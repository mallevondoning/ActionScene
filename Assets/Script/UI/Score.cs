using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private float _scorePerSec;

    private float _score;

    void Update()
    {
        if (DataManager.IsPlaying)
        {
            _score += _scorePerSec * Time.deltaTime;
            _scoreText.text = "Score: " + Mathf.FloorToInt(_score);
        }
        else
        {
            _score = DataManager.Score;
        }
    }
}
