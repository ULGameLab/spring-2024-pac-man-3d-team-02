using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private GameObject parentObject;
    public int maxEnemyCount = 7;
    public float secondsBetweenSpawn = 2;
    float elapsedTime = 0;
    int currentEnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentEnemyCount = CountEnemy();
        parentObject = transform.gameObject;

    }
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        currentEnemyCount = CountEnemy();

        if (elapsedTime > secondsBetweenSpawn && currentEnemyCount < maxEnemyCount)
        {
            for (int i = 0; i < enemyPrefabs.Length; i++)
            {
                elapsedTime = 0;
                Vector3 spawnPosition = RandomPositionAroundPlayer();
                Debug.Log(i.ToString());
                GameObject newEnemy = (GameObject)Instantiate(enemyPrefabs[i], spawnPosition, Quaternion.Euler(0, 0, 0));
                newEnemy.transform.SetParent(parentObject.transform);
                currentEnemyCount = CountEnemy();

            }
        }   
    }

    private int CountEnemy()
    {
        int count = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        count = enemies.Length;
        return count;
    }
    private Vector3 RandomPositionAroundPlayer()
    {
        Vector3 randPos = new Vector3(Random.Range(-30.0f, 30.0f), 0, Random.Range(-30.0f, 30.0f));
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        randPos += playerPos;
        randPos.x += 10.0f;
        randPos.y = 0.11f;
        randPos.z += 10.0f;
        NavMeshHit hit;
        NavMesh.SamplePosition(randPos, out hit, Mathf.Infinity, NavMesh.AllAreas);
        randPos = hit.position;
        return randPos;
    }
}
