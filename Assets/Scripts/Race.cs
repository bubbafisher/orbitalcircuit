using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    private GameObject[] waypoints, respawnPoints;
    [SerializeField]
    private Material waypointMaterial, targetWaypointMaterial;
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            GameObject w = respawnPoints[0];
            for(int i = 0; i < waypointNum; i++)
            {
                foreach(GameObject r in respawnPoints)
                {
                    if (waypoints[i] == r)
                        w = r;
                }
            }
            StartCoroutine(respawn(w));
        }
    }

    IEnumerator respawn(GameObject w)
    {
        player.GetComponent<PlayerInput>().enabled = false;
        player.transform.position = w.transform.position;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        yield return new WaitForSeconds(1);
        player.GetComponent<PlayerInput>().enabled = true;
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
