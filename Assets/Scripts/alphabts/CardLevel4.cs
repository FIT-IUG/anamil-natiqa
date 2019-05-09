using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class CardLevel4 : MonoBehaviour
{

    public static bool Do_NOT = false;
    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    void Start()
    {
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<Level4>().getCardBack();
        _cardFace = _manager.GetComponent<Level4>().getCardFace(_cardValue);
        flipCard();
    }

    public void flipCard()
    {
        if (_state == 0)
            _state = 1;
        else if (state == 1)
            _state = 0;
        if (_state == 0 && !Do_NOT)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1 && !Do_NOT)
            GetComponent<Image>().sprite = _cardFace;
    }

    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }

    }
    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }
    public void falseCheck()
    {
        StartCoroutine(pause());
    }

    IEnumerator pause() // return back face if the check of cards is false
    {
        yield return new WaitForSeconds(1);
        // yield return new WaitForSeconds(1);
        if (_state == 0)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1)
            GetComponent<Image>().sprite = _cardFace;
        Do_NOT = false;
    }
}
