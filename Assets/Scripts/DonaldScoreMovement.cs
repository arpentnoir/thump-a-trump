using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class DonaldScoreMovement : MonoBehaviour {

		public float target;
		public float speed;
		public AudioClip babaw;
		public AudioSource audio;
	public Score score;

	private bool gameOver = false;
		
		// Use this for initialization
		void Start () {
		score = GameObject.FindGameObjectWithTag("PersistentGameObject").GetComponent<Score>();

		}

		void Update () {
			MoveTowardsTarget ();
			
		if(transform.position.x > 4.0f && gameOver == false){
			gameOver = true;
			endGame();
		}

		}

	public void endGame(){

		//score.audio.PlayOneShot(score.babaw, 0.7F);
		SceneManager.LoadScene (3);
	}

		public void MoveTowardsTarget() {
			//the speed, in units per second, we want to move towards the target

			//move towards the center of the world (or where ever you like)
			Vector3 targetPosition = new Vector3(target, transform.position.y, transform.position.z);

			Vector3 currentPosition = this.transform.position;
			//first, check to see if we're close enough to the target
			if (Vector3.Distance (currentPosition, targetPosition) > .05f) { 
				Vector3 directionOfTravel = targetPosition - currentPosition;
				//now normalize the direction, since we only want the direction information
				directionOfTravel.Normalize ();
				//scale the movement on each axis by the directionOfTravel vector components

				this.transform.Translate (
					(directionOfTravel.x * speed * Time.deltaTime),
					(directionOfTravel.y * speed * Time.deltaTime),
					(directionOfTravel.z * speed * Time.deltaTime),
					Space.World);
			} else {

			}
		}
		


	}
