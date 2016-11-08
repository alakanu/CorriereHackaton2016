using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {


	public static SoundManager Instance = null;

	public AudioSource m_background_player;

	[Header("Player Sound Effects")]
	public AudioSource m_player_effects;
    public AudioClip m_background;
    public AudioClip m_death;
    public AudioClip m_virus;



	void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	void Start() {
        m_background_player.clip = m_background;
		m_background_player.Play ();
	}

	public void PlayerDeath() {
		m_player_effects.PlayOneShot (m_death);
	}

    public void VirusDeath()
    {
        m_player_effects.PlayOneShot(m_virus);
    }

}
