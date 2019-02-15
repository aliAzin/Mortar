using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text TimeText;
    public Text TargetsCountText;
    public Text LevelName;

    private float _levelStartTime;
    void Start()
    {
        _levelStartTime = Time.time;
        LevelName.text = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        Target[] targets = FindObjectsOfType<Target>();
        TargetsCountText.text =  targets.Length.ToString();

        TimeText.text = ( (int)(Time.time - _levelStartTime) ).ToString();

    }
}
