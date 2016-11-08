using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    protected Text Score;

    public delegate void OnNewsEvent();
    public static event OnNewsEvent NewsEvent;

    void Start()
    {
        Score = transform.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        Score.text = "" + Math.Round(Time.time,2);
    }

    void PushRandomNews()
    {
        if(NewsEvent != null)
            NewsEvent();
    }
}
