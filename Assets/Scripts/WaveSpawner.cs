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
        WavesManager.instance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    void Spawn()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        BulletMovement enemyScript = enemy.GetComponent<BulletMovement>();
        if (enemyScript != null)
        {
            enemyScript.speed = 1f;
            // enemyScript.directionTransform = transform;
        }
    }
    void EndSpawner() {
        WavesManager.instance.RemoveWave(this);
        CancelInvoke();
    }
}
