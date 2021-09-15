using System.Collections;
using System.Collections.Generic;
using EmeraldAI;
using Lean.Pool;
using UnityEngine;

public class EmeraldEnemyEvents : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject DeathEffect;
    public GameObject EnemySelf;
    public GameObject enemyModel;
    public GameObject gunModel;
    public GameObject muzzle;


    public void ShootBullet()
    {
        LeanPool.Spawn(Projectile, muzzle.transform.position, muzzle.transform.rotation);
    }

    public void Die()
    {
        enemyModel.SetActive(false);
        gunModel.SetActive(false);
       LeanPool.Spawn(DeathEffect,transform.position, transform.rotation);
         LeanPool.Despawn(transform.root.gameObject,1.2f);

    }

    public void AISetup()
    {
        enemyModel.SetActive(true);
        gunModel.SetActive(true);
        EmeraldAISystem enemiesEmerald = EnemySelf.GetComponent<EmeraldAISystem>();
        enemiesEmerald.BehaviorRef = EmeraldAISystem.CurrentBehavior.Aggressive;
        enemiesEmerald.ConfidenceRef = EmeraldAISystem.ConfidenceType.Brave;
    }

}