using UnityEngine;
using System.Collections;

public class ChaserVirus : BasicVirus {
    
    public float DirectionRefreshTime;
    
    protected Transform target;

    protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(ChangeDirection());
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(DirectionRefreshTime);
        direction = (target.position - transform.position).normalized;
        StartCoroutine(ChangeDirection());
    }
    
}
