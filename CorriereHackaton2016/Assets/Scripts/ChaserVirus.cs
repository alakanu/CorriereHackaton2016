using UnityEngine;
using System.Collections;

public class ChaserVirus : BasicVirus {
    
    public float RotationSpeed;
    
    protected Transform target;

    protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    protected override void Move()
    {
        Vector3 targetDirection = (target.position - transform.position).normalized;
        direction = Vector3.Lerp(direction, targetDirection, Time.fixedDeltaTime * RotationSpeed);
        rb2D.MovePosition(transform.position + direction * Speed * Time.fixedDeltaTime);
    }
    
}
