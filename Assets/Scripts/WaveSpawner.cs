using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float startTime;
    public float endTime;
    public float spawnRate;
    void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }

    void Spawn()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        BulletMovement enemyScript = enemy.GetComponent<BulletMovement>();
        if (enemyScript != null)
        {
            enemyScript.speed = 1f;
            enemyScript.directionTransform = transform;
        }
    }
}
