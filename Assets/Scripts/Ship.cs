using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX, movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x*-100;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, movementY);
        Vector3 rotation = new Vector3(0, 0, movementX);
        Quaternion deltaRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        rb.AddForce(movement);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
