using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject _sah;
    void Start()
    {
        Instantiate(_sah, new Vector3(0, 0, -1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
