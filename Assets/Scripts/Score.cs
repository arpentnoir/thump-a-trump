using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {


	public AudioClip babaw;
	public AudioSource audio;
	public static int globalScore = 0;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void resetScore(){
		globalScore = 0;
	}

	public static int getScore(){
		return globalScore;
	} 

	public static void updateScore(){
		globalScore += 1;
	}

	//public static void playSound(){
	//	audio.PlayOneShot(babaw, 0.7F);

	//}
}
