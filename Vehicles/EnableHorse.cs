using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHorse : MonoBehaviour
{
    private HorseInteract hi;

    private void Start()
    {
        hi = GetComponent<HorseInteract>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hi.enabled = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hi.enabled = false;
        }
        
    }
}
