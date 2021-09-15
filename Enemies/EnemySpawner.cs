using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
//    public GameObject Enemy;
    private bool spawning;
    public float timeToSpawn;
    public GameObject Enemy;

    private void Start()
    {
        spawning = false;
    }

    private void Update()
    {
        if (!spawning)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        spawning = true;
        LeanPool.Spawn(Enemy, transform.position, transform.rotation);
        yield return new WaitForSeconds(timeToSpawn);
        spawning = false;
    }
}