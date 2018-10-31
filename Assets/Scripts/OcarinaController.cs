using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcarinaController : MonoBehaviour
{

    // For a note to play, the user has to move the stick from the right or left hand.  
    private int[] sequenceOfNotes = { 5, 7, 1, 3, 1, 7 };
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
            lockGrabPosition();

        // If locked, hold its position
        if (isLocked)
        {
            rigidbody.isKinematic = !(rigidbody.isKinematic);
            transform.position = rightHand.setPosition();

        }

        // Check melodies
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0)
            sunMelody.checkMelody(sequenceOfNotes);
    }

    void lockGrabPosition ()
    {
        Debug.Log("Press X and Y");
        // If you press two buttons, then lock or unlock 
        if (OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Two))
            isLocked = !isLocked;

    }

    void addNote()
    {
        Vector2 position;
        position = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
    }
}
