using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcarinaController : MonoBehaviour {

    // For a note to play, the user has to move the stick from the right or left hand.  
    private int[] sequenceOfNotes = { 0, 0, 0, 0, 0, 0 };
    private bool isLocked = false;

    public SunMelody sunMelody;
    public RightHand rightHand;
    public Rigidbody rigidbody;
    public AudioSource cNote, dNote, eNote, fNote, gNote, aNote, bNote;

    private GameObject A, B, C, D, E, F, G;
    private GameObject rightHandAnchor;

    // Use this for initialization
    void Start() {
        sunMelody = FindObjectOfType(typeof(SunMelody)) as SunMelody;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rightHandAnchor = GameObject.Find("RightHandAnchor");

        A = GameObject.Find("A");
        B = GameObject.Find("B");
        C = GameObject.Find("C");
        D = GameObject.Find("D");
        E = GameObject.Find("E");
        F = GameObject.Find("F");
        G = GameObject.Find("G");

        aNote = A.GetComponent<AudioSource>();
        bNote = B.GetComponent<AudioSource>();
        cNote = C.GetComponent<AudioSource>();
        dNote = D.GetComponent<AudioSource>();
        eNote = E.GetComponent<AudioSource>();
        fNote = F.GetComponent<AudioSource>();
        gNote = G.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update() {

        // Always check to see if it is grabbed
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger)> 0.0)
            // If you press two buttons, then lock or unlock 
            if (OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Two))
                isLocked = !isLocked;

        // If locked, hold its position
        if (isLocked) {
            rigidbody.isKinematic = !(rigidbody.isKinematic);
            transform.position = rightHandAnchor.transform.position;

            if (OVRInput.GetUp(OVRInput.Button.Three)) {
                addNote(1);
                cNote.Play();
            }
            if (OVRInput.GetUp(OVRInput.Button.Four)) {
                addNote(2);
                dNote.Play();
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstick)) {
                addNote(3);
                eNote.Play();
            }
            if (OVRInput.GetUp(OVRInput.Button.Start)) {
                addNote(4);
                fNote.Play();
            }
            if (OVRInput.GetUp(OVRInput.Button.One)) {
                addNote(5);
                gNote.Play();
            }
            if (OVRInput.GetUp(OVRInput.Button.Two)) {
                addNote(6);
                aNote.Play();
            }
            if (OVRInput.GetUp(OVRInput.Button.SecondaryThumbstick)) {
                addNote(7);
                bNote.Play();
            }
        }

        // Check melodies
        sunMelody.checkMelody(sequenceOfNotes);
    }


    void addNote(int note) {
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
