using System.Collections;
using EmeraldAI;
using Lean.Pool;
using UnityEngine;


public class BulletImpact : MonoBehaviour
{
    [Header("Bullet Info")]
    public GameObject bloodParticle;
//    public GameObject impactParticle;
    public int bulletDamage;
    public float bulletSpeed;
    
//    private float step;
    private EmeraldAISystem em;


//    private void OnEnable()
//    {
//        step = 0;
//    }

    private void Update()
    {
       float step = bulletSpeed * Time.deltaTime; // calculate distance to move
        transform.position += transform.forward * step;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EmeraldAI"))
        {
            em = other.gameObject.GetComponent<EmeraldAISystem>();
            em.Damage(bulletDamage, EmeraldAISystem.TargetType.AI, other.transform);
            StartCoroutine(BloodImpact());
        }
    }

    IEnumerator BloodImpact()
    {
        LeanPool.Spawn(bloodParticle, transform.position, UnityEngine.Random.rotation);
        yield return new WaitForSeconds(1f);
        LeanPool.Despawn(bloodParticle);
        LeanPool.Despawn(gameObject,0.5f);
    }
}