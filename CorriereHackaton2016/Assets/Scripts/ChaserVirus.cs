using UnityEngine;
using System.Collections;

public class ChaserVirus : BasicVirus {
    
    public float RotationSpeed;
    
    protected Transform target;

    protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    protected override void Move ()
    {
        Vector2 targetDir = (target.position - transform.position).normalized;
        direction =  Vector2.Lerp(direction, targetDir, RotationSpeed * Time.fixedDeltaTime);
        rb2D.MovePosition(transform.position + direction * Speed * Time.fixedDeltaTime);
    }
    
}
