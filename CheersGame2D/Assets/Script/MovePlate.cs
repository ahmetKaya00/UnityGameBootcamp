using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject _conroller;
    GameObject _referans = null;
    int matrixX;
    int matrixY;
    public bool attack = false;
    void Start()
    {
        if(attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        _conroller = GameObject.FindGameObjectWithTag("GameController");

        if (attack)
        {
            GameObject cp = _conroller.GetComponent<Game>().GetPosition(matrixX, matrixY);
            if (cp.name == "beyaz_sah") _conroller.GetComponent<Game>().Winner("siyah");
            if (cp.name == "siyah_sah") _conroller.GetComponent<Game>().Winner("beyaz");
            Destroy(cp);
        }
        _conroller.GetComponent<Game>().SetPositionEmpty(_referans.GetComponent<Karakter>().GetXTahta(), _referans.GetComponent<Karakter>().GetYTahta());
        _referans.GetComponent<Karakter>().Koordinat();

        _conroller.GetComponent<Game>().SetPosition(_referans);
        _conroller.GetComponent<Game>().NextTurn();
        _referans.GetComponent<Karakter>().DestroyMovePlate();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }
    public void SetReferance(GameObject obj)
    {
        _referans = obj;
    }
    public GameObject GetReferance()
    {
        return _referans;
    }
}
