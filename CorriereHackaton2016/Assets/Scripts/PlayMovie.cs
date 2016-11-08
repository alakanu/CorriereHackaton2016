using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMovie : MonoBehaviour {

    public MovieTexture movie;

	// Use this for initialization
	void Start () {
        GetComponent<RawImage>().texture = movie;
        movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if(!movie.isPlaying)
        {
            SceneManager.LoadScene(1);
        }
	
	}
}
