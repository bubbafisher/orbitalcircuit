using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipType
{
    Sparrow, Vester, Crusader, Neo, Algo, Invader
}

public class ShipStats : MonoBehaviour
{
    private int speed, handling, weight;

    public static ShipStats[] ships =
    { 
        new ShipStats(25, 40, 1000), //Sparrow
        new ShipStats(50, 40, 1000), //Vester
        new ShipStats(50, 40, 1000), //Crusader
        new ShipStats(50, 40, 1000), //Neo
        new ShipStats(50, 40, 1000), //Algo
        new ShipStats(50, 40, 1000) //Invader
    };
 
    public ShipStats(int s, int h, int w)
    {

        speed = s;
        handling = h;
        weight = w;
    }

    public int getSpeed()
    {
        return speed;
    }    
    public int getHandling()
    {
        return handling;
    }
    public int getWeight()
    {
        return weight;
    }
}
