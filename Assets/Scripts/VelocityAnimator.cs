using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityAnimator : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", rb.velocity.magnitude);
    }
}
