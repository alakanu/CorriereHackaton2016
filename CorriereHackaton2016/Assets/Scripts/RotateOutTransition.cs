using UnityEngine;
using System.Collections;

public class RotateOutTransition : MonoBehaviour {

    protected Transform Pivot;
    protected float acc;
	
	void Start ()
    {
        acc = 0;
        Pivot = transform.Find("Pivot");
	}
	
	// Update is called once per frame
	void Update ()
    {
        acc += 45 * Time.deltaTime;
        transform.RotateAround(Pivot.position, -Vector3.forward, 45 * Time.deltaTime);
        if(acc >= 90)
        {
            Debug.Log("cacca");
            gameObject.SetActive(false);
        }
	}
}
