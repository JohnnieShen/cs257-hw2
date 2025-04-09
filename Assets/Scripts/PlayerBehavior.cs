using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Vector2 movementValue;
    private float lookValue;
    private Rigidbody rb;
    public float health;
    public float maxHealth;
    public UnityEvent onDeath;
    // Start is called before the first frame update
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.AddRelativeForce(movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime);
        rb.AddTorque(0, lookValue*Time.deltaTime, 0);
        if (health <= 0) {
            onDeath.Invoke();
        }
    }
    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>() * speed;
    }
    public void OnLook(InputValue value)
    {
        Vector2 mouseInput = value.Get<Vector2>();
        float rotationAmount = mouseInput.x * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0, rotationAmount, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // float rotation = Input.GetAxis("Mouse X");
    //     // transform.Rotate(0, rotation * rotationSpeed*Time.deltaTime, 0);
    //     // if (Input.GetKey(KeyCode.W))
    //     // {
    //     //     transform.position += new Vector3(0, 0, speed*Time.deltaTime);
    //     // }
    //     // if (Input.GetKey(KeyCode.S))
    //     // {
    //     //     transform.position += new Vector3(0, 0, -speed*Time.deltaTime);
    //     // }
    //     // if (Input.GetKey(KeyCode.A))
    //     // {
    //     //     transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
    //     // }
    //     // if (Input.GetKey(KeyCode.D))
    //     // {
    //     //     transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
    //     // }


    //     // transform.Translate(movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime);
    //     // transform.Rotate(0, lookValue * Time.deltaTime, 0);
        
    // }
}
