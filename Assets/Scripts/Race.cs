using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RaceType
{
    Race, TimeTrial, FreeRoam
}

public class Race : MonoBehaviour
{
    private RaceType type;
    [SerializeField]
    private int lapNumber, numOfOpponents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
