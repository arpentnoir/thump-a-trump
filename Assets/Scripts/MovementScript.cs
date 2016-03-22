using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour {

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
	public float speedLevel1;
	public float speedLevel2;
	public float speedLevel3;
	public float speedLevel4;
	public float speedLevel5;
	public float speedLevel6;

	public ScoreManager scoreManager;
	public DonaldScoreMovement donaldIndicator;
	public SoundManager soundManager;

	// Use this for initialization
	void Start () {
		//audio = GetComponent<AudioSource> ();
		soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
		scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
		donaldIndicator = GameObject.FindGameObjectWithTag ("DonaldScore").GetComponent<DonaldScoreMovement>();

		Debug.Log (scoreManager);
	
	}
	
	void Update () {
		// old hit detector...
		/*Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
		if (hit != null && hit.collider == transform.GetComponent<CircleCollider2D>() && active == true) {
			Debug.Log ("I'm hitting "+hit.collider.name);
			audio.PlayOneShot(hitSound, 0.7F);
			transform.position = new Vector3(transform.position.x, startposition, transform.position.z);
			active = false;
			scoreManager.updateScore ();
		}*/

		/*if (Score.globalScore < 5) {
			speed *= 1.2f;
		} else if (Score.globalScore < 10) {
			speed *= 1.2f;
		} else if (Score.globalScore < 20){
			speed *= 1.2f;
		} else if (Score.globalScore < 30){
			speed *= 1.2f;
		} else if (Score.globalScore < 40){
			speed *= 1.2f;
		} else if (Score.globalScore < 50){
			speed *= 1.2f;
		}*/

		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (transform.GetComponent<CircleCollider2D> ().OverlapPoint (touchPos) && active) {
				soundManager.play ();
				//audio.PlayOneShot(hitSound, 0.7F);
				transform.position = new Vector3(transform.position.x, startposition, transform.position.z);
				active = false;
				scoreManager.updateScore ();
			}
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
			//movement = amplitude * Mathf.Cos (frequency * time + phase);
			//transform.Translate (new Vector2 (movement, 0));

		if (direction == 1) {
			//MoveTowardsTarget ();
		} else {
			//MoveTowardsStartPosition();
		}
		//transform.position = new Vector3(transform.position.x, movement + startposition, 0);
			//print ("time = " + time + " platform-position = " + (transform.position.x + 9));
			time = time + 1;
	}

	public float getSpeed(){
		if (Score.globalScore < 5) {
			return speedLevel1;
		} else if (Score.globalScore < 10) {
			return speedLevel2;
		} else if (Score.globalScore < 20) {
			return speedLevel3;
		} else if (Score.globalScore < 30) {
			return speedLevel4;
		} else if (Score.globalScore < 40) {
			return speedLevel5;
		} else if (Score.globalScore < 50) {
			return speedLevel6;
		} else {
			return speedLevel6;
		}
	}

	public void MoveTowardsTarget() {
		//the speed, in units per second, we want to move towards the target

		//move towards the center of the world (or where ever you like)
		Vector3 targetPosition = new Vector3(transform.position.x, stopposition, transform.position.z);
		
		Vector3 currentPosition = this.transform.position;
		//first, check to see if we're close enough to the target
		if (Vector3.Distance (currentPosition, targetPosition) > .05f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			//now normalize the direction, since we only want the direction information
			directionOfTravel.Normalize ();
			//scale the movement on each axis by the directionOfTravel vector components
			
			this.transform.Translate (
			(directionOfTravel.x * getSpeed() * Time.deltaTime),
			(directionOfTravel.y * getSpeed() * Time.deltaTime),
			(directionOfTravel.z * getSpeed() * Time.deltaTime),
				Space.World);
		} else {
			direction = -1;
		}
	}

	public void MoveTowardsStartPosition() {
		//the speed, in units per second, we want to move towards the target

		//move towards the center of the world (or where ever you like)
		Vector3 targetPosition = new Vector3(transform.position.x, startposition, transform.position.z);
		
		Vector3 currentPosition = this.transform.position;
		//first, check to see if we're close enough to the target
		if (Vector3.Distance (currentPosition, targetPosition) > .05f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			//now normalize the direction, since we only want the direction information
			directionOfTravel.Normalize ();
			//scale the movement on each axis by the directionOfTravel vector components
			
			this.transform.Translate (
			(directionOfTravel.x * getSpeed() * Time.deltaTime),
			(directionOfTravel.y * getSpeed() * Time.deltaTime),
			(directionOfTravel.z * getSpeed() * Time.deltaTime),
				Space.World);
		} else {
			if (active) {
				donaldIndicator.target = donaldIndicator.target + 0.5f;
			}
			direction = 1;
			active = false;
			// donaldIndicator.position = new Vector2(donaldIndicator.position.x + 0.001f, donaldIndicator.position.y);
		}
	}



}
