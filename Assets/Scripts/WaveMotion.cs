using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMotion : MonoBehaviour {

    private GameObject water;

	// Use this for initialization
	void Start () {
        water = GameObject.Find("Water");
    }
	
	// Update is called once per frame
	void Update () {
        water.transform.Rotate(0, Time.deltaTime * 0.5f, 0);
	}
}
