using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

[Serializable]
class PlayerData
{
    public string position;
    public string rotation;
}


public class GameSaveManager : MonoBehaviour
{
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        // keyboard support
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    public void OnSaveButton_Pressed()
    {
        SaveGame();
    }

    public void OnLoadButton_Pressed()
    {
        LoadGame();
    }

    // Serializing Data (Encoding)
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        PlayerData data = new PlayerData();
        data.position = JsonUtility.ToJson(playerTransform.position);
        data.rotation = JsonUtility.ToJson(playerTransform.rotation.eulerAngles);
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    // Deserializing Data (Decoding)
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            playerTransform.gameObject.GetComponent<CharacterController>().enabled = false;
            playerTransform.position = JsonUtility.FromJson<Vector3>(data.position);
            playerTransform.rotation = Quaternion.Euler(JsonUtility.FromJson<Vector3>(data.rotation));
            playerTransform.gameObject.GetComponent<CharacterController>().enabled = true;

            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no save data!");
        }
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath + "/MySaveData.dat");
            Debug.Log("Data reset complete!");
        }
        else
        {
            Debug.LogError("No save data to delete.");
        }
    }
}
