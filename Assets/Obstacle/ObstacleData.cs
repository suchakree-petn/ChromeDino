using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleData : MonoBehaviour
{
    public Obstacle obstacle;
    public void MoveObstacle()
    {
        Rigidbody2D rb2D = transform.GetComponentInParent<Rigidbody2D>();
        if (rb2D != null)
        {
            rb2D.MovePosition(rb2D.position + Vector2.right * (int)SceneController.Instance.moveDirection * SceneController.Instance.SceneMoveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnEnable()
    {
        GameController.InGame += MoveObstacle;
    }
    private void OnDisable()
    {
        GameController.InGame -= MoveObstacle;
    }

}
