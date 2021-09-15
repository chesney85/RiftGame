using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItems : MonoBehaviour
{
   public GameObject prefabToSpawn;
   public Material gloveTexture;
   
   public int indexPosition;

   public GameObject getItem()
   {
      return prefabToSpawn;
   }

   public Material getTexture()
   {
       return gloveTexture;
   }

}
