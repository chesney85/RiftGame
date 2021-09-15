using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class DespawnGameObject : MonoBehaviour
{

    public float timeToDespawn;
    private void OnEnable()
    {
        StartCoroutine(Despawn());
    }

    IEnumerator 
        Despawn()
    {
        yield return new WaitForSeconds(timeToDespawn);
        LeanPool.Despawn(gameObject);
    }
}
