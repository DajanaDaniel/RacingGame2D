using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private Rigidbody2D enemy;

    public float _wait = 5.0f;

     Vector2 positionToGo, whereToMove;
     private float randomX;
    private float randomY;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        GeneratePosition();
    }

    void Update()
    {
        if (_wait > 0)
        {
            GoToPozition();
            _wait -= Time.deltaTime;
        }
        else
        {
            GeneratePosition();
            _wait = 5f;
        }
    }

    public void GeneratePosition()
    {
        randomX = Random.Range(-2.5f, 1.28f);
        randomY = Random.Range(-12.0f, 1.0f);
        positionToGo = new Vector2(randomX, randomY);
    }

    public void GoToPozition()
    {
        whereToMove = (positionToGo - enemy.position).normalized;
        enemy.velocity = new Vector2(whereToMove.x * speed, whereToMove.y * speed);
    }

}
