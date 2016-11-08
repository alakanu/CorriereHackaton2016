using UnityEngine;
using System.Collections;

public class VaccinatedManager : MonoBehaviour {

    public NotVaccinated m_novacc;
    public GameObject m_container;
    public int m_change_number;

	// Use this for initialization
	void Start () {
        GameManager.NewsEvent += News;
	}

    void News()
    {
        int children_count = m_container.transform.childCount;


        for (int i=0; i< m_change_number; i++)
        {
            Transform trans = m_container.transform.GetChild(i);
            Vector3 pos = trans.position;
            GameObject.Destroy(trans.gameObject);
            GameObject.Instantiate(m_novacc, pos, Quaternion.identity);
        }
    }

    void OnDestroy()
    {
        GameManager.NewsEvent -= News;
    }

}
