using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dice : MonoBehaviour
{
    public Text score;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void RollDice()
    {
        int number = Random.Range(1, 10);
        score.text = number.ToString();

        if(number > PlayerPrefs.GetInt("HighScore", 0))
        {

            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = number.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
