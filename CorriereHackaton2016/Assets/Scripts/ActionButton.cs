using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {

    public GameObject Next;

	public void PopNext()
    {
        GameObject.Instantiate(Next);
        GameObject.Destroy(gameObject);
    }
}
