using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour {

    float m_horizontal;
    float m_vertical;
    Rigidbody2D m_rigid2d;
    Animator m_animator;
    Transform tr;
    bool m_dying = false;

    public delegate void OnPlayerDeath();
    public static event OnPlayerDeath PlayerDeath;

    public float m_speed = 10f;

	// Use this for initialization
	void Start ()
    {
        tr = GetComponent<Transform>();
        m_rigid2d = gameObject.GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        GameManager.NewsEvent += TurnOnSurprised;
    }

    void OnDestroy()
    {
        GameManager.NewsEvent -= TurnOnSurprised;
    }

    // Update is called once per frame
    void Update () {
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");

        if(!m_dying)
            AnimateCharacter();
    }

    private void AnimateCharacter()
    {
        FlipPlayer();
        UpdateAnimator();
    }

    private void FlipPlayer()
    {
        Vector3 temp = tr.localScale;

        if (m_horizontal < 0)
            temp = new Vector3(-1,1,1);
        
        if(m_horizontal > 0 )
            temp = Vector3.one;

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
        if (!m_dying)
            m_rigid2d.velocity = tr.right * m_horizontal * m_speed * Time.fixedDeltaTime + tr.up * m_vertical * m_speed * Time.fixedDeltaTime;
        else
            m_rigid2d.velocity = Vector3.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            m_animator.SetBool("dying",true);
            m_dying = true;

            if (PlayerDeath != null)
                PlayerDeath();
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
