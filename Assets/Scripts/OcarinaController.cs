using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcarinaController : MonoBehaviour
{

    // For a note to play, the user has to move the stick from the right or left hand.  
    private int[] sequenceOfNotes = { 0, 0, 0, 0, 0, 0 };
    private bool isLocked = false;

    public SunMelody sunMelody;
    public RightHand rightHand;
    public Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        sunMelody = FindObjectOfType(typeof(SunMelody)) as SunMelody;
        rightHand = FindObjectOfType(typeof(RightHand)) as RightHand;
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Always check to see if it is grabbed
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger)> 0.0)
            // If you press two buttons, then lock or unlock 
            if (OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Two))
                isLocked = !isLocked;

        // If locked, hold its position
        if (isLocked)
        {
            rigidbody.isKinematic = !(rigidbody.isKinematic);
            transform.position = rightHand.setPosition();

            if (OVRInput.GetUp(OVRInput.Button.Three))
                addNote(1);
            if (OVRInput.GetUp(OVRInput.Button.Four))
                addNote(2);
           if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstick))
                addNote(3);
            if (OVRInput.GetUp(OVRInput.Button.Start))
                addNote(4);
            if (OVRInput.GetUp(OVRInput.Button.One))
                addNote(5);
            if (OVRInput.GetUp(OVRInput.Button.Two))
                addNote(6);
            if (OVRInput.GetUp(OVRInput.Button.SecondaryThumbstick))
                addNote(7);
        }

        // Check melodies
        sunMelody.checkMelody(sequenceOfNotes);
    }


    void addNote(int note)
    {
        // Play sound of note attached to the number

        // Add the note to the sequence queue
        Debug.Log("Lost note : ");
        Debug.Log(sequenceOfNotes[0]);
        for (int i = 0; i < 5; i++)
            sequenceOfNotes[i] = sequenceOfNotes[i + 1];
        sequenceOfNotes[5] = note;
        Debug.Log("Added note: ");
        Debug.Log(note);
        
    }
}
