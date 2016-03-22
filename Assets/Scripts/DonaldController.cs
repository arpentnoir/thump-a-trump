using UnityEngine;
using System.Collections;

public class DonaldController : MonoBehaviour {

	public GameObject donald;
	public MovementScript donaldScript;

	public GameObject[] donalds;
	public MovementScript[] donaldScripts; 

	public ScoreManager scoreObject;
	public float frequency;


	float time;

	// Use this for initialization
	void Start () {
		donalds = GameObject.FindGameObjectsWithTag("GameController");
		donaldScripts = new MovementScript [donalds.Length];
		scoreObject = GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreManager> ();
		frequency = 20 - scoreObject.score;
		time = 0;

		for(int i = 0; i < donalds.Length; i++){
			donaldScripts[i] = donalds[i].GetComponent<MovementScript>();;
		} 
			
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Score.globalScore < 5) {
			frequency = 10;
		} else if (Score.globalScore < 10) {
			frequency = 8;
		} else if (Score.globalScore < 20){
			frequency = 6;
		} else if (Score.globalScore < 30){
			frequency = 4;
		} else if (Score.globalScore < 40){
			frequency = 3;
		} else if (Score.globalScore < 50){
			frequency = 2;
		}

		if (time % frequency <= 0.1) {

			donaldScripts[Random.Range(0, donaldScripts.Length)].active = true;
		}

		for (int i = 0; i < donaldScripts.Length; i++) {
			if (donaldScripts[i].direction == 1 && donaldScripts[i].active) {
				donaldScripts[i].MoveTowardsTarget ();
			} else {
				donaldScripts[i].MoveTowardsStartPosition ();
			}
		}
		time += 0.1f;
	}
}
