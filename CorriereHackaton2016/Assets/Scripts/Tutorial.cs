using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public Sprite One;
    public Sprite Two;
    public Sprite Three;

    protected int count;

    protected Image img;

    void Start () {
        count = 0;
        img = GetComponent<Image>();
        img.sprite = One;
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Submit"))
        {
            count++;
            if (count == 3)
            {
                SceneManager.LoadScene(1);
            }
            switch (count)
            {
                case 1:
                    img.sprite = Two;
                    break;
                case 2:
                    img.sprite = Three;
                    break;
            }
            
        }
	
	}
}
