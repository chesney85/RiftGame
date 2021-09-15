using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

  private bool grabbing;
    private bool triggerHeld;
    public float grabRadius = 0.2f;
    public LayerMask grabMask = 1 << 9;
    public GameObject targetObject;
    public GameObject grabbedObject;
    public OVRInput.Controller controller;
    public OVRInput.Axis1D gripTrigger;
    public OVRInput.Axis1D indexTrigger;
    

    private void Update()
    {
        LookForInteraction();

        LookForVibration();

        if (!triggerHeld && !grabbing && OVRInput.Get(indexTrigger) > 0.2f)
        {
            HandTrigger();
        }

        if (grabbing && OVRInput.Get(gripTrigger) < 0.2f)
        {
            grabbedObject.GetComponent<Interact>().DropAction(controller,OVRInput.GetLocalControllerVelocity(controller), OVRInput.GetLocalControllerAngularVelocity(controller));
            grabbedObject = null;
            grabbing = false;
            targetObject = null;
            triggerHeld = false;
        }

        if (!grabbing && targetObject && OVRInput.Get(gripTrigger) > 0.2f)
        {
            grabbedObject = targetObject;
            targetObject = null;
            grabbedObject.transform.GetComponent<Interact>().GrabbedAction();
            grabbing = true;
                        triggerHeld = true;
            if (transform.GetChild(2).gameObject != null)
            {
                grabbedObject = transform.GetChild(2).gameObject;
                grabbedObject.transform.GetComponent<Interact>().GrabbedAction();
            }
            
        }

        if (grabbing && OVRInput.Get(indexTrigger) > 0.2f)
        {
            grabbedObject.transform.GetComponent<Interact>().TriggerAction();
        }
    }

    public void HandTrigger()
    {

    }

    public void LookForVibration()
    {
        if (!grabbing && targetObject != null)
        {
            OVRInput.SetControllerVibration(0.1f, 0.1f, controller);
        }
        else
        {
            OVRInput.SetControllerVibration(0, 0, controller);
        }
    }
    
    void LookForInteraction()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);
        int closestHit = 0;
        if (hits.Length > 0)
        {
            closestHit = 0;

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].distance < hits[closestHit].distance)
                {
                    closestHit = i;
                }
            }
        }

        if (hits.Length != 0)
        {
            targetObject = hits[closestHit].transform.gameObject;
        }
        else
        {
            targetObject = null;
        }
    }

//    public override OVRInput.Controller GetController()
//    {
//        return controller;
//    }

//    private IEnumerator HandSetup()
//    {
//        yield return new WaitForSeconds(1f);
//        material = transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
//    }

//    public override void SetMaterial(Texture _texture)
//    {
//        material.mainTexture = _texture;
//    }
}
