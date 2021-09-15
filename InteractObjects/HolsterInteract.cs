using Lean.Pool;
using UnityEngine;

public class HolsterInteract : Interact
{
    public GameObject itemToSpawn;
    public GameObject hand;
    public Camera camera;
    
    [Header("Int To Represent List Position Of Player Inventory")]
    public int gunIndex;

    public override void GrabbedAction()
    {
        GameObject go = LeanPool.Spawn(itemToSpawn, hand.transform.position, hand.transform.rotation);
        go.GetComponent<Rigidbody>().isKinematic = true;
        go.transform.SetParent(hand.transform);
    }

    public void SetItemToSpawn(GameObject _itemToSpawn)
    {
        itemToSpawn = _itemToSpawn;
    }

}
