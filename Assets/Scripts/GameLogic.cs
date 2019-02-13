using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public float Speed = 1;
    public Transform LowLimit;
    public Transform HighLimit;
    public GameObject BoxPrefab;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/Speed);
            Vector3 boxPosition = 
                new Vector3( Random.Range(LowLimit.position.x,HighLimit.position.x), LowLimit.position.y, 0);
            Instantiate(BoxPrefab, boxPosition, Quaternion.identity);
        }
    }

}
