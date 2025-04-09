using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class WavesUI : MonoBehaviour
{
    public TMP_Text wavesText;
    // Start is called before the first frame update
    void Start()
    {
        wavesText = GetComponent<TMP_Text>();
        // wavesText.text = "Waves: "+WavesManager.instance.waves.ToString();
        WavesManager.instance.onchanged.AddListener(UpdateWavesText);   
    }

    void UpdateWavesText()
    {
        wavesText.text = "Waves: "+WavesManager.instance.waves.Count.ToString();
    }
}
