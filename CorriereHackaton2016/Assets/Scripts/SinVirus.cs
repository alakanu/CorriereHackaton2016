using UnityEngine;
using System.Collections;

public class SinVirus : BasicVirus {

    public float Frequency;
    public float Amplitude;

    protected float currentAngle;

    protected Vector3 center;

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
            direction = value;
            center = transform.position;
            if(direction.y != 0)
            {
                vertical = true;
            }
            
        }
    }

    protected new void Awake()
    {
        base.Awake();
        currentAngle = 0;
    }

    protected override void Move()
    {
        center += direction * Speed * Time.fixedDeltaTime;
        currentAngle += Time.fixedDeltaTime * Frequency;
        currentAngle %= 360;

        if (vertical)
        {
            rb2D.MovePosition(center + Amplitude * transform.right * Mathf.Sin(currentAngle * Mathf.Deg2Rad));
        }
        else
        {
            rb2D.MovePosition(center + Amplitude * transform.up * Mathf.Sin(currentAngle * Mathf.Deg2Rad));
        }

        
    }
}
