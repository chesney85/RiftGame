using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public List<GameObject> itemsToSell;
    private int index;
    public PlayerInventory playerInventory;
    private Animator anim;
    private bool isAnimating;
    private GameObject itemToShow;
    public GameObject itemToShowParent;
    public GameObject purchasedParticlePrefab;
//    public HolsterInteract holster;
//    public GameObject leftHand;
//    public GameObject rightHand;
//    public GameObject avatar;
//    [Tooltip("6 = left shoulder, 7 = rightHip, 8 = leftHip, 9 = rightShoulder")] public int holsterChildNumber;


 
    private void OnEnable()
    {
//        StartCoroutine(GetAvatar());
        RefreshList();
        First();
        Next();
    }

    private void OnDisable()
    {
        Destroy(itemToShow);
    }


    public void BuyWeapon()
    {
       playerInventory.AddWeapon(itemsToSell[index]);
       itemsToSell.Remove(itemsToSell[index]);
       RefreshList();
       FirstItem();
       StartCoroutine(Purchased());
       Next();
    }

    public void BuyApparel()
    {
        playerInventory.AddApparel(itemsToSell[index].GetComponent<MenuItems>().getItem());
        itemsToSell.Remove(itemsToSell[index]);
        RefreshList();
        FirstItem();
        StartCoroutine(Purchased());
        Next();
    }

    IEnumerator Purchased()
    {
       GameObject go = LeanPool.Spawn(purchasedParticlePrefab, itemToShow.transform.position, itemToShow.transform.rotation);
        yield return new WaitForSeconds(1f);
        LeanPool.Despawn(go);
    }
    
    
    public IEnumerator LastItem()
    {
        isAnimating = true;
        anim.Play("ScaleDown");
        yield return new WaitForSeconds(1f);
        index--;
        if (index < 0)
        {
            index = itemsToSell.Count -1;
        }
        Destroy(itemToShow);
        itemToShow = Instantiate(itemsToSell[index], itemToShowParent.transform.position, itemToShowParent.transform.rotation);
        itemToShow.transform.SetParent(itemToShowParent.transform);
        anim = itemToShow.GetComponent<Animator>();
        anim.Play("ScaleUp");
        yield return new WaitForSeconds(1f);
        isAnimating = false;
    }

    public IEnumerator NextItem()
    {
        isAnimating = true;
        anim.Play("ScaleDown");
        yield return new WaitForSeconds(1f);
        index++;
        
        if (index > itemsToSell.Count -1)
        {
            index = 0;
        }
        Destroy(itemToShow);
        itemToShow = Instantiate(itemsToSell[index], itemToShowParent.transform.position, itemToShowParent.transform.rotation);
        itemToShow.transform.SetParent(itemToShowParent.transform);
        anim = itemToShow.GetComponent<Animator>();
        anim.Play("ScaleUp");
        yield return new WaitForSeconds(1f);
        isAnimating = false;
    }

   public IEnumerator FirstItem()
    {
        isAnimating = true;
        //show First Object in List
        index = 0;
        Destroy(itemToShow);
        //Get animator of first object
        if (itemsToSell.Count > 0)
        {
            itemToShow = Instantiate(itemsToSell[index], itemToShowParent.transform.position, itemToShowParent.transform.rotation);
            itemToShow.transform.SetParent(itemToShowParent.transform);
            anim = itemToShow.GetComponent<Animator>();
            //scale it up
            anim.Play("ScaleUp");
        }
        yield return new WaitForSeconds(1f);
        isAnimating = false;
    }

   public void Next()
   {
       StartCoroutine("NextItem");
   }
   public void Last()
   {
       StartCoroutine("LastItem");
   }
   public void First()
   {
       StartCoroutine("FirstItem");
   }

   public bool GetIsAnimating()
   {
       return isAnimating;
   }

   void RefreshList()
   {
       List<GameObject> temp = new List<GameObject>();
       for (int i = 0; i < itemsToSell.Count; i++)
       {
           if (itemsToSell[i] != null)
           {
            temp.Add(itemsToSell[i]);   
           }
           
       }
       itemsToSell.Clear();
       for (int i = 0; i < temp.Count; i++)
       {
           if (temp[i] != null)
           {
              itemsToSell.Add(temp[i]);   
           }
       }
   }

//   IEnumerator HandSetup()
//   {
//       yield return new WaitForSeconds(5f);
//       leftHand = avatar.transform.GetChild(5).gameObject;
//      rightHand = avatar.transform.GetChild(6).gameObject;
//     holster = avatar.transform.parent.GetChild(holsterChildNumber).gameObject.GetComponent<HolsterInteract>();
//   }
}