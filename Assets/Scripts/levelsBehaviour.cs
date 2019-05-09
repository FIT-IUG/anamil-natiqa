using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class levelsBehaviour : MonoBehaviour {

    public void triggerMenuBehaviour(int i)
    {
        switch (i)
        {
            default:
            case (1):
                SceneManager.LoadScene("level1");
                break;
            case (2):
                SceneManager.LoadScene("level2");
                break;
            case (3):
                SceneManager.LoadScene("level3");
                break;
            case (4):
                SceneManager.LoadScene("level4");
                break;
            case (5):
                SceneManager.LoadScene("level5");
                break;
            case (6):
                SceneManager.LoadScene("level6");
                break;
            case (7):
                SceneManager.LoadScene("stages");
                break;
            case (8):
                break;
        }
    }

    public void animalsMenuBehaviour ( int i )
    {
        switch ( i )
        {
            default:
            case ( 1 ):
                SceneManager . LoadScene ( "pets" );
                break;
            case ( 2 ):
                SceneManager . LoadScene ( "Predators" );
                break;
           
        }
    }

    public void numbersMenuBehaviour(int i)
    {
        switch (i)
        {
            default:
            case (1):
                SceneManager.LoadScene("numberLevel");
                break;
          
        }
    }

    


}
