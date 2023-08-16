using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(transform.parent.GetComponent<ObstacleData>().obstacle.damage);
        }
    }
}
