using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnCubespawner = delegate { };
    private Respawn[] _spawners;
    private int spawnIndex;
    private Respawn CurrentSpawn;

    private void Awake()
    {
        _spawners = FindObjectsOfType<Respawn>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
               if(MovingCube.CurrentCube != null)
                    MovingCube.CurrentCube.Stop();
                spawnIndex = spawnIndex == 0 ? 1 : 0;
                CurrentSpawn = _spawners[spawnIndex];

                CurrentSpawn.SpawnCube();
                OnCubespawner();
            }
        }
    }
}
