using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    protected Text Score;

    protected float time;

    public delegate void OnNewsEvent();
    public static event OnNewsEvent NewsEvent;

    void Start()
    {
        Score = transform.Find("Score").GetComponent<Text>();
        StartCoroutine(PushRandomNews());
        Player.PlayerDeath += ResetTime;
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        Score.text = "" + Math.Round(time,2);
    }

    public void ResetTime()
    {
        time = 0;
    }

    IEnumerator PushRandomNews()
    {
        yield return new WaitForSeconds(30);
        if(NewsEvent != null)
            NewsEvent();
        StartCoroutine(PushRandomNews());
    }
}
