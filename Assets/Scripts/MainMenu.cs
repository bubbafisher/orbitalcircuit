using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public static void TutorialButton()
    {
        PlayerPrefs.SetInt("Ship", 0);
        SceneManager.LoadScene(3);
    }

    public static void CreditsButton()
    {

    }

    public static void ExitButton()
    {
        Application.Quit();
    }

    public static void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
