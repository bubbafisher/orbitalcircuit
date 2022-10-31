using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBGAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
