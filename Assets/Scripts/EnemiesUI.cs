using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesUI : MonoBehaviour
{
    public TMP_Text enemiesText;
    // Start is called before the first frame update
    void Start()
    {
        enemiesText = GetComponent<TMP_Text>();
        // enemiesText.text = "Enemies: "+EnemyManager.instance.enemies.Count.ToString();
        EnemyManager.instance.onChanged.AddListener(UpdateEnemiesText);
    }

    void UpdateEnemiesText() {
        enemiesText.text = "Enemies: "+EnemyManager.instance.enemies.Count.ToString();
    }
}
