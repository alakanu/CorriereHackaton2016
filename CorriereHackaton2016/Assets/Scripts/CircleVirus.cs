using UnityEngine;
using System.Collections;

public class CircleVirus : SinVirus {

    protected float wise;

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
            if (direction.y != 0)
            {
                vertical = true;
            }

            if (vertical)
            {
                currentAngle = 0;
                wise = direction.y >= 0 ? -1 : 1;
            }
            else
            {
                currentAngle = 90;
                wise = direction.x >= 0 ? -1 : 1;
            }

        }
    }

   
protected override void Move()
    {
        center += direction * Speed * Time.fixedDeltaTime;
        currentAngle += Time.fixedDeltaTime * Frequency * wise;
        currentAngle %= 360;
        Vector3 offset = Vector2.zero;
        if (vertical)
        {
            offset = Amplitude * new Vector2(Mathf.Sin(currentAngle * Mathf.Deg2Rad),Mathf.Cos(currentAngle * Mathf.Deg2Rad));
        }
        else
        {
            offset = Amplitude * new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad));
        }

        rb2D.MovePosition(center + offset);
    }
}
