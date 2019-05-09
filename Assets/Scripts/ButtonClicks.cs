using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonClicks : MonoBehaviour {

   
    // game over button (re-play)
    public void restartCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void MainMenu()
    {
       
        SceneManager.LoadScene("menu_manager");
    }

}
