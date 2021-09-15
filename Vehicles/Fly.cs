using UnityEngine;
using System.Collections;


public class Fly : MonoBehaviour
{
// Use this for initialization
    private Rigidbody rigidbody;
    Vector3 zero;
    private bool fixingRot;
    public float moveSpeed;

    public float RotateBackSpeed;
    void Start()
    {
        Debug.Log("Fly script added to: " + gameObject.name);
        rigidbody = GetComponent<Rigidbody>();
    }

// Update is called once per frame
    void Update()
    {
        
//        rigidbody.MovePosition(rigidbody.position + transform.forward * Time.deltaTime * 0f );
//        if (Input.GetButton("Fire1"))
//            rigidbody.MovePosition(rigidbody.position + transform.forward * Time.deltaTime * 8f );
//
//        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") !=0 || Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") !=0 || Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal") !=0)
//        {
//            transform.Rotate(Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical"), 
//                Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal"), -Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal"));
//        }

        //To move forward
        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger")> 0.2)
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward * Time.deltaTime * moveSpeed );
        }
        //to move backwards
        else if (Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger")> 0.2)
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward * Time.deltaTime * -moveSpeed );
        }
        //to move up
        if (Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") > 0.2)
        {
            rigidbody.MovePosition(rigidbody.position + transform.up * Time.deltaTime * moveSpeed );
        }
        //to move down
        else if(Input.GetAxis("Oculus_CrossPlatform_SecondaryHandTrigger") > 0.2)
        {
             rigidbody.MovePosition(rigidbody.position + transform.up * Time.deltaTime * -moveSpeed );
        }
        
        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") !=0 || Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") !=0 || Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal") !=0)
       {
           transform.Rotate(Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical"), 
                Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal"), -Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal"));
      }
        
        

    }

}