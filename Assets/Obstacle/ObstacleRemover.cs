using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check obstacle remover
        if (other.transform.parent.CompareTag("Obstacle"))
        {
            Destroy(other.transform.parent.parent.gameObject);
        }
    }
}
