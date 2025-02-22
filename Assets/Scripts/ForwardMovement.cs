using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    // public Transform directionTransform;
    // private Vector3 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        // moveDirection = directionTransform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
