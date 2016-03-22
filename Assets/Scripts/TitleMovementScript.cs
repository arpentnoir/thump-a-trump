using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleMovementScript : MonoBehaviour {
	
	public float amplitude;
	public float frequency;
	public float time = 0;
	public float phase;
	public float movement;
	public float startposition;
	public bool active;
	public int level;

	
	// Use this for initialization
	void Start () {
		//audio = GetComponent<AudioSource> ();
		print(level);
		
	}
	
	void Update () {
		//Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
		//if (hit != null && hit.collider != null && active == true) {
		//	Application.LoadLevel(level);
		//	active = false;
		//}


		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (transform.GetComponent<CircleCollider2D> ().OverlapPoint (touchPos) && active) {

				if (level == -1) {
					Application.Quit();
				}
				SceneManager.LoadScene (level);
				active = false;

			}
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		movement = amplitude * Mathf.Cos (frequency * time + phase);
		//transform.Translate (new Vector2 (movement, 0));

		transform.position = new Vector3(transform.position.x, movement + startposition, 0);
		//print ("time = " + time + " platform-position = " + (transform.position.x + 9));
		time = time + 1;

		if (time > 100) active = true;
	}


	
}
