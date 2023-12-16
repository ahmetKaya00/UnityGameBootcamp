using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    public GameObject Karakter, _zombi;
    public float HedefUzakligi, islemUzakligi = 10, zombiHiz;
    public int SaldiriTetikleyici;
    public RaycastHit Atis;
    public AudioSource _ses;

    public int Saldiri;
    public GameObject EkranFlas;
    public AudioSource hurt, hurt1, hurt2;
    public int VurmaSesi;

    private void Update()
    {
        transform.LookAt(Karakter.transform);
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out Atis))
        {           
            HedefUzakligi = Atis.distance;
            if(HedefUzakligi < islemUzakligi)
            {              
                zombiHiz = 0.2f;
                if(SaldiriTetikleyici == 0)
                {
                    Debug.Log("göründün");
                    _zombi.GetComponent<Animator>().SetBool("Walking", true);
                    _zombi.GetComponent<Animator>().SetBool("Attacking", false);
                    _ses.Play();
                    transform.position = Vector3.MoveTowards(transform.position, Karakter.transform.position, zombiHiz);
                    Saldiri = 0;
                }
                else
                {
                    zombiHiz = 0;
                    _zombi.GetComponent<Animator>().SetBool("Attacking", false);
                    _zombi.GetComponent<Animator>().SetBool("Walking", false);
                    transform.position = Vector3.MoveTowards(transform.position, Karakter.transform.position, zombiHiz);
                }
                if (SaldiriTetikleyici == 1)
                {
                    if (Saldiri == 0)
                    {
                        StartCoroutine(dusmanHasar());
                    }
                    zombiHiz = 0;
                    _zombi.GetComponent<Animator>().SetBool("Attacking", true);
                    _zombi.GetComponent<Animator>().SetBool("Walking", false);
                    transform.position = Vector3.MoveTowards(transform.position, Karakter.transform.position, zombiHiz);
                    Debug.Log("tetiklendin");
                }
            }           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            SaldiriTetikleyici = 1;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SaldiriTetikleyici = 0;
    }
    IEnumerator dusmanHasar()
    {
        Saldiri = 1;
        VurmaSesi = Random.Range(1,4);
        yield return new WaitForSeconds(0.9f);
        EkranFlas.SetActive(true);
        KalanCan.OyuncuCan -= 1;
        if(VurmaSesi == 1)
        {
            hurt.Play();
        }
        if (VurmaSesi == 2)
        {
            hurt1.Play();
        }
        if (VurmaSesi == 3)
        {
            hurt2.Play();
        }
        yield return new WaitForSeconds(0.05f);
        EkranFlas.SetActive(false);
        yield return new WaitForSeconds(1);
        Saldiri = 1;
    }
}
