using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteract : Interact
{
    
    public EnterCar ec;


        public override void TriggerAction()
        {
            ec.enabled = !ec.enabled;
        }
}
