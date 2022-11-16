using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelector : MonoBehaviour
{
    private ShipType currentShip;

    void Start()
    {
        currentShip = (ShipType)PlayerPrefs.GetInt("Ship", 0);
    }

    public void selectShip(int ship)
    {
        PlayerPrefs.SetInt("Ship", ship);
        currentShip = (ShipType)ship;
    }
}
