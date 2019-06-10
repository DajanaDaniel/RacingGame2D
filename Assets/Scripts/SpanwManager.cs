using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUps;

    [SerializeField]
    private GameObject[] obstacles; //tablca bo będziemy dodawać np dziury 

    public float speedCreatePowerUp = 5.0f;
    public float speedCreateObstacle = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObstaclesSpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    IEnumerator ObstaclesSpawnRoutine()
    {
        while (true)
        {
            int randomObscales = Random.Range(0, 2);
            Instantiate(obstacles[randomObscales], new Vector3(Random.Range(-1.9f, 1.9f), 6, 0), Quaternion.identity);
            yield return new WaitForSeconds(speedCreateObstacle);

        }
    }

    IEnumerator PowerUpSpawnRoutine()
    {
        while (true)
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerUps[randomPowerUp], new Vector3(Random.Range(-1.9f, 1.9f), 6, 0), Quaternion.identity);
            yield return new WaitForSeconds(speedCreatePowerUp);
        }
    }
}
