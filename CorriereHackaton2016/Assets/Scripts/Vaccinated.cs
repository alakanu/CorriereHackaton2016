using UnityEngine;
using System.Collections;

public class Vaccinated : MonoBehaviour {

    const int min_move_timer = 1;
    const int max_move_timer = 5;

    Transform tr;
    Animator anim;
    Rigidbody2D rigid2d;

    public float m_speed = 20f;
    Vector3 direction;

	// Use this for initialization
	void Start () {
        
        tr = GetComponent<Transform>() as Transform;
        anim = GetComponent<Animator>() as Animator;
        rigid2d = GetComponent<Rigidbody2D>() as Rigidbody2D;
	}

    void OnEnable()
    {
        StartCoroutine(ChangeDirection());
    }
	
    IEnumerator ChangeDirection()
    {
        direction = RandomDir();
        yield return new WaitForSeconds(Random.Range(min_move_timer, max_move_timer));
        StartCoroutine(ChangeDirection());
    }

	void FixedUpdate () {
        rigid2d.velocity = direction * m_speed;
	}

    Vector3 RandomDir()
    {
            int r = Random.Range(1, 4);
            switch (r)
            {
                case 1:
                    return new Vector3(1, 0, 0);
                    //an.SetInteger("Direction", 2);
                case 2:
                    return new Vector3(-1, 0, 0);
                    //an.SetInteger("Direction", 4);
                case 3:
                    return new Vector3(0, 1, 0);
                    //an.SetInteger("Direction", 1);
                case 4:
                    return new Vector3(0, -1, 0);
                    //an.SetInteger("Direction", 3);
                default:
                    return new Vector3(0, 0, 0);
                    //an.SetInteger("Direction", 0);
            }
        }
    

}
