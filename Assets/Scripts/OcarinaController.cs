using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcarinaController : MonoBehaviour {
	
	// For a note to play, the user has to move the stick from the right or left hand.  
	private int[6] sequenceOfNotes = {0, 0, 0, 0, 0, 0}; 
	public SunMelody sunMelody;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		sunMelody.checkMelody(sequenceOfNotes);	
	}
}
