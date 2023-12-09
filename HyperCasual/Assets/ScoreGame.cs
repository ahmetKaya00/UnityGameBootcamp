using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreGame : MonoBehaviour
{
    private int _score;
    private TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        GameManager.OnCubespawner += GameManager_OnCubeSpawner;
    }
    private void OnDestroy()
    {
        GameManager.OnCubespawner -= GameManager_OnCubeSpawner;
    }
    private void GameManager_OnCubeSpawner()
    {
        _score++;
        _text.text = "Score:" + _score; 
    }
}
