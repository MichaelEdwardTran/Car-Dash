using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailpipeSmokeScript : MonoBehaviour {
    private CarController carControl;
    private ParticleSystem tailPipeSmoke;
	// Use this for initialization
	void Start () {
        carControl = transform.root.gameObject.GetComponent<CarController>();
        tailPipeSmoke = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //pipe smoke particles stop when slowing down and play when travelling at constant speed
        if (carControl.rb.drag != 0)
        {
            tailPipeSmoke.Stop();
        }
        else
        {
            tailPipeSmoke.Play();
        }
    }
}
