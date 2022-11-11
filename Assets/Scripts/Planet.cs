using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlanetType
{
    Planet, Star, Moon, BlackHole
}

public class Planet : MonoBehaviour
{
    private double mass;
    private float diameter, volume;
    public PlanetType type;
    private Transform tf;
    private bool pulling = false;
    private GameObject ship;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        //Set up Size
        tf = gameObject.transform;
        switch(type)
        {
            case PlanetType.Planet:
                diameter = 65;
                mass = 1.443e8;
                volume = 20;
                break;
            case PlanetType.Star:
                diameter = 200;
                mass = 1.072e9;
                volume = 20;
                break;
            case PlanetType.Moon:
                diameter = 20;
                mass = 2.5467e6;
                volume = 20;
                break;
            case PlanetType.BlackHole:
                diameter = 0;
                mass = 0;
                volume = 0;
                break;
        }
        //Set size of planet if not already set
        tf.localScale = new Vector3(diameter, diameter, diameter);

        //Set up gravity line
        line = this.gameObject.AddComponent<LineRenderer>();
        line.positionCount = 2;
        line.startWidth = 0;
        line.endWidth = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if object is ship
        if(other.CompareTag("Player"))
        {
            ship = other.gameObject;
            pulling = true;
            print("Gravity!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Check to see if object is ship
        if (other.gameObject == ship)
        {
            ship = null;
            pulling = false;
            print("No gravity.");

            line.startWidth = 0;
            line.endWidth = 0;
        }
    }
    public Vector3 pull()
    {
        //Calculate gravity
        float pull = calculateGravity();
        //Calculate heading of distance
        Vector3 heading = this.gameObject.transform.position - ship.transform.position;
        //Calculate pull vector
        return pull * (heading/heading.magnitude);
    }

    private float calculateGravity()
    {
        //Get variables for gravity formula
        const float G = (float)6.67e-6; //G
        float m1 = ship.GetComponent<Rigidbody>().mass; //Ship
        float m2 = (float)mass; //Planetary body
        float r = Vector3.Distance(this.gameObject.transform.position, ship.transform.position); //Distance
        r *= r; //r^2
        //Plug everything in
        print("F =" + G + "(" + m1 + " * " + m2 + ") / " + r+"\nF = " + (G * m1 * m2 / r));
        return G * m1 * m2 / r;
    }

    private void drawLine()
    {
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
        line.SetPosition(0, ship.transform.position);
        line.SetPosition(1, this.gameObject.transform.position);
    }

    private void FixedUpdate()
    {
        if (pulling)
        {
            ship.GetComponent<Rigidbody>().AddForce(pull(), ForceMode.Impulse); //Pull on ship
            drawLine();
        }
    }
}
