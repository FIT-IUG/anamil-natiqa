using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;

public class Level1 : MonoBehaviour
{

    public Sprite[] cardFace;
    public Sprite cardBack;
    public List<GameObject> cards = new List<GameObject>();
    public Text matchText;
    public Canvas GameOver;
    public Canvas win;
    public Canvas _Canvas;
    private bool _init = false;
    private int _matches = 2;
    public GameObject scoreCanvas;
    public GameObject ScoreText;
    public int highScore = 10;
    public int  Score = 0;
    public int  Equation;
    public static Level1 Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(scoreCanvas);
        scoreCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
        //DontDestroyOnLoad(ScoreText);
    }

    public int _Clicks = 0; // to count number of clicks
  
  // Update is called once per frame
    void Update()
    {
        // panel.SetActive(false);
        if (!_init)
            initializaCard(); // card population
        
        if (Input.GetMouseButtonUp(0)) //each click in screen
            checkCards();

    }


    public List<T> Shuffle<T>(List<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
    }

    void initializaCard() // card population
    {
        cards = Shuffle(cards);

        for (int id = 0; id < 2; id++) // 2= match between 2 cards
        {
            GameOver.enabled = false;
            win.enabled = false;
        
            for (int i = 1; i < 3; i++) // 3= number of matches
            {
                cards[0].GetComponent<card>().cardValue = 1;
                cards[1].GetComponent<card>().cardValue = 2;
                cards[2].GetComponent<card>().cardValue = 3;
                cards[3].GetComponent<card>().cardValue = 4;
            }
        }


        foreach (GameObject C in cards)
            C.GetComponent<card>().setupGraphics();
        if (!_init)
            _init = true;
    }
    
    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {

        return cardFace[i - 1];
    }
    void checkCards()
    {

        List<int> c = new List<int>();
        //  Debug.Log(cards.Length);
        for (int i = 0; i < cards.Capacity; i++)
        {
            if (cards[i].GetComponent<card>().state == 1)
                c.Add(i);
        }
        if (c.Count == 2)
            cardComparison(c);
    }

    void cardComparison(List<int> c)
    {
        card.Do_NOT = true;
        int x = 0;
        _Clicks += 2;
        gameover();
        //gameover();
        if ((cards[c[0]].GetComponent<card>().cardValue == 1 && cards[c[1]].GetComponent<card>().cardValue == 2) ||
            (cards[c[0]].GetComponent<card>().cardValue == 3 && cards[c[1]].GetComponent<card>().cardValue == 4))
        {
            x = 2;

            _matches--;
            matchText.text = "Number of matches: " + _matches;
            if (_matches == 0)
            {
                //win.enabled = true;
                StartCoroutine(waitSec());
                ScoreOfGame();
            }
        }
        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<card>().state = x;
            cards[c[i]].GetComponent<card>().falseCheck();

        }
    }

    IEnumerator waitSec()
    {
        win.enabled = true;
        yield return new WaitForSeconds(3);
       // SceneManager.LoadScene("level2");
    }

    public void ScoreOfGame()
    {
        if (_Clicks > 0)
        {
            Equation = _Clicks / cards.Capacity;
            if (Equation == 1)
            {
                Score = highScore ; // score ...

            }
            else if (Equation == 2)
            {
                Score =  (highScore - 5);
            }
       
            PlayerPrefs.SetInt("Score", Score);
            ScoreText.GetComponent<Text>().text = "Score " + Score;
            
            //Debug.Log(PlayerPrefs.SetFloat("Score", 3f));
        }
    }

    public void gameover()
    {
        if (_Clicks > (cards.Capacity * 2) && _matches != 0 ) // gameover panel 
        {
            _Canvas.enabled = false;
            GameOver.enabled = true;
            Debug.Log("Game over");
        }
    }
}
