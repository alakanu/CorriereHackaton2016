using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour {

    public GameObject m_deathScreen; 

	// Use this for initialization
	void Start () {
        Player.PlayerDeath += ShowDeathScreen;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowDeathScreen()
    {
        Instantiate(m_deathScreen);
    }
}
