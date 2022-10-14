using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] protected int speed = 15, handling = 40, weight, health;
    [SerializeReference] protected Color color;
    protected int gridPostion;
    protected float distanceToCelesitalBody;
    protected Rigidbody rb;


}
