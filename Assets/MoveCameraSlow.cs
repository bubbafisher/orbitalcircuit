using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraSlow : MonoBehaviour
{
    
float rotateCameraX = 0.001f;
float rotateCameraY = -0.005f;
float rotateCameraZ = 0.0f;
    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.Rotate(rotateCameraX, rotateCameraY, rotateCameraZ);
        
    }
}
