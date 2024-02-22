using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoodPellets : MonoBehaviour
{
    public GameObject goodPellPrefab;
    private GameObject parentObject;
    public int maxGoodPell = 10;
    public float secondsBetweenSpawn = 2;
    float elapsedTime = 0;
    int curGoodPell = 0;
    public float destroyTime = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        curGoodPell = CountGoodPell();
        parentObject = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.deltaTime;
        curGoodPell = CountGoodPell();
        if (elapsedTime < secondsBetweenSpawn && curGoodPell < maxGoodPell) 
        {
            elapsedTime = 0;
            Vector3 offset = new Vector3(0, 1, 0);
            Vector3 spawnPosition = offset + RandomPositionAroundPlayer();
            GameObject newGoodPell = (GameObject)Instantiate(goodPellPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
            newGoodPell.transform.SetParent(parentObject.transform);
            curGoodPell = CountGoodPell();
            Destroy(newGoodPell,destroyTime);
        }
    }

    private int CountGoodPell()
    {
        int count = 0;
        GameObject[] goodPells = GameObject.FindGameObjectsWithTag("GoodPellet");
        count = goodPells.Length;
        return count;
    }

    private Vector3 RandomPositionAroundPlayer()
    {
        Vector3 randPos = new Vector3(Random.Range(-30.0f, 30.0f), 0, Random.Range(-30.0f, 30.0f));
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        randPos += playerPos;
        randPos.x += 10.0f;
        randPos.y += 10.0f;
        randPos.z += 10.0f;
        NavMeshHit hit;
        NavMesh.SamplePosition(randPos, out hit, Mathf.Infinity, NavMesh.AllAreas);
        randPos = hit.position;
        return randPos;
    }


}
