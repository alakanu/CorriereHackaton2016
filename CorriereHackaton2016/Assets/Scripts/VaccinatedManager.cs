using UnityEngine;
using System.Collections;

public class VaccinatedManager : MonoBehaviour {

    public NotVaccinated m_novacc;
    public int m_change_number;

	// Use this for initialization
	void Start () {
        GameManager.NewsEvent += News;
	}

    void News()
    {
        Vaccinated[] vacc = GameObject.FindObjectsOfType(typeof(Vaccinated)) as Vaccinated[];
        for (int i=0; i< m_change_number; i++)
        {
            Vector3 pos = vacc[i].gameObject.transform.position;
            GameObject.Destroy(vacc[i].gameObject);
            GameObject.Instantiate(m_novacc, pos, Quaternion.identity);
        }
    }

}
