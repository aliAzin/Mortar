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
    public float ShootingSpeed = 10f;

    private float _angle = 0f;
    private float _force = 0f;
    private Vector3 _mouseStartPosition;
    private ShootingState _shootingState;
    private float _startClickTime;

    void Update()
    {

        //        if (Input.GetKey(KeyCode.DownArrow))
        //        {
        //            _angle += 5;
        //        }
        //
        //        if (Input.GetKey(KeyCode.UpArrow))
        //        {
        //            _angle -=  5;
        //        }

        if ( Input.GetMouseButtonDown(0) || ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began ))
        {
            if (Input.touchCount > 0)
            {
                _mouseStartPosition = Input.GetTouch(0).position;
            }
            else
            {
                _mouseStartPosition = Input.mousePosition;
            }

            _startClickTime = Time.time;

            Vector3 ray = Camera.main.ScreenToWorldPoint(_mouseStartPosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if ( hit.collider != null )
            {
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    _shootingState = ShootingState.IsShooting;
                }
                else
                {
                    _shootingState = ShootingState.IsTargeting;
                }
            }
            else
            {
                _shootingState = ShootingState.IsTargeting;
            }
            
        }


        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            Vector2 mousePosition;
            if (Input.touchCount > 0)
            {
                mousePosition = Input.GetTouch(0).position;
            }
            else
            {
                mousePosition = Input.mousePosition;
            }

            if (_shootingState == ShootingState.IsShooting)
            {
                float distance = Vector2.Distance(_mouseStartPosition, mousePosition);
                float currentTime = Time.time - _startClickTime;
                _force = currentTime * ShootingSpeed;
                if (_force > 10)
                    _force = 10;
                Arrow.SetActive(true);

                ShootPoint.localScale = Vector3.one * Mathf.Lerp(0.2f, 1f, _force / 10f);

                if (distance > 200)
                {
                    _shootingState = ShootingState.IsCanceled;
                    ShootPoint.localScale = Vector3.one * .2f;
                    Arrow.SetActive(false);
                }

            }
            else if (_shootingState == ShootingState.IsTargeting)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 nonZeroZ = mousePos - CannonBarrel.position;
                Vector3 direction = new Vector3(nonZeroZ.x, nonZeroZ.y,0);

                CannonBarrel.up = direction;

            }
        }

        if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) && _shootingState == ShootingState.IsShooting)
        {
            // shoot
            GameObject cannonBall = Instantiate(CannonBall, ShootPoint.position, Quaternion.identity);
            Rigidbody2D rigidBody = cannonBall.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(ShootPoint.up * CannonForce* _force, ForceMode2D.Impulse);
            _force = 0;
            ShootPoint.localScale = Vector3.one * .2f;
            Arrow.SetActive(false);
        }
        else if ((Input.GetMouseButtonUp(0) || 
                  (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) && 
                 _shootingState == ShootingState.IsCanceled)
        {
            ShootPoint.localScale = Vector3.one * .2f;
            Arrow.SetActive(false);
        }


    }


}

public enum ShootingState
{
    IsTargeting,
    IsShooting,
    IsCanceled
}