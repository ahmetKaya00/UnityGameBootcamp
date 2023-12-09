using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jump = 10f;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    public string currentColor;

    [SerializeField] private Color colorCam, colorSari, colorPembe, colorEflatun;

    [SerializeField] Text _score,panelScore , highScore;
    private int scoreValue, panelValue;

    [SerializeField] GameObject bir, iki, uc, dort, panel;

    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _sr = GetComponent<SpriteRenderer>();
        panel.SetActive(false);
        highScore.text = PlayerPrefs.GetInt("HinghScore",0).ToString();
        RandomColor();
    }

    void Update()
    {
        _score.text = scoreValue.ToString();
        if(Input.GetButtonDown("Jump") || (Input.GetMouseButtonDown(0)))
        {
            _rb.velocity = Vector2.up * _jump;
            _rb.bodyType = RigidbodyType2D.Dynamic;
            audioSource.Play();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ColorChanger")
        {           
            bir.transform.position = transform.position + new Vector3(0f, 15f, 0f);
            collision.gameObject.transform.position = bir.transform.position + new Vector3(0f, 2f, 0f);
            scoreValue++;
            panelValue++;
            panelScore.text = panelValue.ToString();
            if (panelValue > PlayerPrefs.GetInt("HinghScore", 0))
            {
                PlayerPrefs.SetInt("HinghScore", panelValue);
                highScore.text = panelScore.ToString(); ;
            }
            RandomColor();
            return;
        }
        if (collision.tag == "ColorChanger2")
        {            
            iki.transform.position = transform.position + new Vector3(0f, 15f, 0f);
            collision.gameObject.transform.position = iki.transform.position + new Vector3(0f, 2f, 0f);
            scoreValue++;
            panelValue++;
            panelScore.text = panelValue.ToString();
            if (panelValue > PlayerPrefs.GetInt("HinghScore", 0))
            {
                PlayerPrefs.SetInt("HinghScore", panelValue);
                highScore.text = panelScore.ToString(); ;
            }
            RandomColor();
            return;
        }
        if (collision.tag == "ColorChanger3")
        {           
            uc.transform.position = transform.position + new Vector3(0f, 15f, 0f);
            dort.transform.position = transform.position + new Vector3(0f, 15f, 0f);
            collision.gameObject.transform.position = uc.transform.position + new Vector3(0f, 2f, 0f);
            scoreValue++;
            panelValue++;
            panelScore.text = panelValue.ToString();
            if(panelValue > PlayerPrefs.GetInt("HinghScore", 0))
            {
                PlayerPrefs.SetInt("HinghScore", panelValue);
                highScore.text = panelValue.ToString(); ;
            }
            RandomColor();
            return;
        }
        if (collision.tag != currentColor)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    void RandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "cam"; 
                _sr.color = colorCam;
                break;
            case 1:
                currentColor = "sari"; 
                _sr.color = colorSari;
                break;
            case 2:
                currentColor = "pembe";
                _sr.color = colorPembe;
                break;
            case 3:
                currentColor = "eflatun";
                _sr.color= colorEflatun;
                break;
        }
    }
}
