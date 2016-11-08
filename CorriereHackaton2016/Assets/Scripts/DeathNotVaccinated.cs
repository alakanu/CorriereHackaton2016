using UnityEngine;
using System.Collections;

public class DeathNotVaccinated : MonoBehaviour {

    Transform tr;
    SpriteRenderer sp;

    public float m_growth = 2f;
    public float m_alpha = 0.5f;

	// Use this for initialization
	void Start () {
        tr = transform;
        sp = GetComponent<SpriteRenderer>() as SpriteRenderer;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        tr.localScale += new Vector3(1, 1, 0) * m_growth * Time.fixedDeltaTime;
        sp.color = new Color(1, 1, 1, sp.color.a - m_alpha * Time.fixedDeltaTime);
        if (sp.color.a <= 0)
        {
            GameObject.Destroy(gameObject);
        }
	}
}
