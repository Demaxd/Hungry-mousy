using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "HIGHSCORE:\n" + PlayerPrefs.GetInt("Highscore");

    }
}
