using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    public string _startGry;
    
    public void NowaGra()
    {
        Application.LoadLevel(_startGry);
    }

    public void WyjdzZGry()
    {
        Application.Quit();
    }

}
