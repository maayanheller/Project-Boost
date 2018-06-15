﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidbody;
    AudioSource audio;
	
    // Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();

        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space)) // can thrust while rotaiting
        {
            print("audio play");
            rigidbody.AddRelativeForce(Vector3.up);
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }

        else
        {
            audio.Stop();
            print("audio stop");
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}
