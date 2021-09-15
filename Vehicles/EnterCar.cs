using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCar : MonoBehaviour
{
    public GameObject Player;
    public OVRPlayerController playerController;
    public CharacterController character;
    private bool canEnter;
    private GameObject Parent;
    private bool insideCar;
    public Vector3 offset;
    private bool exiting;
    private VehicleFree vf;

    private bool entering;
    // Start is called before the first frame update
    void OnEnable()
    {
        Parent = transform.root.gameObject;
        vf = Parent.transform.GetComponent<VehicleFree>();
        
    }

    private void Update()
    {
        if (canEnter && OVRInput.Get(OVRInput.Button.Four))
        {
            StartCoroutine("EnteringCar");
        }

        if (insideCar && OVRInput.Get(OVRInput.Button.Four))
        {
            StartCoroutine("ExitingCar");
        }


    }


    IEnumerator EnteringCar()
    {
        Player.transform.position = transform.position + offset;
        Player.transform.rotation = transform.rotation;
        Player.transform.SetParent(transform);
        vf.enabled = true;
        character.enabled = false;
        playerController.enabled = false;
        yield return new WaitForSeconds(1f);
        insideCar = true;
    }

    IEnumerator ExitingCar()
    {
        Player.transform.SetParent(null);
        Player.transform.rotation = Quaternion.Euler(0,0,0);
        character.enabled = true;
        vf.enabled = false;
        playerController.enabled = true;
        yield return new WaitForSeconds(1f);
        insideCar = false;
    }
  

    private void OnTriggerEnter(Collider other)
    {
        
        canEnter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canEnter = false;
    }
}
