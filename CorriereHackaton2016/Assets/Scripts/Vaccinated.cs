using UnityEngine;
using System.Collections;

public class Vaccinated : MonoBehaviour {

    Transform tr;
    Animator anim;

    public float m_speed = 20f;
    Vector3 direction;

	// Use this for initialization
	void Start () {
        
        tr = GetComponent<Transform>() as Transform;
        anim = GetComponent<Animator>() as Animator;
        direction = RandomDir();
	}

    void OnEnable()
    {
        StartCoroutine(ChangeDirection());
    }

	
    IEnumerator ChangeDirection()
    {
        direction = RandomDir();
        yield return new WaitForSeconds(Random.Range(1,5));
        StartCoroutine(ChangeDirection());
    }

    void Update()
    {
        //RandomDirProb();
    }

	// Update is called once per frame
	void FixedUpdate () {
        //RandomDir();
        tr.position = tr.position + direction * m_speed * Time.deltaTime;
	}

    void RandomDirProb()
    {
        if (Random.value > 0.80f)
        {
            direction = RandomDir();
        }
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
