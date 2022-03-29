using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBotController : MonoBehaviour
{
    public Animator controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            controller.SetInteger("AnimationState", 0); // idle
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            controller.SetInteger("AnimationState", 1); // walk
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            controller.SetInteger("AnimationState", 2); // punch
        }
    }
}
