using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int _score = 0;

    int _index;
    float _lerpTime = 0.5f;
    float _changer;

    Color[] _colorList = new Color[] { Color.red, Color.magenta, Color.blue, Color.yellow };

    public static UIHandler Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = "Score: " + _score.ToString();
    }

    private void Update()
    {
        scoreText.color = Color.Lerp(scoreText.color, _colorList[_index], _lerpTime * Time.deltaTime);
        _changer = Mathf.Lerp(_changer, 1f, _lerpTime * Time.deltaTime);

        if (_changer > 0.9f)
        {
            _changer = 0;
            _index++;

            if (_index >= _colorList.Length)
            {
                _index = 0;
            }
        }
    }

    public void IncreaseScore()
    {
        _score += 5;
        scoreText.text = "Score: " + _score.ToString();
    }
}
