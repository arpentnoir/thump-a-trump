﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class BackToMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void backToMainMenu(){
		SceneManager.LoadScene (0);
	}
}
