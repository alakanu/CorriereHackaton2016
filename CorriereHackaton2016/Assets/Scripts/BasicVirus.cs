using UnityEngine;
using System.Collections;

public class BasicVirus : MonoBehaviour {

    public float Speed;

    protected Vector3 direction;

    protected Rigidbody2D rb2D;

    protected bool ready;

    protected bool firstTouch;
    
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
        rb2D = GetComponent<Rigidbody2D>();
        firstTouch = true;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            if(firstTouch)
            {
                firstTouch = false;
            }
            else
            {
                GameObject.Destroy(gameObject);
            }
            
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
