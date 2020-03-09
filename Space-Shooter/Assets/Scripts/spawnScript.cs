using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{

    public GameObject enemy;               //Store values from Unity

    public float spawnTime;                

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addEnemy", 0, spawnTime);              //Spawn an enemy every spawnTime seconds
    }

    private void addEnemy()
    {
        Vector2 spawnPoint = new Vector2(Random.Range(-4.25f,4.25f), transform.position.y);     //Spawn location is the height of the spawn node, and a random width in range of the camera
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }
}
