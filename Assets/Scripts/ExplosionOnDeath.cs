using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{
    public GameObject particlePrefab;
    // Start is called before the first frame update
    void Awake()
    {
        // var life  = GetComponent<Life>();
        // life.OnDeath.AddListener(OnDeath);
    }

    void OnDeatroy()
    {
        Instantiate(particlePrefab, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
