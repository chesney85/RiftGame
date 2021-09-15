using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteract : Interact
{
    private bool isOpen;
    private bool isChanging;
    public GameObject open;
    public GameObject closed;
    public GameObject shop;
    public GameObject sellItemParent;
    


    private void Start()
    {
        isOpen = false;
        isChanging = false;
    }

    public override void GrabbedAction()
    {
        if (!isOpen && !isChanging)
        {
            StartCoroutine("Open");
        }
        else if (isOpen && !isChanging)
        {
            StartCoroutine("Close");
        }
        
        
    }

    IEnumerator Open()
    {
        isChanging = true;
        open.SetActive(false);
        closed.SetActive(true);
        shop.SetActive(true);
        isOpen = true;
        yield return new WaitForSeconds(1f);
        isChanging = false;
    }

    IEnumerator Close()
    {
        isChanging = true;
        open.SetActive(true);
        closed.SetActive(false);
        shop.SetActive(false);
        isOpen = false;
        Destroy(sellItemParent.transform.GetChild(0).gameObject);
        yield return new WaitForSeconds(1f);
        isChanging = false;
    }

    
}
