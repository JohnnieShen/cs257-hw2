using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WavesManager : MonoBehaviour
{
    public static WavesManager instance;
    public List<WaveSpawner> waves;
    public UnityEvent onchanged;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("There is already a WavesManager in the scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddWave(WaveSpawner wave) {
        waves.Add(wave);
        onchanged.Invoke();
    }
    public void RemoveWave(WaveSpawner wave) {
        waves.Remove(wave);
        onchanged.Invoke();
    }
}
