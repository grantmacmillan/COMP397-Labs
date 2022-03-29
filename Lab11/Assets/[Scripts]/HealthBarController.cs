using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider HealthBar;

    
    public void TakeDamage(int damage)
    {
        HealthBar.value -= damage;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            TakeDamage(5);
        }
    }
}
