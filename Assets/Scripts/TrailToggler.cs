using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailToggler : MonoBehaviour
{
    public GameObject trailL;
    public GameObject trailR;
    public Material f;
    public Material r;

    // Start is called before the first frame update
    void Start()
    {
        trailL.SetActive(false);
        trailR.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //thrusters appear when one of the following held: W, S, UpArrow, DownArrow
        if (Input.GetKey(KeyCode.W))
        {
            trailL.SetActive(true);
            trailR.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            trailL.SetActive(true);
            trailR.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            trailL.SetActive(true);
            trailR.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            trailL.SetActive(true);
            trailR.SetActive(true);
        }
        else
        {
            trailL.SetActive(false);
            trailR.SetActive(false);
        }
        
    }
}
