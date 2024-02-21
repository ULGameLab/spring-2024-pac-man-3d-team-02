using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.SocialPlatforms.Impl;

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

    void Update()
    {

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("GoodPellet")) {
            AddScore(1);
        }
        if(other.gameObject.CompareTag("ToxicPellet")) {
            //if mega comp numPelletsCollected += 0
            if (Player.hasMegachomp == true)
            {
                AddScore(0);
            }
            if(numPelletsCollected == 0) {
                AddScore(0);
            }
            else {
                AddScore(-1);
            }
        }
    }

    public void AddScore(int points)
    {
        numPelletsCollected += points;
        countPellets.text = numPelletsCollected.ToString();
    }

}
