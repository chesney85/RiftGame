using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSphere : MonoBehaviour
{

    public Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>().position = newPos;
    }

   
}
