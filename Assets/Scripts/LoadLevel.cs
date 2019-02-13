using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public string LevelName;
    public void LoadLevelWithName()
    {
        SceneManager.LoadScene(LevelName);
    }
}
