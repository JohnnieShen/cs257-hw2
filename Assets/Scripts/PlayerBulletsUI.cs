using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBulletsUI : MonoBehaviour
{
    TMP_Text text;
    public PlayerShooting playerShooting;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Ammo: "+playerShooting.ammo.ToString();
    }
}
