using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Ship : MonoBehaviour
{
    protected int shipType;
    protected int speed = 70, handling = 40, weight = 400, health;
    [SerializeField] protected Mesh[] shipLooks = new Mesh[6];
    private MeshFilter shipMesh;
    public MeshFilter doubleShipMesh;
    protected float distanceToCelesitalBody;
    protected Rigidbody rb;

    public void setShipStats()
    {
        ShipStats ship = ShipStats.ships[shipType];
        shipMesh = gameObject.GetComponent<MeshFilter>();
        //doubleShipMesh = gameObject.GetComponentInChildren<MeshFilter>();
        speed = ship.getSpeed();
        handling = ship.getHandling();
        weight = ship.getWeight();
        shipMesh.mesh = shipLooks[(int)shipType];
        doubleShipMesh.mesh = shipMesh.mesh;
    }
}
