using UnityEngine;
using System.Collections;

public class BasicVirus : MonoBehaviour {

    public float Speed;

    public VirusAnimators animCollection;

    protected Animator animator;

    protected Vector3 direction;

    protected Rigidbody2D rb2D;

    protected bool ready;
    
    public virtual Vector3 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
            ready = true;
        }
    }    
	
    protected void Awake()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animCollection.Animators[Random.Range(0, animCollection.Animators.Length)];
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            GameObject.Destroy(gameObject);
            
        }
    }

    protected void FixedUpdate()
    {
        if (ready)
        {
            Move();
        }
    }

    protected virtual void Move()
    {
        rb2D.MovePosition(transform.position + direction * Speed * Time.fixedDeltaTime);
    }
}
