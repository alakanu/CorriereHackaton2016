using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    protected Text Score;

    protected Text Percentage;

    protected float time;

    protected float perc;

    public delegate void OnNewsEvent();
    public static event OnNewsEvent NewsEvent;

    public int m_news_time = 30;

    void Start()
    {
        Score = transform.Find("Score").GetComponent<Text>();
        Percentage = transform.Find("Percentage").GetComponent<Text>();
        StartCoroutine(PushRandomNews());
        Player.PlayerDeath += ResetTime;
        time = 0;
        perc = 100;
        Percentage.text = "Percentage of vaccinated: 100%";
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
        yield return new WaitForSeconds(m_news_time);
        perc = perc == 0 ? 0 : perc - 20;
        
        Percentage.text = "Percentage of vaccinated: " + perc+ " %";
        if (NewsEvent != null)
            NewsEvent();
        StartCoroutine(PushRandomNews());
    }

    public void PlayerDeath()
    {
        StopAllCoroutines();
    }
}
