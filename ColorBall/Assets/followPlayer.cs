using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        if(_player.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,_player.position.y,transform.position.z);
        }
    }
}
