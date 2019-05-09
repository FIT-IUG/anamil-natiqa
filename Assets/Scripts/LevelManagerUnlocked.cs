using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManagerUnlocked : MonoBehaviour {
	public int Level;
	public Image Image;
	private string LevelString;

	void Start () {
		if (ButtonSettings.releasedLevelStatic >= Level) {
			Levelunlocked ();
		} else {
			Levellocked ();
		}
	}


	public void LevelSelect(string _level)
	{
		LevelString = _level;
		SceneManager.LoadScene (LevelString);
	}

	

	void Levellocked()
	{
		GetComponent<Button> ().interactable = false;
		Image.enabled = true;
	}
	void Levelunlocked ()
	{
		GetComponent<Button> ().interactable = true;
		Image.enabled = false;
	}

}
