using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class DeathScreenManager : MonoBehaviour {

    public GameObject m_deathScreen;
    public GameObject m_creditsScreen;
    public float m_delayTime = 1.0f;

	// Use this for initialization
	void Start () {
        Player.PlayerDeath += ShowDeathScreen;
	}

    void OnDestroy()
    {
        Player.PlayerDeath -= ShowDeathScreen;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowDeathScreen()
    {
        StartCoroutine(WaitSomeTime());
    }

    private IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(m_delayTime);
        m_deathScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        m_deathScreen.SetActive(false);
        m_creditsScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenLink()
    {
        Application.OpenURL("http://www.corriere.it/salute/pediatria/cards/decalogo-antibufale-vaccini-societa-italiana-pediatria/i-vaccini-causano-l-autismo-falso.shtml");
    }
}
