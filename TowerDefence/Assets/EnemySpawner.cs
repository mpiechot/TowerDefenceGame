using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform target;
    [Range(0,30)]
    public int enemysToSpawn;
    public float targetDistance = 45;
    private List<GameObject> enemys = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemysToSpawn; i++)
        {
            GameObject enemy = Instantiate<GameObject>(enemyPrefab, transform.position, Quaternion.identity);
            NavTestAI ai = enemy.GetComponent<NavTestAI>();
            ai.target = target;
            enemys.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = enemys.Count-1;i>=0;i--)
        {
            if(Vector3.Distance(target.position,enemys[i].transform.position) <= targetDistance)
            {
                Destroy(enemys[i]);
                enemys.RemoveAt(i);
            }
        }
        for(int i = enemys.Count;i < enemysToSpawn; i++)
        {
            GameObject enemy = Instantiate<GameObject>(enemyPrefab, transform.position, Quaternion.identity);
            NavTestAI ai = enemy.GetComponent<NavTestAI>();
            ai.target = target;
            enemys.Add(enemy);
        }
    }
}
