using UnityEngine;
using UnityEngine . UI;
using UnityEngine . SceneManagement;
using System . Collections;
using System . Collections . Generic;
using System . Security . Cryptography;
using System;

public class Level4 : MonoBehaviour
{

    public Sprite[] cardFace;

    public Sprite cardBack;
    public List<GameObject> cards = new List<GameObject>();


    public Text matchText;
    public Canvas GameOver;
    public Canvas win;
    public Canvas _Canvas;

    private bool _init = false;
    private int _matches = 5;
    public Text ScoreText;
    public int Score = 0;

    public int _Clicks = 0;
    public int Equation;
    public int highScore = 10;
    public int Scorelevel3;

    public static Level4 Instance;

    void Awake ( )
    {
        Instance = this;
    }
    void Start ( )
    {
        GameObject ScoreBoard;
        ScoreBoard = GameObject . Find ( "ScoreBoard" );
        ScoreBoard . SetActive ( false );
        ScoreBoard . SetActive ( true );
        matchText = ScoreBoard . transform . Find ( "Panel" ) . Find ( "Matches" ) . gameObject . GetComponent<Text> ( );
        ScoreText = ScoreBoard . transform . Find ( "Panel" ) . Find ( "Score" ) . gameObject . GetComponent<Text> ( );

        ScoreText . text = "Score " + PlayerPrefs . GetInt ( "Score" );
    }


    // Update is called once per frame
    void Update ( )
    {
        // Scorelevel3 = level3 . Instance . Score;
        //ScoreText . text = "Score " + Scorelevel3;
        if ( !_init )
            initializaCard ( );

        if ( Input . GetMouseButtonUp ( 0 ) )

            checkCards ( );

    }

    public List<T> Shuffle<T> ( List<T> list )
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while ( n > 1 )
        {
            byte[] box = new byte[1];
            do provider . GetBytes ( box );
            while ( !( box [ 0 ] < n * ( Byte . MaxValue / n ) ) );
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list [ k ] = list [ n ];
            list [ n ] = value;
        }

        return list;
    }

    void initializaCard ( )
    {
        cards = Shuffle ( cards );

        for ( int id = 0 ; id < 2 ; id++ )
        {
            GameOver . enabled = false;
            win . enabled = false;

            for ( int i = 1 ; i < 6 ; i++ )
            {
                cards [ 0 ] . GetComponent<CardLevel4> ( ) . cardValue = 1;
                cards [ 1 ] . GetComponent<CardLevel4> ( ) . cardValue = 2;
                cards [ 2 ] . GetComponent<CardLevel4> ( ) . cardValue = 3;
                cards [ 3 ] . GetComponent<CardLevel4> ( ) . cardValue = 4;
                cards [ 4 ] . GetComponent<CardLevel4> ( ) . cardValue = 5;
                cards [ 5 ] . GetComponent<CardLevel4> ( ) . cardValue = 6;
                cards [ 6 ] . GetComponent<CardLevel4> ( ) . cardValue = 7;
                cards [ 7 ] . GetComponent<CardLevel4> ( ) . cardValue = 8;
                cards [ 8 ] . GetComponent<CardLevel4> ( ) . cardValue = 9;
                cards [ 9 ] . GetComponent<CardLevel4> ( ) . cardValue = 10;
            }
        }
        foreach ( GameObject C in cards )
            C . GetComponent<CardLevel4> ( ) . setupGraphics ( );
        if ( !_init )
            _init = true;
    }

    public Sprite getCardBack ( )
    {
        return cardBack;
    }

    public Sprite getCardFace ( int i )
    {

        return cardFace [ i - 1 ];
    }
    void checkCards ( )
    {

        List<int> c = new List<int>();
        //  Debug.Log(cards.Length);
        for ( int i = 0 ; i < cards . Capacity ; i++ )
        {
            if ( cards [ i ] . GetComponent<CardLevel4> ( ) . state == 1 )
                c . Add ( i );
        }
        if ( c . Count == 2 )
            cardComparison ( c );
    }

    void cardComparison ( List<int> c )
    {
        card . Do_NOT = true;
        int x = 0;
        _Clicks += 2;
        gameover ( );
        if ( ( cards [ c [ 0 ] ] . GetComponent<CardLevel4> ( ) . cardValue == 1 && cards [ c [ 1 ] ] . GetComponent<CardLevel4> ( ) . cardValue == 2 ) ||
            ( cards [ c [ 0 ] ] . GetComponent<CardLevel4> ( ) . cardValue == 3 && cards [ c [ 1 ] ] . GetComponent<CardLevel4> ( ) . cardValue == 4 ) ||
             ( cards [ c [ 0 ] ] . GetComponent<CardLevel4> ( ) . cardValue == 5 && cards [ c [ 1 ] ] . GetComponent<CardLevel4> ( ) . cardValue == 6 ) ||
             ( cards [ c [ 0 ] ] . GetComponent<CardLevel4> ( ) . cardValue == 7 && cards [ c [ 1 ] ] . GetComponent<CardLevel4> ( ) . cardValue == 8 ) ||
             ( cards [ c [ 0 ] ] . GetComponent<CardLevel4> ( ) . cardValue == 9 && cards [ c [ 1 ] ] . GetComponent<CardLevel4> ( ) . cardValue == 10 ) )
        {
            x = 2;

            _matches--;
            matchText . text = "Number of matches: " + _matches;
            if ( _matches == 0 )
            {
                StartCoroutine ( waitSec ( ) );
                ScoreOfGame ( );
            }
               
        }
        for ( int i = 0 ; i < c . Count ; i++ )
        {
            cards [ c [ i ] ] . GetComponent<CardLevel4> ( ) . state = x;
            cards [ c [ i ] ] . GetComponent<CardLevel4> ( ) . falseCheck ( );

        }
    }


    IEnumerator waitSec ( )
    {
        win . enabled = true;
        yield return new WaitForSeconds ( 3 );
        //SceneManager.LoadScene("level3");
    }

    public void ScoreOfGame ( )
    {
        if ( _Clicks > 0 )
        {
            Equation = _Clicks / cards . Capacity;
            //Scorelevel3 = level3 . Instance . Score;
            Scorelevel3 = PlayerPrefs . GetInt ( "Score" );

            Score = Scorelevel3;
            if ( Equation == 1 )
            {
                Score = highScore + Scorelevel3; // score ...

            }
            else if ( Equation == 2 )
            {
                Score = Scorelevel3 + ( highScore - 5 );
            }
            PlayerPrefs . SetInt ( "Score" , Score );
            //DontDestroyOnLoad ( ScoreText );
            ScoreText . text = "Score " + Score;

            Debug . Log ( PlayerPrefs . GetInt ( "Score" ) );
        }
    }

    public void gameover ( )
    {
        if ( _Clicks > ( cards . Capacity * 2 ) && _matches != 0 ) // gameover panel 
        {
            _Canvas . enabled = false;
            win . enabled = false;
            GameOver . enabled = true;
            Debug . Log ( "Game over" );
        }
    }
}
