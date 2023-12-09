using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 100f;
    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
