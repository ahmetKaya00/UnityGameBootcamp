using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    [SerializeField]
    private GameObject _controller, _hareket;

    private int xTahta = -1, yTahta = -1;

    private string _player;

    public Sprite siyah_sah, siyah_vezir, siyah_at, siyah_kale, siyah_fil, siyah_piyon;
    public Sprite beyaz_sah, beyaz_vezir, beyaz_at, beyaz_kale, beyaz_fil, beyaz_piyon;


    public void Etkinlestir()
    {
        _controller = GameObject.FindGameObjectWithTag("GameController");

        Koordinat();

        switch (this.name)
        {
            case "siyah_sah": this.GetComponent<SpriteRenderer>().sprite = siyah_sah; _player = "siyah"; break;
            case "siyah_vezir": this.GetComponent<SpriteRenderer>().sprite = siyah_vezir; _player = "siyah"; break;
            case "siyah_at": this.GetComponent<SpriteRenderer>().sprite = siyah_at; _player = "siyah"; break;
            case "siyah_kale": this.GetComponent<SpriteRenderer>().sprite = siyah_kale; _player = "siyah"; break;
            case "siyah_fil": this.GetComponent<SpriteRenderer>().sprite = siyah_fil; _player = "siyah"; break;
            case "siyah_piyon": this.GetComponent<SpriteRenderer>().sprite = siyah_piyon; _player = "siyah"; break;
            case "beyaz_sah": this.GetComponent<SpriteRenderer>().sprite = beyaz_sah; _player = "beyaz"; break;
            case "beyaz_vezir": this.GetComponent<SpriteRenderer>().sprite = beyaz_vezir; _player = "beyaz"; break;
            case "beyaz_at": this.GetComponent<SpriteRenderer>().sprite = beyaz_at; _player = "beyaz"; break;
            case "beyaz_kale": this.GetComponent<SpriteRenderer>().sprite = beyaz_kale; _player = "beyaz"; break;
            case "beyaz_fil": this.GetComponent<SpriteRenderer>().sprite = beyaz_fil; _player = "beyaz"; break;
            case "beyaz_piyon": this.GetComponent<SpriteRenderer>().sprite = beyaz_piyon; _player = "beyaz"; break;
        }
    }

    public void Koordinat()
    {
        float x = xTahta;
        float y = yTahta;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1);
    }
    public int GetXTahta()
    {
        return xTahta;
    }
    public int GetYTahta()
    {
        return yTahta;
    }

    public void SetXTahta(int x)
    {
        xTahta = x;
    }
    public void SetYTahta(int y)
    {
        yTahta = y;
    }
    private void OnMouseUp()
    {
        if (!_controller.GetComponent<Game>().IsGameOver() && _controller.GetComponent<Game>().GetCurrentPlayer() == _player)
        {
            DestroyMovePlate();
            intiateMovePlate();

        }
    }
    public void DestroyMovePlate()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void intiateMovePlate()
    {
        switch (this.name)
        {
            case "siyah_vezir":
            case "beyaz_vezir":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(0, -1);
                LineMovePlate(-1, 0);
                LineMovePlate(-1, -1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1); break;
            case "siyah_at":
            case "beyaz_at":
                LMovePlate(); break;
            case "siyah_fil":
            case "beyaz_fil":
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(1, 1);break;
            case "siyah_sah":
            case "beyaz_sah":
                SurroundMovePlate();break;
            case "siyah_kale":
            case "beyaz_kale":
                LineMovePlate(1,0);
                LineMovePlate(0,1);
                LineMovePlate(0,-1);
                LineMovePlate(-1,0);break;
            case "siyah_piyon":
                PiyonMovePlate(xTahta, yTahta - 1);break;
            case "beyaz_piyon":
                PiyonMovePlate(xTahta, yTahta + 1);break;
        }
    }
    public void LineMovePlate(int xIntrement,int yIntrement)
    {
        Game sc = _controller.GetComponent<Game>();
        int x = xTahta + xIntrement;
        int y = yTahta + yIntrement;
        while (sc.PositionOnboard(x, y) && sc.GetPosition(x, y) == null)
        {
            MovePlateSpawn(x,y);
            x += xIntrement;
            y += yIntrement;
        }
        if(sc.PositionOnboard(x,y) && sc.GetPosition(x, y).GetComponent<Karakter>()._player != _player)
        {
            MovePlateAttackSpawn(x, y);
        }
    }
    public void LMovePlate()
    {
        PointMovePlate(xTahta + 1, yTahta + 2);
        PointMovePlate(xTahta - 1, yTahta + 2);
        PointMovePlate(xTahta + 1, yTahta - 2);
        PointMovePlate(xTahta + 2, yTahta - 1);
        PointMovePlate(xTahta + 2, yTahta + 1);
        PointMovePlate(xTahta - 2, yTahta - 1);
        PointMovePlate(xTahta - 1, yTahta - 2);
        PointMovePlate(xTahta - 2, yTahta + 1);

    }
    public void SurroundMovePlate()
    {
        PointMovePlate(xTahta, yTahta + 1);
        PointMovePlate(xTahta, yTahta - 1);
        PointMovePlate(xTahta-1, yTahta);
        PointMovePlate(xTahta-1, yTahta-1);
        PointMovePlate(xTahta-1, yTahta+1);
        PointMovePlate(xTahta+1, yTahta-1);
        PointMovePlate(xTahta+1, yTahta+1);
        PointMovePlate(xTahta+1, yTahta);
    }

    //Burasý Kontrol Edilecek!!!!
    public void PointMovePlate(int x, int y)
    {
        Game sc = _controller.GetComponent<Game>();
        if (sc.PositionOnboard(x, y))
        {
            if (sc.GetPosition(x,y) == null)
            {
                MovePlateSpawn(x,y);

            } else if (sc.GetComponent<Karakter>()._player != _player)
            {
                MovePlateAttackSpawn(x, y);
            }

        }
    }
    public void PiyonMovePlate(int x, int y)
    {
        Game sc = _controller.GetComponent<Game>();
        if (sc.PositionOnboard(x, y))
        {
            if (sc.GetPosition(x, y) == null)
            {
                MovePlateSpawn(x, y);
            }
            if (sc.PositionOnboard(x + 1, y) && sc.GetPosition(x + 1, y) != null && sc.GetPosition(x + 1, y).GetComponent<Karakter>()._player != _player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }
            if (sc.PositionOnboard(x - 1, y) && sc.GetPosition(x + 1, y) != null && sc.GetPosition(x + 1, y).GetComponent<Karakter>()._player != _player)
            {
                MovePlateAttackSpawn(x - 1, y);
            }
        }
    }
    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = xTahta;
        float y = yTahta;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(_hareket, new Vector3(x, y, -3.0f), Quaternion.identity);
        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReferance(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = xTahta;
        float y = yTahta;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(_hareket, new Vector3(x, y, -3.0f), Quaternion.identity);
        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReferance(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }


}
