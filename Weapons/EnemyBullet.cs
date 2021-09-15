using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class EnemyBullet : MonoBehaviour
{
    [Header("Bullet Info")]
    public GameObject impactParticle;

    private float bulletSpeed;

    public GameObject camera;
    private Vector3 target;
    private void OnEnable()
    {
        camera = Camera.main.gameObject;
        target = camera.transform.position;
        transform.LookAt(target);
        bulletSpeed = 25f;
    }

    private void Update()
    {
        float step =  bulletSpeed * Time.deltaTime; // calculate distance to move
        transform.position += transform.forward * step;
    }

    private void OnCollisionEnter(Collision other)
    {
//        if (other.gameObject.CompareTag("MainCamera"))
//        {
//            //Do killy player stuff
//            
//        }
        StartCoroutine(Impact());
    }

    IEnumerator Impact()
    {
        LeanPool.Spawn(impactParticle, transform.position, Random.rotation);
        yield return new WaitForSeconds(.2f);
        LeanPool.Despawn(impactParticle);

        LeanPool.Despawn(gameObject);

        
    }

    public void SetVelocity(float _speed)
    {
        bulletSpeed = _speed;
    }
}
