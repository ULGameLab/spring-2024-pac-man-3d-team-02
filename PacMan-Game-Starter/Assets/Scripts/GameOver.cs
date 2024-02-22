using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text score;

    public void Start() {
        score.SetText(PelletCount.numPelletsCollected.ToString());
    }
}
