using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            LoadNextLevel();
        }



    }
public void LoadNextLevel(){
    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
}
public void LoadGameScene1(){
    SceneManager.LoadScene("GameScene");
}
IEnumerator LoadLevel (int levelIndex){
    transition.SetTrigger("Start");
    yield return new WaitForSeconds(transitionTime);
    SceneManager.LoadScene(levelIndex);
}

}
