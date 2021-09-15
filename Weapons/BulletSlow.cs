
using UnityEngine;

public class BulletSlow : MonoBehaviour
{
    public float newSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            EnemyBullet enemy = other.gameObject.GetComponent<EnemyBullet>();
            enemy.SetVelocity(newSpeed);
        }
        
    }
}
