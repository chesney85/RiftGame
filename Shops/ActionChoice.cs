using System.Collections;
using Lean.Pool;
using UnityEngine;

public class ActionChoice : MonoBehaviour
{
    public InventoryActions ia;
    public GameObject particleIfUsed;
    public GameObject objectForAction;

    public enum Actions
    {
        BuyHipGun,
        BuyShoulderGun,
        BuyGlove,
        EquipHip,
        EquipShoulder,
        WearHand
    }

    public Actions actions;

    public void DoAction()
    {
        switch (actions)
        {
            case Actions.BuyGlove:
                if (ia.playerTokens >= 1)
                {
                    ia.playerTokens--;
                    ia.BuyGlove(objectForAction);
                    StartCoroutine(PlayParticle());
                    Destroy(transform.GetChild(1).gameObject);
                    ia.PlayRandomExclamation();
                    actions = Actions.WearHand;
                }
                else
                {
                    ia.NotEnoughTokens();
                }

                break;
            case Actions.BuyHipGun:
                if (ia.playerTokens >= 2)
                {
                    ia.playerTokens -= 2;
                    ia.buyGun(objectForAction);
                    StartCoroutine(PlayParticle());
                    Destroy(transform.GetChild(1).gameObject);
                    ia.PlayRandomExclamation();
                    actions = Actions.EquipHip;
                }
                else
                {
                    ia.NotEnoughTokens();
                }

                break;
            case Actions.BuyShoulderGun:
                if (ia.playerTokens >= 3)
                {
                    ia.playerTokens -= 3;
                    ia.buyGun(objectForAction);
                    StartCoroutine(PlayParticle());
                    Destroy(transform.GetChild(1).gameObject);
                    ia.PlayRandomExclamation();
                    actions = Actions.EquipShoulder;
                }
                else
                {
                    ia.NotEnoughTokens();
                }

                break;
            case Actions.EquipHip:
                ia.EquipGun(ia.leftHip, objectForAction);
                ia.EquipGun(ia.rightHip, objectForAction);
                break;
            case Actions.EquipShoulder:
                ia.EquipGun(ia.leftShoulder, objectForAction);
                ia.EquipGun(ia.rightShoulder, objectForAction);
                break;
            case Actions.WearHand:
                ia.EquipGlove(ia.leftHand, objectForAction);
                ia.EquipGlove(ia.rightHand, objectForAction);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DoAction();
        }
    }


    IEnumerator PlayParticle()
    {
        GameObject go = LeanPool.Spawn(particleIfUsed, transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);
        LeanPool.Despawn(go);
    }
}