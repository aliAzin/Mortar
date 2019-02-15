using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{


    void Update()
    {
        Target[] targets = FindObjectsOfType<Target>();

        if (targets.Length == 0)
        {
            StartCoroutine( LoadLevelAfterSeconds(5) );
        }
    }

    IEnumerator LoadLevelAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);

    }
}
