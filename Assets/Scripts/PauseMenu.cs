using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void resume()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
    public void quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
