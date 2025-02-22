using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class WavesGameMode : MonoBehaviour
{
    public static WavesGameMode instance;
    public PlayerBehavior player;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is already a WavesGameMode in the scene");
        }
        player.onDeath.AddListener(onPlayerDeath);
        EnemyManager.instance.onChanged.AddListener(CheckWinCond);
        WavesManager.instance.onchanged.AddListener(CheckWinCond);
    }
    void onPlayerDeath() {
        SceneManager.LoadScene("LoseScene");
    }
    void Update() {
        Debug.Log("Enemies: " + EnemyManager.instance.enemies.Count);
        Debug.Log("Waves: " + WavesManager.instance.waves.Count);
    }

    // Update is called once per frame
    void CheckWinCond()
    {
        if (EnemyManager.instance.enemies.Count <= 0 && WavesManager.instance.waves.Count <= 0) {
            SceneManager.LoadScene("WinScene");
        }
    }
}
