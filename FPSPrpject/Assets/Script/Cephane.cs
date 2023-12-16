using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cephane : MonoBehaviour
{
    [SerializeField] AudioSource _ses;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") { 
        _ses.Play();
        if (Mermi._cephane == 0)
        {
            Mermi._cephane += 10;
            this.gameObject.SetActive(false);
        }
        else
        {
            Mermi.yCephane += 10;
            this.gameObject.SetActive(false);

        }
        }
    }
}
