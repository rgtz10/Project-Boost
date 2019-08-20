using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Moving : MonoBehaviour
{

    [SerializeField] Vector3 movementDirection = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    float moventFactor;

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } //protects divide by zero
        float cycles = Time.time / period; //grows from 0 forever

        const float tau = Mathf.PI * 2f; // aboout 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); //goes from -1 to 1

        moventFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementDirection * moventFactor;
        transform.position = startingPos + offset;
    }
}
