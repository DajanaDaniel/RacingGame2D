using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private GameObject _explosionPlayer;

    [SerializeField]
    private GameObject _protectionPlayer;

    public bool speedPower = false;
    public bool protectionActive = false;

    public Life life;
    public string _startMenu;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-0.04f, -3.49f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
#if UNITY_ANDROID
        float horizontalInput = SimpleInput.GetAxis("Horizontal");
#else
        float horizontalInput = Input.GetAxis("Horizontal");
#endif
        Move(horizontalInput);

        if (transform.position.x > 2.64f)
        {
            if (protectionActive == true)
            {
                Debug.Log("Wyłączam tarcze");
                protectionActive = false;
                _protectionPlayer.SetActive(false);
                transform.position = new Vector3(-0.04f, -3.49f, 0);
                return;
            }
            life.changeEnergyDown(1);
            Debug.Log("Usówam jedno życie");
            transform.position = new Vector3(-0.04f, -3.49f, 0);
        }
        else if (transform.position.x < -2.64f)
        {
            if (protectionActive == true)
            {
                Debug.Log("Wyłączam tarcze");
                protectionActive = false;
                _protectionPlayer.SetActive(false);
                transform.position = new Vector3(-0.04f, -3.49f, 0);
                return;
            }
            life.changeEnergyDown(1);
            Debug.Log("Usówam jedno życie");
            transform.position = new Vector3(-0.04f, -3.49f, 0);
        }
    }

    public void Move(float horizontalInput)
    {
        if (speedPower == true)
        {
            transform.Translate(Vector3.right * _speed * 1.5f * horizontalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        }
    }

    public void speedPowerUpOn()
    {
        Debug.Log("Włączam prędkość");
        speedPower = true;
        StartCoroutine(SpeedPowerDown());
    }

    public void lifePowerUpOn()
    {
        Debug.Log("Dodaje jedno życie");
        life.changeEnergyUp(1);
    }

    public void protectionPowerUpOn()
    {
        Debug.Log("Włączam osłone");
        protectionActive = true;
        _protectionPlayer.SetActive(true);
        StartCoroutine(protectionPowerDown());
    }

    IEnumerator protectionPowerDown()
    {
        yield return new WaitForSeconds(3.0f);
        protectionActive = false;
        _protectionPlayer.SetActive(false);
        Debug.Log("Wyłączam osłonę po 3s ");
    }

    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        speedPower = false;
        Debug.Log("I turned on your power");
    }

    public void Damage()
    {
        if(protectionActive == true)
        {
            Debug.Log("Wyłączam tarcze");
            protectionActive = false;
            _protectionPlayer.SetActive(false);
            return;
        }
        life.changeEnergyDown(1);
        Debug.Log("Usuwam jedno życie");
    }

    public IEnumerator DestroyPlayer()
    {
        Debug.Log("Wybuch");
        Instantiate(_explosionPlayer, transform.position, Quaternion.identity);
        var score = GetComponent<Score>();
        SaveScoreToFile(score.score);
        Destroy(gameObject);
        yield return new WaitForSeconds(2.4f);
        Application.LoadLevel(_startMenu);
    }

    public void SaveScoreToFile(int score)
    {
        string path = Application.persistentDataPath;
        System.IO.File.AppendAllText(path + "/score.txt", score.ToString() + "\r\n");
    }

}
