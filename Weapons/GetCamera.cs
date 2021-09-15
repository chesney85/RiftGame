using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCamera : MonoBehaviour
{
   private void OnEnable()
   {
      GetComponent<Canvas>().worldCamera = Camera.main;
   }
}
