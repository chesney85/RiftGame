using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScripts : MonoBehaviour
{
   public EnterCar ec;

   private void Awake()
   {
      ec = GetComponent<EnterCar>();
      
   }

   private void OnTriggerEnter(Collider other)
   {
      ec.enabled = true;
   }

   private void OnTriggerExit(Collider other)
   {
      ec.enabled = false;
   }

   
}
