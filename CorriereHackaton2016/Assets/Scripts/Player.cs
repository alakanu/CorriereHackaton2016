using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    float m_horizontal;
    float m_vertical;
    Rigidbody2D m_rigid2d;
    Transform tr;

    public float m_speed = 10f;

	// Use this for initialization
	void Start ()
    {
        tr = GetComponent<Transform>() as Transform;
        m_rigid2d = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
    }
	
	// Update is called once per frame
	void Update () {

        m_horizontal = Input.GetAxis("Horizontal");

        m_vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        m_rigid2d.velocity = tr.right * m_horizontal * m_speed
                        + tr.up * m_vertical * m_speed;
    }

}
