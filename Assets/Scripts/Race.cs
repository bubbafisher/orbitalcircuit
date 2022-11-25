using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Race : MonoBehaviour
{
    [Header("Race Settings")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int lapNum = 3;
    private int lapCounter;
    [SerializeField]
    private GameObject[] waypoints;
    [Header("UI")]
    [SerializeField]
    private TMP_Text lapGUI;
    [SerializeField]
    private TMP_Text timerGUI;
    public GameObject gameOverScreen;

    private float timeStart;
    private int waypointNum;
    private double[] times = new double[3];
    // Start is called before the first frame update
    void Start()
    {
        waypointNum = 0;
        lapCounter = 0;
        lapGUI.text = "Lap: " + (lapCounter + 1) + "/" + lapNum;
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timerGUI.text = System.Math.Round(Time.time - timeStart, 2).ToString();
        print(waypointNum);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Waypoint"))
        {
            if (other == waypoints[waypointNum].GetComponent<Collider>())
            {
                print("Waypoint " + waypointNum);
                waypointNum++;
            }

            if (waypointNum == waypoints.Length)
            {
                newLap();
            }
        }
    }

    void newLap()
    {
        print("New lap!");
        times[lapCounter] = Time.time - timeStart;
        if (++lapCounter >= lapNum)
        {
            raceOver();
        }
        else
        {
            timeStart = Time.time;
            waypointNum = 0;
            lapGUI.text = "Lap: " + (lapCounter + 1) + "/" + lapNum;
        }
    }

    void raceOver()
    {
        string timeStr = "";
            for (int i = 0; i < times.Length; i++)
            {
                timeStr += "Lap " + (i + 1) + ": " + System.Math.Round(times[i], 2) + "\n";
                //print(times);
            }
            gameOverScreen.SetActive(true);
    }
}
