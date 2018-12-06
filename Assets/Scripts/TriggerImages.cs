using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerImages : MonoBehaviour {

    private Image image1, image2, image3, image4, image5, image6, image7;

    // Use this for initialization
    void Start () {
        GameObject obj1= GameObject.Find("SunMelodyImage");
        GameObject obj2 = GameObject.Find("LegendImage");
        GameObject obj3 = GameObject.Find("StartImage");
        GameObject obj4 = GameObject.Find("PickUpImage");
        GameObject obj5 = GameObject.Find("LockImage");
        GameObject obj6 = GameObject.Find("UnlockImage");
        GameObject obj7 = GameObject.Find("PlayNotesImage");

        image1 = obj1.GetComponent<Image>();
        image2 = obj2.GetComponent<Image>();
        image3 = obj3.GetComponent<Image>();
        image4 = obj4.GetComponent<Image>();
        image5 = obj5.GetComponent<Image>();
        image6 = obj6.GetComponent<Image>();
        image7 = obj7.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.0) {
            image1.enabled = true;
            image2.enabled = true;
            image3.enabled = true;
            image4.enabled = true;
            image5.enabled = true;
            image6.enabled = true;
            image7.enabled = true;
        }
        else
        {
            image1.enabled = false;
            image2.enabled = false;
            image3.enabled = false;
            image4.enabled = false;
            image5.enabled = false;
            image6.enabled = false;
            image7.enabled = false;
        }
    }
}
