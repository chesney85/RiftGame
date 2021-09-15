using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableCollider : MonoBehaviour
{
    public List<GameObject> toEnable;
    public List<GameObject> toDisable;
    public bool enable;
    public bool disable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enable && toEnable.Count > 0)
            {
                for (int i = 0; i < toEnable.Count; i++)
                {
                    toEnable[i].SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (disable && toDisable.Count > 0)
            {
                if (enable && toDisable.Count > 0)
                {
                    for (int i = 0; i < toDisable.Count; i++)
                    {
                        toDisable[i].SetActive(false);
                    }
                }
            }

        }
    }
}