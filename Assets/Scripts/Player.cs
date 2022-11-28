using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : Ship
{
    public GameObject pauseMenu;
    private float movementX, movementY, currentSpeed;
    private Vector2 direction;
    private Vector3 turnVector, lastPosition;
    private float turnAccumulator = 0.002f;
    const float TURN_INCREASE = 0.02f;
    [SerializeField]
    private TMP_Text speedUI;

    private void Start()
    {
        lastPosition = Vector3.zero;
        shipType = PlayerPrefs.GetInt("Ship");
        setShipStats();
        base.rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x * -100;
        movementY = movementVector.y;
        print("X:"+movementX);
        print("Y:"+movementY);

        direction = movementVector.normalized;
    }

    void OnPause()
    {
        if (pauseMenu.active)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    void Update()
    {
        turnVector = new Vector3(0, handling * turnAccumulator, 0);
        if (movementX != 0)
            turnAccumulator += TURN_INCREASE;
        else
            turnAccumulator = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movePos = rb.transform.position - transform.position;
        Quaternion deltaRotation = Quaternion.Euler(direction.x * turnVector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.AddForce(movementY * transform.forward * speed);
        speedUI.text = getSpeed().ToString();
    }

    public float getSpeed()
    {
        currentSpeed = Mathf.Round(Vector3.Distance(transform.position, lastPosition) * 100000f)/100f;
        lastPosition = transform.position;
        return currentSpeed;
    }
}
