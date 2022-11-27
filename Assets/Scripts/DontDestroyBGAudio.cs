using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyBGAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
        
     
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("GameScene"))
        {
            Destroy(transform.gameObject);
        }
        if (SceneManager.GetActiveScene().name.Equals("GameScene2"))
        {
            Destroy(transform.gameObject);
        }
    }

}
