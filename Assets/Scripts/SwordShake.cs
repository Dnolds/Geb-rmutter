using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordShake : MonoBehaviour
{
    public float shakeSpeed = 100f;
    public float shakeAmplitude = 5f;
    public bool isWalking = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            transform.position = new Vector3 (transform.position.x,Mathf.Sin(Time.time*shakeSpeed) * shakeAmplitude + transform.position.y, transform.position.z);
        }
    }
}
