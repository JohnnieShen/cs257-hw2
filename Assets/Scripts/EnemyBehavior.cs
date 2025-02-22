using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyBehavior : MonoBehaviour
{
    public float health;
    public int scoreValue;
    public UnityEvent onDeath;
    void Awake() {
        EnemyManager.instance.AddEnemy(this);
        onDeath.AddListener(() => ScoreManager.instance.score += scoreValue);
    }
    void Update()
    {
        if (health <= 0) {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
    void OnDestroy() {
        // ScoreManager.instance.score += scoreValue;
        onDeath.RemoveAllListeners();
        EnemyManager.instance.RemoveEnemy(this);
    }
}
