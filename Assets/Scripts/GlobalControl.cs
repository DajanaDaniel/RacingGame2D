using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GlobalControl : MonoBehaviour
{
    public Text scoreText;
    int bestScores;
    
    // Start is called before the first frame update
    void Start()
    {
        GetBestScores();
    }

    void Update()
    {
        scoreText.text = "Best Score : " + bestScores;
    }

    // Update is called once per frame
    public void GetBestScores()
    {
        var scores = new List<int>();
        using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/score.txt"))
        {
            string score;
            while ((score = reader.ReadLine()) != null)
            {
                scores.Add(int.Parse(score));
            }
        }

        bestScores = scores.Max();
    }

}
