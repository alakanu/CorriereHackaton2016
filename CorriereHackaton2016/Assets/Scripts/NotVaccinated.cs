using UnityEngine;
using System.Collections;

public class NotVaccinated : MonoBehaviour
{

    const int min_move_timer = 1;
    const int max_move_timer = 5;

    Transform tr;
    Animator anim;
    Rigidbody2D rigid2d;
    BoxCollider2D box2d;

    public float m_speed = 20f;
    Vector3 direction;

    // Use this for initialization

    void Awake()
    {
        tr = GetComponent<Transform>() as Transform;
        anim = GetComponent<Animator>() as Animator;
        rigid2d = GetComponent<Rigidbody2D>() as Rigidbody2D;
        box2d = GetComponent<BoxCollider2D>() as BoxCollider2D;
    }

    void Start()
    {

    }

    void OnEnable()
    {
        direction = RandomDir();
        SetAnimator();
        StartCoroutine(ChangeDirection());
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(Random.Range(min_move_timer, max_move_timer));
        direction = RandomDir();
        SetAnimator();
        StartCoroutine(ChangeDirection());
    }

    void FixedUpdate()
    {
        rigid2d.velocity = direction * m_speed;
    }

    Vector3 RandomDir()
    {
        Vector3 d = direction;
        int r = Random.Range(1, 4);
        switch (r)
        {
            case 1:
                d = new Vector3(1, 0, 0);
                //tr.localScale = new Vector3(1, 1, 1);
                break;
            case 2:
                d = new Vector3(-1, 0, 0);
                //tr.localScale = new Vector3(-1, 1, 1);
                break;
            case 3:
                d = new Vector3(0, 1, 0);
                break;
            case 4:
                d = new Vector3(0, -1, 0);
                break;
        }
        return d;
    }

    void Bounce()
    {
        direction.x = -1 * direction.x;
        direction.y = -1 * direction.y;
        SetAnimator();
        StopAllCoroutines();
        StartCoroutine(ChangeDirection());
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Bounce();
        }
        if (other.collider.CompareTag("Enemy"))
        {
            StopAllCoroutines();
            direction = new Vector3(0, 0, 0);
            anim.SetInteger("Direction", 0);
            anim.SetBool("Death", true);
            box2d.enabled = false;
            StartCoroutine(DestroyOnDeath());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            Bounce();
        }
    }

    void SetAnimator()
    {
        if (direction.y == 1)
        {
            anim.SetInteger("Direction", 1);
        }
        if (direction.x == 1)
        {
            anim.SetInteger("Direction", 2);
            tr.localScale = new Vector3(1, 1, 1);
        }
        if (direction.y == -1)
        {
            anim.SetInteger("Direction", 3);
        }
        if (direction.x == -1)
        {
            anim.SetInteger("Direction", 4);
            tr.localScale = new Vector3(-1, 1, 1);
        }
    }

    IEnumerator DestroyOnDeath()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}

