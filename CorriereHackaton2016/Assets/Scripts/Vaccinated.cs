using UnityEngine;
using System.Collections;

public class Vaccinated : MonoBehaviour
{

    const int min_move_timer = 1;
    const int max_move_timer = 5;

    Transform tr;
    Animator anim;
    Rigidbody2D rigid2d;

    public float m_speed = 20f;
    Vector3 direction;

    // Use this for initialization

    void Awake()
    {
        tr = GetComponent<Transform>() as Transform;
        anim = GetComponent<Animator>() as Animator;
        rigid2d = GetComponent<Rigidbody2D>() as Rigidbody2D;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            Debug.Log("Collider");
            direction.x = -1 * direction.x;
            direction.y = -1 * direction.y;
            SetAnimator();
            StopAllCoroutines();
            StartCoroutine(ChangeDirection());
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


}
