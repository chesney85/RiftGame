using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class DespawnOnDisable : MonoBehaviour
{
  public void Disable()
   {
      LeanPool.Despawn(gameObject);
   }
}
