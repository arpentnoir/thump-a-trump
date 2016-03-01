using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int score = 0;
	private Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText = GetComponentInParent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString();
	}

	public void updateScore(){
		score += 1;
		Debug.Log ("Score: " + score);
	}
}
