using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    [SerializeField] int DusmanSagligi = 10;
    public GameObject _zombi;

    public void dusman(int HasarMiktari)
    {
        DusmanSagligi -= HasarMiktari;
    }

    private void Update()
    {
        if(DusmanSagligi <= 0)
        {
            
            _zombi.GetComponent<Animator>().SetBool("Dyling", true);
            _zombi.GetComponent<Animator>().SetBool("Walking", false);
            _zombi.GetComponent<Animator>().SetBool("Attacking", false);
            Invoke("zombiOlum", 3);
        }
    }

    void zombiOlum()
    {
        Destroy(gameObject);
    }


}
