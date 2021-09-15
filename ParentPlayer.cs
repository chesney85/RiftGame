using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
//        Debug.Log("Collided with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        other.gameObject.transform.SetParent(transform);
//        Debug.Log("Parented with with " + other.gameObject.transform.parent.name);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.transform.SetParent(null);
    }
}
