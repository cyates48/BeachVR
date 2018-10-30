using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcarinaController : MonoBehaviour
{

    // For a note to play, the user has to move the stick from the right or left hand.  
    private int[] sequenceOfNotes = { 0, 0, 0, 0, 0, 0 };
    private bool isHeld = false;
    public SunMelody sunMelody;


    // Use this for initialization
    void Start()
    {
        sunMelody = FindObjectOfType(typeof(SunMelody)) as SunMelody;
    }

    // Update is called once per frame
    void Update()
    {
        // always check to see if it is grabbed
        if (OVRGrabbable.isGrabbed())
            lockGrabPosition();

        // check melodies
        sunMelody.checkMelody(sequenceOfNotes);
    }

    void lockGrabPosition ()
    {
        // if you press two buttons, then lock or unlock 
        if (OVRInput.Get() && OVRInput.Get())
            isHeld = !isHeld;

        // if locked, hold its position
        if (isHeld)
            return;

    }
}
