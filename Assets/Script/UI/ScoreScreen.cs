using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score: " + DataManager.Score;
    }
}
