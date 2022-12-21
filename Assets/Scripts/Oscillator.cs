using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPosition = transform.localPosition;
        Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period; //growing over time
        const float tau = Mathf.PI * 2; 
        float rawSinWave = Mathf.Sin(cycles * tau); // from -1 to 1
        movementFactor = rawSinWave+1f /2; // recalculate to go from 0 to 1
        Vector3 offset = movementVector * movementFactor;
        transform.localPosition = startingPosition + offset;
    }
}
