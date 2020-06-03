using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    public Text scoreText;

    void Update()
    {
        scoreText.text = "SCORE:" + PacDot.takenPacDots;
    }
}
