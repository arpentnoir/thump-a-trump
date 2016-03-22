using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	public int score;
	private Text scoreText;
	public AudioSource audio;
	public AudioClip babaw;

	// Use this for initialization
	void Start () {
		audio.PlayOneShot (babaw, 0.7f);
		Score persistentScript = GameObject.FindGameObjectWithTag("PersistentGameObject").GetComponent<Score>();
		score = Score.globalScore;
		scoreText = GetComponentInParent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString();
	}
}