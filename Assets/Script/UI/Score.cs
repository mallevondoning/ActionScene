using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private float _scorePerSec;

    private float _score;

    private void Awake()
    {
        _score = 0f;
        DataManager.Score = (int)_score;
    }

    void Update()
    {
        if (DataManager.IsPlaying)
        {
            _score += _scorePerSec * Time.deltaTime;
            _scoreText.text = "Score: " + Mathf.FloorToInt(_score);
        }
        else
        {
            DataManager.Score = Mathf.FloorToInt(_score);
        }
    }
}
