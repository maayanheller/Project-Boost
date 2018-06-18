using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    Rigidbody rigidbody;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Thrust();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            case "Fuel":
                print("fuel");
                break;
            default:
                print("dead");
                break;
        }
    }

    private void Rotate()
    {
        rigidbody.freezeRotation = true; // take manual control of rotation
        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rigidbody.freezeRotation = false; // resume physics control of rotation

    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) // can thrust while rotaiting
        {
            print("audio play");
            rigidbody.AddRelativeForce(Vector3.up * mainThrust);
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
    }
}
