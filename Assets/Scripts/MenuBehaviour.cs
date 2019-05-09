using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//using UnityEditor;

public class MenuBehaviour : MonoBehaviour
{
    
    public void triggerMenuBehaviour(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("stages");
                break;
            case (1):
                {
                    /*Debug.Log("has quited");*/
                 //   Application.Quit();
                    SceneManager.LoadScene("menu_manager");
                    break;
                }
            case (2):
                {
                    
                    SceneManager.LoadScene("alphabetsLevels");
                    break;
                }
            case (3):
                {
                    /*Debug.Log("has quited");*/
               //      Application.Quit();
                    SceneManager . LoadScene ( "numberlvl" );
                    break;
                }

            case ( 4 ):
                {
                    /*Debug.Log("has quited");*/
                 //   Application . Quit ( );
                    SceneManager.LoadScene( "animalsLevels" );
                    break;
                }
            case ( 5 ):
                {
                    /*Debug.Log("has quited");*/
                    Application . Quit ( );
                    break;
                }

        }
    }
   /* public void nextButton()
    {
        SceneManager.LoadScene("alphabetsLevels");
    }*/
}
