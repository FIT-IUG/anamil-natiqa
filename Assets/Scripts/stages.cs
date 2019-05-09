using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class stages : MonoBehaviour {

    public void triggerMenuBehaviour(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("alphabetsLevels");
                break;
            case (1):
                  SceneManager . LoadScene ( "numberlvl" );
                  break;
            case ( 2 ):
                SceneManager . LoadScene ( "animalsLevels" );
                break;


        }
    }
}
