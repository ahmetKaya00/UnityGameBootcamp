using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarjor : MonoBehaviour
{
    [SerializeField] private AudioSource _ses;
    public GameObject mermi, trigger;
    public int sarjor,Ysarjor,yEkran;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        sarjor = Mermi._cephane;
        Ysarjor = Mermi.yCephane;

        if(Ysarjor == 0)
        {
            yEkran = 0;
        }
        else
        {
            yEkran = 10 - sarjor;
        }

        if(sarjor <= 0)
        {
            trigger.GetComponent<AtesEtme>().enabled = false;
            mermi.GetComponent<Mermi>().enabled = false;
            _animator.SetBool("trigger", false);
        }
        else
        {
            trigger.GetComponent<AtesEtme>().enabled = true;
            mermi.GetComponent<Mermi>().enabled = true;
            _animator.SetBool("trigger", true);
        }
        if (Input.GetButtonDown("Sarjor"))
        {
            if(yEkran >= 1)
            {
                _animator.SetBool("sarjor",true);
                if(Ysarjor <= yEkran)
                {
                    Mermi._cephane += Ysarjor;
                    Mermi.yCephane -= Ysarjor;
                    ActionReload();
                }
                else
                {
                    Mermi._cephane += yEkran;
                    Mermi.yCephane -= yEkran;
                    ActionReload();
                }
            }
            StartCoroutine(EnableScript());
        }
    }

    IEnumerator EnableScript()
    {
        yield return new WaitForSeconds(1.1f);
        trigger.SetActive(true);
        _animator.SetBool("sarjor", false);
    }

    void ActionReload()
    {
        trigger.SetActive(false);
        _ses.Play();
    }
}
