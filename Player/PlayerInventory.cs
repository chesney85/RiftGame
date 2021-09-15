using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> weapons;
    public List<GameObject> apparel;

    public void AddWeapon(GameObject _weapon)
    {
        weapons.Add(_weapon);
    }

    public void AddApparel(GameObject _apparel)
    {
        apparel.Add(_apparel);
    }
}
