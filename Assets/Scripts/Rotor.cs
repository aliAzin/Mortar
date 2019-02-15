using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour
{

    public float Speed = 1;


    void Update()
    {
        transform.Rotate(new Vector3(0,0,Speed));
    }
}
