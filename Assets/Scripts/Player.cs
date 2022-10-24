using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Ship
{
    private float movementX, movementY;
    private Vector2 direction;
    private Vector3 turnVector;

    private void Start()
    {
        base.rb = GetComponent<Rigidbody>();
        turnVector = new Vector3(0, handling * 10, 0);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x * -100;
        movementY = movementVector.y;

        direction = movementVector.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(direction.x * turnVector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.MovePosition(rb.position + transform.forward * direction.y * base.speed * Time.deltaTime);
    }
}
