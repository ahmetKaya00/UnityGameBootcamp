using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesEtme : MonoBehaviour
{
    [SerializeField]
    private int HasarMiktari = 5;
    [SerializeField]
    private float HedefUzakligi, VerilenUzaklik = 15;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit Atis;
            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out Atis))
            {
                HedefUzakligi = Atis.distance;
                if(HedefUzakligi < VerilenUzaklik)
                {
                    Atis.transform.SendMessage("dusman", HasarMiktari);
                }
            }

        }
    }
}
