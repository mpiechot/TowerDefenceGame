using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform target;
    public Transform startPoint;
    [Range(0,50)]
    public int enemysToSpawn;
    public float targetDistance = 1.5f;
    public float timeBetweenWaves = 5f;
    public TextMeshProUGUI waveCountdownText;

    private int waveNumber = 1;
    private float countdown = 2f;

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;
        PlayerStats.rounds++;
    }
    private void SpawnEnemy()
    {
        Instantiate<GameObject>(enemyPrefab, startPoint.position, Quaternion.identity);
    }
}
