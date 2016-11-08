using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour {

    float m_horizontal;
    float m_vertical;
    Rigidbody2D m_rigid2d;
    Animator m_animator;
    Transform tr;
    bool looking_right = false;

    public float m_speed = 10f;
    public UnityEvent m_onPlayerDeath;

	// Use this for initialization
	void Start ()
    {
        tr = GetComponent<Transform>();
        m_rigid2d = gameObject.GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");

        AnimateCharacter();
    }

    private void AnimateCharacter()
    {
        UpdateAnimator();
        FlipPlayer();
        
    }

    private void FlipPlayer()
    {
        Vector3 temp = tr.localScale;

        if (m_horizontal < 0 && looking_right)
        {
            looking_right = false;
            temp = new Vector3(-1,1,1);
        }
        
        if(m_horizontal > 0 && !looking_right)
        {
            looking_right = true;
            temp = Vector3.one;
        }
        tr.localScale = temp;
    }

    private void UpdateAnimator()
    {
        m_animator.SetInteger("dir", 0);

        if (m_horizontal != 0)
            m_animator.SetInteger("dir", 1);

        if (m_vertical > 0)
            m_animator.SetInteger("dir", 2);

        if (m_vertical < 0)
            m_animator.SetInteger("dir", 3);

        if (m_rigid2d.velocity == Vector2.zero)
            m_animator.SetBool("moving", false);
        else
            m_animator.SetBool("moving", true);
    }

    void FixedUpdate()
    {
        m_rigid2d.velocity = tr.right * m_horizontal * m_speed
                        + tr.up * m_vertical * m_speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            m_onPlayerDeath.Invoke();
            m_animator.SetBool("dying",true);
            Debug.Log("Colpito");
        }
    }

    public void TurnOnSurprised()
    {
        m_animator.SetBool("surprised",true);
        StartCoroutine(TurnOffSurprised());
    }

    IEnumerator TurnOffSurprised()
    {
        yield return new WaitForSeconds(0.5f);
        m_animator.SetBool("surprised",false);
    }
}
