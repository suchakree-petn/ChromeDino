using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    Left = -1,
    Right = 1
}
public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public float SceneMoveSpeed;
    public float MoveSpeedGrowth;
    public Direction moveDirection;
    void Awake()
    {
        Instance = this;

        if (transform.childCount == 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        GameController.OnStart += InitialScene;
        GameController.OnStart += SpeedUpRate;
        GameController.InGame += MoveScene;
    }
    private void OnDisable()
    {
        GameController.OnStart -= InitialScene;
        GameController.OnStart -= SpeedUpRate;
        GameController.InGame -= MoveScene;
    }
    void InitialScene()
    {
        transform.position = Vector3.zero;
    }
    void MoveScene()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.MovePosition(rb2D.position + Vector2.right * (int)moveDirection * SceneMoveSpeed * Time.fixedDeltaTime);

        // Reset scene pos
        if (transform.position.x <= -36.6f)
        {
            transform.position = Vector3.zero;
        }
    }

    void SpeedUpRate()
    {
        StartCoroutine(SpeedUpCooldown());
    }


    // Speed up every 10 sec
    IEnumerator SpeedUpCooldown()
    {
        yield return new WaitForSeconds(5);
        SceneMoveSpeed += MoveSpeedGrowth;
        SpeedUpRate();
    }
}
