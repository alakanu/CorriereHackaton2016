using UnityEngine;
using System.Collections;

public class TriangleVirus : BasicVirus {

    public float HoldTime;
    public float Amplitude;

    protected Vector3 center;

    protected float changeSpeed;

    protected float span;

    protected bool changeFront;
    protected bool vertical;
    
    public override Vector3 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            ready = true;
            changeFront = true;
            direction = value;
            center = transform.position;
            changeSpeed = Speed;
            span = Amplitude / 2f;
            if (direction.y != 0)
            {
                vertical = true;
            }
        }
    }

    IEnumerator Hold()
    {
        yield return new WaitForSeconds(HoldTime);
        changeSpeed *= -1;
        changeFront = true;
    }
    
    protected override void Move()
    {
        Vector3 forwardIncrement = direction * Speed * Time.fixedDeltaTime;
        center += forwardIncrement;
        
        if (vertical)
        {
            if(changeFront)
            {
                Vector2 nextPos = transform.position + forwardIncrement + transform.right * changeSpeed * Time.fixedDeltaTime;
                if(Vector2.Distance(nextPos, center) >= span)
                {
                    changeFront = false;
                    nextPos = center + transform.right * span * Mathf.Sign(changeSpeed);
                    StartCoroutine(Hold());
                }
                
                rb2D.MovePosition(nextPos);
                
            }
            else
            {
                rb2D.MovePosition(transform.position + forwardIncrement);
            }
        }
        else
        {
            if (changeFront)
            {
                Vector2 nextPos = transform.position + forwardIncrement + transform.up * changeSpeed * Time.fixedDeltaTime;
                if (Vector2.Distance(nextPos,center) >= span)
                {
                    changeFront = false;
                    nextPos = center + transform.up * span * Mathf.Sign(changeSpeed);
                    StartCoroutine(Hold());
                }

                rb2D.MovePosition(nextPos);
            }
            else
            {
                rb2D.MovePosition(transform.position + forwardIncrement);
            }
            
        }
        
    }
}
