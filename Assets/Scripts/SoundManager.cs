using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public AudioClip hit1;
	public AudioClip hit2;
	public AudioClip hit3;
	public AudioClip hit4;
	public AudioClip hit5;
	public AudioClip hit6;
	public AudioClip hit7;
	public AudioClip hit8;
	public AudioClip hit9;
	public AudioClip hit10;
	public AudioClip hit11;

	public AudioSource audio;

	public List<AudioClip> list1;
	public List<AudioClip> list2;

	// Use this for initialization
	void Start () {

		list1 = new List<AudioClip> () {

			hit1,
			hit2,
			hit3,
			hit4,
			hit5,
			hit6,
			hit7,
			hit8,
			hit9,
			hit10,
			hit11
		};

		list2 = new List<AudioClip> ();
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(){
		audio.PlayOneShot (randomClip (), 0.7f);
	}
		

	public AudioClip randomClip(){
		int n = Random.Range (0, list1.Count - 1);
		AudioClip clip = list1 [n];
		list2.Add(clip);
		list1.Remove(clip);

		if (list1.Count == 0) {
			list1 = list2;
			list2 = new List<AudioClip> ();
		}
		return clip;

	}
}
