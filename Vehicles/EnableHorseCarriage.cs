using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHorseCarriage : MonoBehaviour
{
    private HorseCarriageInteract hi;

    private void Start()
    {
        hi = GetComponent<HorseCarriageInteract>();
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
