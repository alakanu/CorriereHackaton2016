using UnityEngine;
using System.Collections;

public class SpawnManagement : MonoBehaviour {

    public GameObject[] Enemies;

    protected Transform[] SpawnPoints;

    public AnimationCurve timeBetweenSpawns;

	void Awake ()
    {

	}

    void Start()
    {
        SpawnPoints = transform.GetComponentsInChildren<Transform>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int SpawnInd = Random.Range(0, transform.childCount);
        int EnemyInd = Random.Range(0, Enemies.Length);
        GameObject enemy = GameObject.Instantiate(Enemies[EnemyInd]);
        enemy.transform.position = SpawnPoints[SpawnInd].position;
        enemy.transform.localScale = Vector3.Scale(SpawnPoints[SpawnInd].localScale, enemy.transform.localScale);
        yield return (new WaitForSeconds(timeBetweenSpawns.Evaluate(Time.time)));
        StartCoroutine(Spawn());

    }
}
