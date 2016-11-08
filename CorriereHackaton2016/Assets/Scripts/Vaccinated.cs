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
    void Start()
    {

        tr = GetComponent<Transform>() as Transform;
        anim = GetComponent<Animator>() as Animator;
        rigid2d = GetComponent<Rigidbody2D>() as Rigidbody2D;
    }

    void OnEnable()
    {
        direction = RandomDir();
        StartCoroutine(ChangeDirection());
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(Random.Range(min_move_timer, max_move_timer));
        direction = RandomDir();
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
                anim.SetInteger("Direction", 2);
                break;
            case 2:
                d = new Vector3(-1, 0, 0);
                anim.SetInteger("Direction", 4);
                break;
            case 3:
                d = new Vector3(0, 1, 0);
                anim.SetInteger("Direction", 1);
                break;
            case 4:
                d = new Vector3(0, -1, 0);
                anim.SetInteger("Direction", 3);
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
            StopAllCoroutines();
            StartCoroutine(ChangeDirection());
        }


    }


}
