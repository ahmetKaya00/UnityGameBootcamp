using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject _sah;

    private GameObject[,] _position = new GameObject[8, 8];
    private GameObject[] siyahTakim = new GameObject[16];
    private GameObject[] beyazTakim = new GameObject[16];

    private string mevcutOyuncu = "beyaz";

    private bool gameOver = false;
    void Start()
    {
        siyahTakim = new GameObject[] { Create("siyah_kale", 0, 0), Create("siyah_at", 1, 0), Create("siyah_fil", 2, 0), Create("siyah_vezir", 3, 0), Create("siyah_sah", 4, 0), Create("siyah_fil", 5, 0), Create("siyah_at", 6, 0), Create("siyah_kale", 7, 0), Create("siyah_piyon", 0, 1), Create("siyah_piyon", 1, 1), Create("siyah_piyon", 2, 1), Create("siyah_piyon", 3, 1), Create("siyah_piyon", 4, 1), Create("siyah_piyon", 5, 1), Create("siyah_piyon", 6, 1), Create("siyah_piyon", 7, 1)};
        beyazTakim = new GameObject[] { Create("beyaz_kale", 0, 7), Create("beyaz_at", 1, 7), Create("beyaz_fil", 2, 7), Create("beyaz_vezir", 3, 7), Create("beyaz_sah", 4, 7), Create("beyaz_fil", 5, 7), Create("beyaz_at", 6, 7), Create("beyaz_kale", 7, 7), Create("beyaz_piyon", 0, 6), Create("beyaz_piyon", 1, 6), Create("beyaz_piyon", 2, 6), Create("beyaz_piyon", 3, 6), Create("beyaz_piyon", 4, 6), Create("beyaz_piyon", 5, 6), Create("beyaz_piyon", 6, 6), Create("beyaz_piyon", 7, 6) };

        for(int i = 0; i < siyahTakim.Length; i++)
        {
            SetPosition(siyahTakim[i]);
            SetPosition(beyazTakim[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(_sah,new Vector3(0,0,-1), Quaternion.identity);
        Karakter krt = obj.GetComponent<Karakter>();
        krt.name = name;
        krt.SetXTahta(x);
        krt.SetYTahta(y);
        krt.Etkinlestir();
        return obj;
    }
    public void SetPosition(GameObject obj)
    {
        Karakter ob = obj.GetComponent<Karakter>();
        _position[ob.GetXTahta(), ob.GetYTahta()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        _position[x, y] = null;
    }
    public GameObject GetPosition(int x, int y)
    {
        return _position[x, y];
    }

    public bool PositionOnboard(int x, int y)
    {
        if(x<0 || y<0 || x>=_position.GetLength(0)||y>=_position.GetLength(1)) return false;
        return true;
    }
    public string GetCurrentPlayer()
    {
        return mevcutOyuncu;
    }
    public bool IsGameOver()
    {
        return gameOver;
    }
    public void NextTurn()
    {
        if(mevcutOyuncu == "beyaz")
        {
            mevcutOyuncu = "siyah";
        }
        else
        {
            mevcutOyuncu = "beyaz";
        }
    }
    private void Update()
    {
        if(gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

            SceneManager.LoadScene("Game");
        }
    }
    public void Winner(string playerWinner)
    {
        gameOver = true;
        GameObject.FindGameObjectWithTag("Winner").GetComponent<TMP_Text>().enabled = true;
        GameObject.FindGameObjectWithTag("Winner").GetComponent<TMP_Text>().text = playerWinner + "Kazandý!";
        GameObject.FindGameObjectWithTag("Restart").GetComponent<TMP_Text>().enabled = true;
    }
}
