using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class TestArabic : MonoBehaviour {


	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = ArabicFixer.Fix(gameObject.GetComponent<Text>().text);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
