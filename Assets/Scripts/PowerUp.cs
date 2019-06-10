using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerUpID; // 0 = speed, 1 = life, 2 = protection

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -6.0f)
        {
            //Debug.Log("Tworze nową moc");
            //float randomX = Random.Range(-1.9f, 1.9f);
            //transform.position = new Vector3(randomX, 5.5f, 0);

            //if (transform.position.y == -6.0f)
            //{
                Destroy(this.gameObject);
            //}
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                if (_powerUpID == 0)
                {
                    player.speedPowerUpOn();
                    Debug.Log("You turned on the power : " + _powerUpID);
                }
                else if (_powerUpID == 1)
                {
                    player.lifePowerUpOn();
                    Debug.Log("You turned on the power: " + _powerUpID);
                }
                else if (_powerUpID == 2)
                {
                    player.protectionPowerUpOn();
                    Debug.Log("You turned on the power: " + _powerUpID);
                }
            }
            Destroy(this.gameObject);
        }
    }
}
