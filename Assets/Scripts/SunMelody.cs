using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMelody : MonoBehaviour {

    private int[] sunMelodyNotes = { 5, 7, 1, 3, 1, 7 };
    bool isPlayed = false;
    int toggle = 0;
    float temp = 2.0f;

    public AudioSource[] sunSounds;
    public AudioSource intro, sunMelody;

    // Use this for initialization
    void Start () {
        transform.localRotation = Quaternion.Euler(2, 3, 0);
        sunSounds = GetComponents<AudioSource>();
        intro = sunSounds[0];
        sunMelody = sunSounds[1];
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayed && temp < 90.001) {
            temp += 0.05f;
            transform.localRotation = Quaternion.Euler(temp, 3, 0);
        }
        //if (isPlayed && toggle == 1) {
           // intro.Play();
          //  toggle = 2;
       // }
      //  if (isPlayed && toggle == 2) {
        //    sunMelody.Play();
       //     toggle = 0;
       // }
    }

    public void checkMelody (params int[] ocarinaSequence) {
        bool boolToken = true;
        //int intToken = 1;
        for (int i = 0; i<6; i++) {
            if (ocarinaSequence[i] != sunMelodyNotes[i]) {
                boolToken = false;
                //intToken = 0;
                break;
            }
        }
        isPlayed = boolToken;
        //toggle = intToken;
    }  
}
