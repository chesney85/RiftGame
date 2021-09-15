using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerOnStart : MonoBehaviour
{

    public GameObject spawnPosition;
    public GameObject player;
    private void Start()
    {
        StartCoroutine(Player());
    }

    IEnumerator Player()
    {
        yield return new WaitForSeconds(1f);
//        GameObject player = GameObject.Find("OculusPlayer(Clone)");
        player.transform.position = spawnPosition.transform.position;
    }
}
