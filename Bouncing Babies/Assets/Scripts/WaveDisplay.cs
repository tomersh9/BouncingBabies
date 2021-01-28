using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveDisplay : MonoBehaviour
{
    private const string WAVE = "Wave";
    
    private TextMeshProUGUI _waveTv;

    private void Awake() {
        _waveTv = GetComponent<TextMeshProUGUI>();
    }
    
    public void UpdateWaveDisplay(int wave) {
        _waveTv.text = WAVE + " " + wave;
    }
}
