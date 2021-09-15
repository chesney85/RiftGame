using UnityEngine;


public class Interact : MonoBehaviour
{

   //This is an Abstract class which will be overwritten by child class
   //The methods here return integers to be used in a switch attached 
   //to the Left and Right Grab classes. They determine what to do with grabbed object
   //based on what object type it is
   
   

   public virtual void TriggerAction()
   {
      
   }

   public virtual void GrabbedAction()
   {
      
   }

   public virtual void DropAction(OVRInput.Controller _controller,Vector3 _velocity, Vector3 _angularVelocity)
   {
      
   }


 
   
   
}
