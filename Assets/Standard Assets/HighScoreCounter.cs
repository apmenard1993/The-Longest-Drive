using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreCounter : MonoBehaviour {
	public static int score = 0;
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		score = PlayerPrefs.GetInt("highscore", 0);
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "High Score: " + score;
	}
}
