using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Obstacle Obj", menuName = "ChromeDino/Obstacle")]
public class Obstacle : ScriptableObject
{
    public GameObject obstaclePrefab;
    public string Name;
    public float damage;
    public int stackAmount;
    public Vector2 groundOffset;
}


