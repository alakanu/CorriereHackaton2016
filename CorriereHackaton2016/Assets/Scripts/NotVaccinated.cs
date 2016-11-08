using UnityEngine;
using System.Collections;

public class NotVaccinated : Vaccinated {

    public GameObject m_death_pre;

    new void OnEnable()
    {
        StartCoroutine(Surprise());
    }

    IEnumerator Surprise()
    {
        anim.SetInteger("Direction", 0);
        anim.SetBool("Surprised", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("Surprised", false);
        base.OnEnable();
    }


    protected new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            GameObject.Destroy(other.gameObject);
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
        yield return new WaitForSeconds(1);
        GameObject.Instantiate(m_death_pre, tr.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
