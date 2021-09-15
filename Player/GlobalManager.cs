using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Samples.VrHoops;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager GM;
    public GameObject Player;

    private void Awake()
    {
      
        if (GM == null || GM != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GM = this;
        }
        
    }
    
}
