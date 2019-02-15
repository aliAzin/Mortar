using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MortarControl : MonoBehaviour
{
    public Transform CannonBarrel;
    public GameObject CannonBall;
    public Transform ShootPoint;
    public float CannonForce = 10;
    public GameObject Arrow;

    private float _angle = 0f;
    private float _force = 0f;

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


        if (Input.GetKey(KeyCode.Space))
        {
            Arrow.SetActive(true);
            _force += .1f;
            if (_force > 10)
                _force = 10;
            ShootPoint.localScale = Vector3.one * Mathf.Lerp(0.2f, 1f, _force / 10f);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // shoot
            GameObject cannonBall = Instantiate(CannonBall, ShootPoint.position, Quaternion.identity);
            Rigidbody2D rigidBody = cannonBall.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(ShootPoint.up * CannonForce* _force, ForceMode2D.Impulse);
            _force = 0;
            ShootPoint.localScale = Vector3.one * .2f;
            Arrow.SetActive(false);
        }

    }


}
