using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -6.0f)
        {
            //float randomX = Random.Range(-1.7f, 1.7f);
            //transform.position = new Vector3(randomX, 5.80f, 0);

            //if (transform.position.y < -6.0f)
            //{
                Destroy(this.gameObject);
            //}
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if(player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
