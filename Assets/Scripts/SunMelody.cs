using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMelody : MonoBehaviour {
	
	private int[] sunMelodyNotes = {5, 7, 1, 3, 1, 7};
    	private bool isPlayed = false;

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

    void checkMelody ( params int[] controllerSequence) {
        bool token = true;
        for (int i = 0; i<6; i++) {
            if (controllerSequence[i] != sunMelodyNotes[i]) {
                token = false;
                break;
            }
        }
        isPlayed = token;
    }   
}
