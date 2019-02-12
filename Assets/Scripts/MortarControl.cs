using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarControl : MonoBehaviour
{
    public Transform CannonBarrel;

    private float _angle = 0f;

    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _angle += 5;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _angle -=  5;
        }

        CannonBarrel.eulerAngles = new Vector3(0, 0, _angle);


    }


}
