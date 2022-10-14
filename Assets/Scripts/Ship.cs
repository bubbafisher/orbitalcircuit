using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] protected int speed = 15, turning = 40;
    protected Rigidbody rb;


}
