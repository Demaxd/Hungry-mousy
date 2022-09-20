using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    private Animation anim;

    private AudioSource _audioSrc;
    private int currentScore = 0;
    private int highscore;
    private static int multiplier;
    public static int Multiplier
    {
        set { multiplier = value; }
    }

    private static Color currentColor;
    public static Color CurrentColor { set { currentColor = value; } }

    bool is_played;
    void Start()
    {
        currentColor = Color.black;
        multiplier = 1;
        is_played = false;
        _audioSrc = GetComponent<AudioSource>();
        highscore = PlayerPrefs.GetInt("Highscore");
        anim = scoreText.GetComponent<Animation>();
        scoreText.text = "0";
    }
    void OnTriggerEnter()
    {
        if (multiplier > 1)
        {
            currentScore += multiplier;
            scoreText.color = Color.yellow;
        }
        else
        {
            currentScore++;
            scoreText.color = Color.black;
        }
        scoreText.text = currentScore.ToString();
        anim.Play();

        if (currentScore > highscore) IncreaseHighscore();
    }

    private void IncreaseHighscore()
    {
        if (!is_played)
        {
            _audioSrc.Play();
            is_played = true;
        }

        highscore = currentScore;
        PlayerPrefs.SetInt("Highscore", highscore);
        scoreText.color = Color.green;
    }
}