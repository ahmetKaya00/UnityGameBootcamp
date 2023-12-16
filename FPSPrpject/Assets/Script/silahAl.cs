using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silahAl : MonoBehaviour
{
    public float Mesafe = PlayDokumantansyon.HedefMesafe;
    public GameObject yazi, anaSilah, yedekSilah, cephane;
    public AudioSource almaSesi;


    private void Start()
    {
        yazi.SetActive(false);
        anaSilah.SetActive(false);
        cephane.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("silahAl"))
        {
            if(Mesafe <= 2)
            {
                silahAlindi();
            }
        }
    }

    void silahAlindi()
    {
        almaSesi.Play();
        transform.position = new Vector3 (0,-50,0);
        yedekSilah.SetActive (true);
        anaSilah.SetActive (true);
        cephane.SetActive (true);
        yazi.SetActive (true);
    }
}
