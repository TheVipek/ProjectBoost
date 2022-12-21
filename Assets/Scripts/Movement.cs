using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] AudioClip engineSound;
    [SerializeField] float thrust;
    [SerializeField] float rotationSpeed;
    [SerializeField] ParticleSystem leftBooster, rightBooster, mainBooster;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainBooster.Stop();
    }

    void StartThrusting()
    {
        rb.AddRelativeForce((new Vector3(0, 1, 0) * thrust) * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineSound);
        }
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            StartRotating();
        }
        else
        {
            StopRotating();
        }
    }

    void StartRotating()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!rightBooster.isPlaying)
            {
                rightBooster.Play();
            }
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!leftBooster.isPlaying)
            {
                leftBooster.Play();
            }
            ApplyRotation(-rotationSpeed);

        }
    }

    void StopRotating()
    {
        rightBooster.Stop();
        leftBooster.Stop();
    }

    private void ApplyRotation(float rotationDirection)
    {
        rb.freezeRotation = true;
        transform.Rotate(((Vector3.forward * rotationDirection) * Time.deltaTime )  );
        rb.freezeRotation = false;
    }
}
