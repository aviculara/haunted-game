using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int addedPoints)
    {
        score = score + addedPoints;
        scoreText.text = score.ToString();
    }
}
