using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletAI : MonoBehaviour
{
    public GameObject drop;
    private GameObject parentObject;
    public float secondsBetweenSpawn = 3;
    public int maxPelletCount;
    float elapsedTime = 0;
    int currentPelletCount = 0;
    public float destroyTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        parentObject = transform.gameObject;
        currentPelletCount = countPellets();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        currentPelletCount = countPellets();

        if (elapsedTime > secondsBetweenSpawn && currentPelletCount < maxPelletCount)
        {
            elapsedTime = 0;
            Vector3 pellPos = new Vector3(parentObject.transform.position.x,parentObject.transform.position.y + 0.5f, parentObject.transform.position.z);
            GameObject currentPellet = Instantiate(drop, pellPos, Quaternion.identity);
            currentPelletCount = countPellets();
            Destroy(currentPellet,destroyTime);
        }
    }

    private int countPellets()
    {
        int count = 0;
        GameObject[] pellets = GameObject.FindGameObjectsWithTag("Pellet");
        count = pellets.Length;
        return count;
    }
}
