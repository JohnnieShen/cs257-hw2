using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float damage;
    public float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        EnemyBehavior enemyBehavior = other.GetComponent<EnemyBehavior>();
        if (enemyBehavior != null) {
            enemyBehavior.health -= damage;
            
        }
    }
}
