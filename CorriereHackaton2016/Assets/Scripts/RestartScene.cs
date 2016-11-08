using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
	}
}
