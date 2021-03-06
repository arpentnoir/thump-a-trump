﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	


	public int score;
	private Text scoreText;
	// Use this for initialization
	void Start () {
		Score.resetScore ();
		Score persistentScript = GameObject.FindGameObjectWithTag("PersistentGameObject").GetComponent<Score>();
		scoreText = GetComponentInParent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = Score.globalScore.ToString();
	}

	public void updateScore(){
		Score.updateScore();
		Debug.Log ("Score: " + score);
	}
}
