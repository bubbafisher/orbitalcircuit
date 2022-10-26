using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RaceType
{
    Race, TimeTrial, FreeRoam
}

public class Race : MonoBehaviour
{
    [Header("Race Settings")]
    [SerializeField]  private RaceType type;
    [SerializeField]  private int lapNumber, numOfOpponents;
    [SerializeField] private PlayerConstructor playerConstructor;

    // Start is called before the first frame update
    void Start()
    {
        playerConstructor.createPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
