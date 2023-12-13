using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FareTUZerinde : MonoBehaviour
{
    public float Mesafe = PlayDokumantansyon.HedefMesafe;
    public GameObject YaziGoster;

    private void Update()
    {
        Mesafe = PlayDokumantansyon.HedefMesafe;
    }

    private void OnMouseOver()
    {
        if(Mesafe < 2)
        {
            YaziGoster.GetComponent<Text>().text = "Silahý Al";
        }
    }

    private void OnMouseExit()
    {
        YaziGoster.GetComponent<Text>().text = "";
    }
}
