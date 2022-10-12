using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private int speed = 15, turning = 40;
    private Rigidbody rb;
    private float movementX, movementY;
    private Vector2 direction;
    private Vector3 turnVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        turnVector = new Vector3(0, turning*10, 0);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x*-100;
        movementY = movementVector.y;

        direction = movementVector.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Quaternion deltaRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        //rb.AddForce(movement);
        //rb.MoveRotation(rb.rotation * deltaRotation);

        Quaternion deltaRotation = Quaternion.Euler(direction.x * turnVector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.MovePosition(rb.position + transform.forward * direction.y * speed * Time.deltaTime);
    }
}
