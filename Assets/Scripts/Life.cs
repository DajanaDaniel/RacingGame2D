using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public PlayerController _palyer;
    public float _energy;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    

    // Start is called before the first frame update
    void Start()
    {
        Life1 = GameObject.Find("Life1");
        Life2 = GameObject.Find("Life2");
        Life3 = GameObject.Find("Life3");

    }

    public void changeEnergyDown(int value)
    {
        _energy = _energy - value;
        Debug.Log("Life: " + _energy);
        if(_energy == 0)
        {
            StartCoroutine(_palyer.DestroyPlayer());
        }
    
    }

    public void changeEnergyUp(int value)
    {
        if(_energy != 3)
        {
            _energy = _energy + value;
            Debug.Log(_energy);
        }
        Debug.Log("Nie dodaje żyć bo masz już 3!");
    }

    // Update is called once per frame
    void Update()
    {
        getLife();
    }

    void getLife()
    {
        if(_energy == 3)
        {
            Life3.GetComponent<Renderer>().enabled = true;
            Life2.GetComponent<Renderer>().enabled = true;
            Life1.GetComponent<Renderer>().enabled = true;
        }

        else if (_energy == 2)
        {
            Life3.GetComponent<Renderer>().enabled = false;
            Life2.GetComponent<Renderer>().enabled = true;
            Life1.GetComponent<Renderer>().enabled = true;
        }

        else if (_energy == 1)
        {
            Life3.GetComponent<Renderer>().enabled = false;
            Life2.GetComponent<Renderer>().enabled = false;
            Life1.GetComponent<Renderer>().enabled = true;
        }

        else if (_energy == 0)
        {
            Life3.GetComponent<Renderer>().enabled = false;
            Life2.GetComponent<Renderer>().enabled = false;
            Life1.GetComponent<Renderer>().enabled = false;
        }
    }
}
