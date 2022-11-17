using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;

    float timer;

    private void Update()
    {
        //when timer hits 0, call method SpawnEnemy
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }
    private void SpawnEnemy()
    {

        //generate position based on spawnArea
        Vector3 position = new Vector3(
            UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
            UnityEngine.Random.Range(-spawnArea.y, spawnArea.y),
            0f
            );

        //create new enemy
        GameObject newEnemy = Instantiate(enemy);
        //assisn spawning position to new instantiation
        newEnemy.transform.position = position;
        // gives newEnemy target destination by passing player object through SetTarget (methon in Enemy.cs)
        newEnemy.GetComponent<Enemy>().SetTarget(player);
    }
}
