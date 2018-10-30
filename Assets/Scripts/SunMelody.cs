using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMelody : MonoBehaviour {
	
	private int[] sunMelodyNotes = {5, 7, 1, 3, 1, 7};
    public bool isPlayed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayed == true)
        {
            // play melody
            
        }
		
	}

    public void checkMelody ( params int[] ocarinaSequence) {
        bool token = true;
        for (int i = 0; i<6; i++) {
            if (ocarinaSequence[i] != sunMelodyNotes[i]) {
                token = false;
                break;
            }
        }
        isPlayed = token;
    }   
}
