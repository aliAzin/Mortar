using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MortarControl : MonoBehaviour
{
    public Transform CannonBarrel;
    public GameObject CannonBall;
    public Transform ShootPoint;
    public float CannonForce = 10;

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

        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            GameObject cannonBall = Instantiate(CannonBall, ShootPoint.position, Quaternion.identity);
            Rigidbody2D rigidBody = cannonBall.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(ShootPoint.up * CannonForce, ForceMode2D.Impulse);
        }

    }


}
