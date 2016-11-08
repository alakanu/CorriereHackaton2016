using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour {

    public string m_sceneName = "Jegher";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene(m_sceneName);
        }
	}
}
