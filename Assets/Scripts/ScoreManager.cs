using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public int score;
    public static ScoreManager instance;
    public TMP_Text scoreText;
    public TMP_Text playerHealthText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is already a ScoreManager in the scene");
        }
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        playerHealthText.text = "Health: " + WavesGameMode.instance.player.health;
    }
}
