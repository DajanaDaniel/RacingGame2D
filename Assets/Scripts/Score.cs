using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public trackMove trackMove;
    public SpanwManager spanwManager;
    public float odliczanie = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, odliczanie);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    void scoreUpdate()
    {
        score += 1;
        leveUp();
    }

    public void leveUp()
    {
        if(score == 5)
        {
            //Level 2
            Debug.Log("Level 2 ");
            InvokeRepeating("scoreUpdate", 1.0f, 4.0f);
            trackMove._speed = 0.6f;
            spanwManager.speedCreatePowerUp = 5.0f;
            spanwManager.speedCreateObstacle = 4.0f;
        }
        if(score == 10)
        {
            //Level 3
            Debug.Log("Level 3 ");
            InvokeRepeating("scoreUpdate", 1.0f, 4.0f);
            trackMove._speed = 0.8f;
            spanwManager.speedCreatePowerUp = 5.0f;
            spanwManager.speedCreateObstacle = 3.0f;
            odliczanie = 4.0f;
        }
        if (score == 15)
        {
            //Level 4
            Debug.Log("Level 4 ");
            InvokeRepeating("scoreUpdate", 1.0f, 3.0f);
            trackMove._speed = 1.0f;
            spanwManager.speedCreatePowerUp = 4.0f;
            spanwManager.speedCreateObstacle = 2.0f;
            odliczanie = 3.0f;
        }
        if (score == 20)
        {
            //Level 5
            Debug.Log("Level 5 ");
            InvokeRepeating("scoreUpdate", 1.0f, 2.0f);
            trackMove._speed = 1.2f;
            spanwManager.speedCreatePowerUp = 3.0f;
            spanwManager.speedCreateObstacle = 1.0f;
            odliczanie = 2.0f;
        }
        if (score == 25)
        {
            //Level 6
            Debug.Log("Level 6 ");
            InvokeRepeating("scoreUpdate", 1.0f, 1.0f);
            trackMove._speed = 1.4f;
            odliczanie = 1.0f;
        }
    }
}
