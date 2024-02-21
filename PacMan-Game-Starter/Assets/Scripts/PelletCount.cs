using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PelletCount : MonoBehaviour
{
    public static int numPelletsCollected = 0;

    public TMP_Text countPellets;

    // Start is called before the first frame update
    void Start()
    {
        countPellets = countPellets.GetComponent<TMP_Text>();

        countPellets.text = numPelletsCollected.ToString();
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("GoodPellet")) {
            numPelletsCollected += 1;
        }
        if(other.gameObject.CompareTag("ToxicPellet")) {
            //if mega comp numPelletsCollected += 0
            if(numPelletsCollected == 0) {
                numPelletsCollected += 0;
            }
            else {
                numPelletsCollected -= 1;
            }
        }
    }
}
