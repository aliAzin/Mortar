using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 From;
    public Vector3 To;

    public float Duration = 2;

    private float _startTime = 0;
    private bool _isForward;

    void Start()
    {
        transform.position = From;
        _startTime = Time.time;
        _isForward = true;
    }

    void Update()
    {
        if (_isForward)
        {
            float currentTime = Time.time - _startTime;
            float normalizedTime = currentTime / Duration;
            transform.position = Vector3.Lerp(From, To, normalizedTime);

            if (normalizedTime > 1)
            {
                _isForward = false;
                _startTime = Time.time;
            }
        }
        else
        {
            float currentTime = Time.time - _startTime;
            float normalizedTime = currentTime / Duration;
            transform.position = Vector3.Lerp(To, From, normalizedTime);

            if (normalizedTime > 1)
            {
                _isForward = true;
                _startTime = Time.time;
            }
        }
    }

}
