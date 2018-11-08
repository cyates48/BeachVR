using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMelody : MonoBehaviour {

    private int[] sunMelodyNotes = { 5, 7, 1, 3, 1, 7 };
    bool isPlayed = false;
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
        if (!isPlayed && temp>1.9f)
            sunMelody.Play();
        if (isPlayed && temp < 90.001) {
            temp += 0.05f;
            transform.localRotation = Quaternion.Euler(temp, 3, 0);
        }
    }

    public float checkMelody (params int[] ocarinaSequence) {
        bool token = true;
        for (int i = 0; i<6; i++) {
            if (ocarinaSequence[i] != sunMelodyNotes[i]) {
                token = false;
                break;
            }
        }
        isPlayed = token;
        return temp;
    }  
}
