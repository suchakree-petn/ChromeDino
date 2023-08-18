using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleController : MonoBehaviour
{
    public static ObstacleController Instance;

    // List of obstacle
    [SerializeField] private List<Obstacle> obstacleList;

    // Obstacle ground offset
    [SerializeField] private Vector2 groundOffset;

    // Spawn cooldown time
    [SerializeField] private float[] spawnCooldownTime;

    private bool Is_readyToSpawn = true;



    private void Awake()
    {
        Instance = this;
    }

    // Spawn a group of obstacle
    public void SpawnObtacle()
    {
        if (Is_readyToSpawn)
        {
            // Random obstacle
            int obstacleIndex = Random.Range(0, obstacleList.Count);

            // Instantiate and set position in scene;
            GameObject obstacleInScene = InstantiateObstacle(obstacleList[obstacleIndex]);
            obstacleInScene.transform.position = new Vector3(groundOffset.x,
                                                            groundOffset.y + obstacleList[obstacleIndex].groundOffset.y,
                                                            0);

            // Add rigidbody                                                
            obstacleInScene.AddComponent(typeof(Rigidbody2D));
            obstacleInScene.GetComponent<Rigidbody2D>().gravityScale = 0;

            // Random spawn cooldown
            float randomCD = Random.Range(spawnCooldownTime[0], spawnCooldownTime[1]);
            StartCoroutine(SpawnCooldown(randomCD));
        }
    }


    // Create Obstable
    private GameObject InstantiateObstacle(Obstacle obstacle)
    {
        // Get random obstacle amount per group
        int amount = Random.Range(1, obstacle.stackAmount);

        //Declare obstacle's parent
        GameObject obstacleParent = new GameObject();
        obstacleParent.name = "Obstacle";

        float startX = 0, startY = 0;
        float prevX = 0;
        float childPadding = 0;

        // Instantiate obstacle in parent
        for (int i = 0; i < amount; i++)
        {
            GameObject obstacleChild = Instantiate(obstacle.obstaclePrefab, obstacleParent.transform);

            // Scale child
            if (obstacle.stackAmount > 1)
            {
                float scale = Random.Range(0.5f, 1);
                obstacleChild.transform.localScale = new Vector3(scale, scale, scale);
            }

            // Set position
            childPadding = obstacleChild.transform.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
            if (i == 0)
            {
                startX = -childPadding / 2;
                startY = obstacleChild.transform.GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2;

            }
            startX = (childPadding / 2) + startX + (prevX / 2);
            obstacleChild.transform.position = new Vector3(startX,
                                                        (obstacleChild.transform.GetComponentInChildren<SpriteRenderer>().bounds.size.y) / 2 - startY,
                                                        0f);
            prevX = childPadding;
        }
        return obstacleParent;
    }
    private IEnumerator SpawnCooldown(float spawnCooldownTime)
    {
        Is_readyToSpawn = false;
        yield return new WaitForSeconds(spawnCooldownTime);
        Is_readyToSpawn = true;
    }
    private void OnEnable()
    {
        GameController.InGame += SpawnObtacle;
    }
    private void OnDisable()
    {
        GameController.InGame -= SpawnObtacle;
    }
}
