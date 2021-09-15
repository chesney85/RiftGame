using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerPlay : MonoBehaviour
{
    private Animator anim;
    public string animName;
    private OVRInput.Controller controller;
    private OVRHapticsClip myHapticsClip;
    public AudioClip myVibrationClip;


    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        anim.enabled = true;
        myHapticsClip = new OVRHapticsClip(myVibrationClip);
    }

    private void OnTriggerEnter(Collider other)
    {
        
            controller = other.transform.parent.gameObject.GetComponent<Hand>().controller;
            if (controller == OVRInput.Controller.LTouch)
            {
                OVRHaptics.LeftChannel.Mix(myHapticsClip);
            }
            if (controller == OVRInput.Controller.RTouch)
            {
                OVRHaptics.RightChannel.Mix(myHapticsClip);
            }
            anim.enabled = true;
            anim.SetBool("canPulse", true);
    }

    private void OnTriggerStay(Collider other)
    {
       
        if (controller == OVRInput.Controller.LTouch)
        {
            OVRHaptics.LeftChannel.Mix(null);
        }
        if (controller == OVRInput.Controller.RTouch)
        {
            OVRHaptics.RightChannel.Mix(null);
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
       
        if (controller == OVRInput.Controller.LTouch)
        {
            OVRHaptics.LeftChannel.Mix(null);
        }
        if (controller == OVRInput.Controller.RTouch)
        {
            OVRHaptics.RightChannel.Mix(null);
        }
//            OVRInput.SetControllerVibration(0,0,controller);
            anim.SetBool("canPulse", false);
            anim.enabled = false;
        
    }
}