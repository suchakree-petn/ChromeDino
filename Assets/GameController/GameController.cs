using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum GameState
{
    Start,
    InGame,
    GameEnding
}
public class GameController : MonoBehaviour
{
    //Current game state
    GameState state;

    // List of obstacle
    [SerializeField] private List<Obstacle> obstacleList;

    private void Awake()
    {
        // Initial game state
        state = GameState.Start;
    }

    private void Start()
    {
        InstantiateObstacle(obstacleList[0]);
    }

    // Get a group of obstacle
    public GameObject InstantiateObstacle(Obstacle obstacle)
    {
        // Get random obstacle amount per group
        int amount = Random.Range(1, obstacle.stackAmount);
        amount = 3;
        Debug.Log("amount: " + obstacle.stackAmount);

        //Declare obstacle's parent
        GameObject obstacleParent = new GameObject();
        obstacleParent.name = "Obstacle";

        float childPadding = 0;

        // Instantiate obstacle in parent
        for (int i = 0; i < amount; i++)
        {
            GameObject obstacleChild = Instantiate(obstacle.obstaclePrefab, obstacleParent.transform);
            float scale = Random.Range(0.25f, 1);
            obstacleChild.transform.localScale = new Vector3(scale, scale, scale);
            childPadding += scale * 0.36f;
            obstacleChild.transform.position = new Vector3(childPadding, 0f, 0f);
        }
        return obstacleParent;
    }
}
