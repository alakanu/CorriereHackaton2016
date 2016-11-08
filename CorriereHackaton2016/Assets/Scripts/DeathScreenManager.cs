using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour {

    public GameObject m_deathScreen; 

	// Use this for initialization
	void Start () {
        m_deathScreen.SetActive(false);
        Player.PlayerDeath += ShowDeathScreen;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowDeathScreen()
    {
        m_deathScreen.SetActive(true);
    }

    public void RestartScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
