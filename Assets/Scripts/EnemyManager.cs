using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public List<EnemyBehavior> enemies;
    public UnityEvent onChanged;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is already a EnemyManager in the scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddEnemy(EnemyBehavior enemy) {
        enemies.Add(enemy);
        onChanged.Invoke();
    }
    public void RemoveEnemy(EnemyBehavior enemy) {
        enemies.Remove(enemy);
        onChanged.Invoke();
    }
}
