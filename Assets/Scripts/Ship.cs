using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ShipType
{
    Type1 = 0, Type2 = 1, Type3 = 2, Type4 = 3, Type5 = 4, Type6 = 5
}

public class Ship : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] protected int speed = 50, handling = 40, weight = 1000, health;
    [SerializeField] protected ShipType shipType;
    protected int gridPostion;
    protected float distanceToCelesitalBody;
    protected Rigidbody rb;
}
