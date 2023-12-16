using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrig : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Mermi._cephane != 0)
        {
            AudioSource silahSesi = GetComponent<AudioSource>();
            silahSesi.Play();
            _animator.SetBool("Trigger", true);
            Mermi._cephane -= 1;
        }
        else
        {
            _animator.SetBool("Trigger", false);
        }
    }
}
