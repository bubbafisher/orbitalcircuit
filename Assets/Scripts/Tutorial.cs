using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    [TextArea(1,3)]
    private string hint;
    [SerializeField]
    private bool pauseDuringHint = true, lastHint = false;
    [SerializeField]
    private TMP_Text tutorialText;
    [SerializeField]
    private GameObject continueButton;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            tutorialText.text = hint;
            if(pauseDuringHint)
            {
                Time.timeScale = 0;
                continueButton.SetActive(true);
            }
            if (lastHint)
                tutorialText.enabled = false;
            Destroy(this.gameObject);
        }
    }
    public static void Continue()
    {
        Time.timeScale = 1;
    }
}
