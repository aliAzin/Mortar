using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject Explosion;
    public float TimeOut = 5;

    public float ExplosionMagnitute = 3;
    public float ExplosionRadius = 5;

    void OnCollisionEnter2D()
    {
        GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy( gameObject );
        Destroy( explosion, 2);

        Box[] boxes = FindObjectsOfType<Box>();
        foreach (Box box in boxes)
        {
            // Check if the box is in explosion radius
            if ( Vector3.Distance(box.transform.position, transform.position) < ExplosionRadius) {

                // calculate force vector
                Vector3 force = box.transform.position - transform.position;
                // apply force to boxes
                box.GetComponent<Rigidbody2D>().AddForce(force * ExplosionMagnitute, ForceMode2D.Impulse);
            }
        }

    }


}
