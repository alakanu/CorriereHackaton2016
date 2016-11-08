using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    protected Text Score;

    void Start()
    {
        Score = transform.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        Score.text = "" + Math.Round(Time.time,2);
    }
}
