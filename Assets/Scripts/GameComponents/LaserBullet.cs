using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthPoints>().TakeDamage(1);
        }

        Destroy(gameObject);
    }
}