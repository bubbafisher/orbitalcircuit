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
        new ShipStats(20, 33, 1100), //Vester
        new ShipStats(27, 42, 850), //Crusader
        new ShipStats(22, 45, 950), //Neo
        new ShipStats(28, 35, 1000), //Algo
        new ShipStats(30, 30, 1250) //Invader
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
