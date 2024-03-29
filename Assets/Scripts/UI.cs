using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _pointsText;
    [SerializeField] private GameObject _highestScoreText;

    private int _points = 0;
    private int _highestScore = 0;

    private void Start() {

    }

    private void IncreasePoints() {
        _points++;
        _pointsText.GetComponent<TextMeshProUGUI>().text = _points.ToString();
    }

    private void ResetPoints() {
        _points = 0;
        _pointsText.GetComponent<TextMeshProUGUI>().text = _points.ToString();
    }

    private void SetHighestScore() {
        _highestScore = _highestScore > _points ? _highestScore : _points;
        _highestScoreText.GetComponent<TextMeshProUGUI>().text = "Highest score: " + _highestScore.ToString();
    }
}
