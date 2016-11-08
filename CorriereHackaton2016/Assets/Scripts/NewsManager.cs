using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Collections;

public class NewsManager : MonoBehaviour {

    public Text m_newsField;
    public GameObject m_newsBar;

    public List<string> m_textNews;
    public float m_displayTime = 10.0f;
    //public float m_speed = 1.0f;
    //public float m_directionLimit=20;

    //Transform m_targetTr;
    //Vector3 m_startPosition;
    //float m_change=0;


	// Use this for initialization
	void Start ()
    {
        //m_targetTr = m_newsField.GetComponent<Transform>();
        //m_startPosition = m_targetTr.position;
        GameManager.NewsEvent += UpdateNews;
    }

    void OnDestroy()
    {
        GameManager.NewsEvent -= UpdateNews;
    }
	
	// Update is called once per frame
	void Update ()
    {
        /**
        m_change = Mathf.Repeat(m_change, m_directionLimit);
        m_change += m_speed;
        m_targetTr.position = m_startPosition + m_change *m_targetTr.right;
        */
    }

    public void UpdateNews()
    {
        int r = UnityEngine.Random.Range(0, m_textNews.Count);
        Debug.Log(r);
        string temp = m_textNews[r];
        StartCoroutine(ChangeDisplayedNews(temp));
    }

    private IEnumerator ChangeDisplayedNews(string news_text)
    {
        m_newsField.text = news_text;
        m_newsBar.SetActive(true);
        yield return new WaitForSeconds(m_displayTime);
        m_newsBar.SetActive(false);
    }
}
