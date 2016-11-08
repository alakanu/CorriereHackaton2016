using UnityEngine;
using System.Collections;

public class NotVaccinated : Vaccinated {

    protected new void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        if (other.collider.CompareTag("Enemy"))
        {
            StopAllCoroutines();
            direction = new Vector3(0, 0, 0);
            anim.SetInteger("Direction", 0);
            anim.SetBool("Death", true);
            box2d.enabled = false;
            StartCoroutine(DestroyOnDeath());
        }
    }

    IEnumerator DestroyOnDeath()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
