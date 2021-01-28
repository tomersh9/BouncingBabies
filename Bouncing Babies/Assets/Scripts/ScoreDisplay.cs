using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour {

    private const string SCORE = "Score";
    
    private TextMeshProUGUI _scoreTv;

    private void Awake() {
        _scoreTv = GetComponent<TextMeshProUGUI>();
    }
    
    public void UpdateScoreDisplay(int score) {
        _scoreTv.text = SCORE + " " + score;
    }
}
