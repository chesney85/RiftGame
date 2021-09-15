using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseInteract : MonoBehaviour
{
    public CharacterController charControl;
    public OVRPlayerController playerControl;
    private GameObject seatSpawn;
    public HorseController horseControl;
    public CharacterController horseCharControl;
    public GameObject player;
    public Vector3 seatOffset;
    public Vector3 getOffSet;
    private bool isOn;
   

    private void OnEnable()
    {
        seatSpawn = transform.root.GetChild(3).gameObject;
        isOn = false;
    }




    private void Update()
    {
        if (isOn && Input.GetButtonDown("Oculus_CrossPlatform_Button4"))
        {
            StartCoroutine("GetOff");
        }

        if (!isOn && Input.GetButtonDown("Oculus_CrossPlatform_Button4"))
        {
            StartCoroutine("GetOn");
        }


       
    }

    IEnumerator GetOn()
    {
        
        charControl.enabled = false;
        playerControl.enabled = false;
        player.transform.SetParent(seatSpawn.transform);
        player.transform.rotation = seatSpawn.transform.localRotation;
        player.transform.position = seatSpawn.transform.position + seatOffset;
        horseControl.enabled = true;
        horseCharControl.enabled = true;
        yield return new WaitForSeconds(1f);
        isOn = true;
    }

    IEnumerator GetOff()
    {
        
        charControl.enabled = true;
        playerControl.enabled = true;
        player.transform.SetParent(null);
        player.transform.position = seatSpawn.transform.position + getOffSet;
        horseControl.enabled = false;
        horseCharControl.enabled = false;
        yield return new WaitForSeconds(1f);
        isOn = false;
    }
    
    
}
