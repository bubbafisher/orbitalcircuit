using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipSelector : MonoBehaviour
{
    private ShipType currentShip;
    [SerializeField]
    private Slider thrustSlider, handlingSlider, weightSlider;
    [SerializeField]
    private TMP_Text shipName;
    [SerializeField] protected Mesh[] shipLooks = new Mesh[6];
    [SerializeField] private GameObject shipDisplay, shipDisplay2;
    private string[] shipNames = { "Sparrow", "Vester", "Crusader", "Neo", "Algo", "Invader" };
    void Start()
    {
        currentShip = (ShipType)PlayerPrefs.GetInt("Ship", 0);
        selectShip(PlayerPrefs.GetInt("Ship", 0));
    }

    void Update()
    {
        shipDisplay.transform.Rotate(new Vector3(0f, 0.5f, 0f));
    }

    public void selectShip(int ship)
    {
        PlayerPrefs.SetInt("Ship", ship);
        currentShip = (ShipType)ship;
        shipName.text = shipNames[ship];
        thrustSlider.value = ShipStats.ships[ship].getSpeed();
        handlingSlider.value = ShipStats.ships[ship].getHandling();
        weightSlider.value = ShipStats.ships[ship].getWeight();
        shipDisplay.GetComponent<MeshFilter>().mesh = shipLooks[ship];
        shipDisplay2.GetComponent<MeshFilter>().mesh = shipLooks[ship];
    }
}
