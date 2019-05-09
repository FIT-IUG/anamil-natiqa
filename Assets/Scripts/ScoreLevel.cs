using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ScoreLevel : MonoBehaviour {

    public int highScore = 10;
    public int Score = 0;
    public int Equation;
    public GameObject[] cards;
    public int _Clicks = 0;
    public Text ScoreText;
    public Canvas GameOver;
    public Canvas _Canvas;

    public void ScoreOfGame()
    {
        if (_Clicks > 0)
        {
            Equation = _Clicks / cards.Length;
            if (Equation == 1)
            {
                Score = highScore; // score ...

            }
            else if (Equation == 1.5)
            {
                Score = highScore - 2;

            }
            else if (Equation == 2)
            {
                Score = highScore - 4;

            }
            else if (Equation == 3)
            {
                Score = highScore - 6;

            }
            else
            {
                gameover();
            }
            PlayerPrefs.SetInt("Score", Score);
            DontDestroyOnLoad(ScoreText);
            Debug.Log(PlayerPrefs.GetInt("Score"));
        }
            
    }

    public void gameover()
    {
        if (_Clicks > (cards.Length * 2)) // gameover panel 
        {
            _Canvas.enabled = false;
            GameOver.enabled = true;
            Debug.Log("Game over");
        }
    }
}
