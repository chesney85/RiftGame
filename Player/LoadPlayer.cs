using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    private HandSetup handSetup;

    public GameObject player;

//    public GameObject playerPrefab;

    public GameObject spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
//        player = GameObject.Find("OculusPlayer");
        
//            if (player == null)
//        {
//            player = Instantiate(playerPrefab, spawnLocation.transform.position, spawnLocation.transform.rotation);
//        }
//           

        handSetup = player.transform.GetChild(0).GetChild(10).gameObject
                        .GetComponent<HandSetup>();
        
//        StartCoroutine(LoadPlayerStuff());
    }


    IEnumerator LoadPlayerStuff()
    {
        yield return new WaitForSeconds(5f);
//        handSetup.GetComponent<HandSetup>().LoadPlayer();
    }
}