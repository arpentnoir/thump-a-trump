﻿using UnityEngine;
using System.Collections;

public class TitleMovementScript : MonoBehaviour {
	
	public float amplitude;
	public float frequency;
	public float time = 0;
	public float phase;
	public float movement;
	public float rotation;
	public float rotationSpeed;
	public float startposition;
	public float stopposition;
	public AudioClip hitSound;
	public AudioSource audio;
	public bool active;
	public int direction;
	public float speed;
	
	// Use this for initialization
	void Start () {
		//audio = GetComponent<AudioSource> ();
		
	}
	
	void Update () {
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
		if (hit != null && hit.collider != null && active == true) {
			Debug.Log ("I'm hitting "+hit.collider.name);
			Application.LoadLevel(1);
			active = false;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		movement = amplitude * Mathf.Cos (frequency * time + phase);
		//transform.Translate (new Vector2 (movement, 0));

		transform.position = new Vector3(transform.position.x, movement + startposition, 0);
		//print ("time = " + time + " platform-position = " + (transform.position.x + 9));
		time = time + 1;
	}


	
}