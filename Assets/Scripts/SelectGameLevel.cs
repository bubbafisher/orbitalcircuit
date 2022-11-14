using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGameLevel : MonoBehaviour
{
   public void Level1(){

    SceneManager.LoadScene("GameScene");
   }
    public void ShipSelect(){

    SceneManager.LoadScene("Ship Selection");
   }
    public void LevelSelect(){

    SceneManager.LoadScene("LevelSelection");
   }
   
   //public void Level2(){
    //SceneManager.LoadScene()
   // void
   //}
}
