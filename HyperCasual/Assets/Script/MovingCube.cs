using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube {  get; private set; }
    public static MovingCube LastCube { get; private set; }
    public MoveDirection MoveDirection { get;  set; }

    [SerializeField] float moveSpeed = 1f;

    private void OnEnable()
    {
        if(LastCube == null)
            LastCube = GameObject.Find("Start").GetComponent<MovingCube>();
        CurrentCube = this;

        GetComponent<Renderer>().material.color = GetRandomColor();

        transform.localScale = new Vector3(LastCube.transform.localScale.x, transform.localScale.y, LastCube.transform.localScale.z);

    }

    Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f),UnityEngine.Random.Range(0, 1f));
    }
    internal void Stop()
    {
        moveSpeed = 0f;
        float BreakZ = GetBreak();


        float max = MoveDirection == MoveDirection.X ? LastCube.transform.localScale.z : LastCube.transform.localScale.x;
        if (Mathf.Abs(BreakZ) >= max)
        {
            LastCube = null;
            CurrentCube = null;
            SceneManager.LoadScene(0);
        }

        float direction = BreakZ > 0 ? 1f : -1f;
        if (MoveDirection == MoveDirection.Z)
            SplitCubeOnZ(BreakZ, direction);
        else
            SplitCubeOnX(BreakZ, direction);
        LastCube = this;
    }

    private float GetBreak()
    {
        if (MoveDirection == MoveDirection.Z)
            return transform.position.z - LastCube.transform.position.z;
        else
            return transform.position.x - LastCube.transform.position.x;
    }

    void SplitCubeOnZ(float breakZ, float direction)
    {
        float newSize = LastCube.transform.localScale.z - Mathf.Abs(breakZ);
        float fallingBlockSize = transform.localScale.z - newSize;
        float newPosition = LastCube.transform.localPosition.z + (breakZ / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newPosition);

        float cubeEgde = transform.position.z + (newSize / 2 * direction);
        float fallingBlockPos = cubeEgde + fallingBlockSize / 2f * direction;

        DropCube(fallingBlockSize, fallingBlockPos);

    }
    void SplitCubeOnX(float breakZ, float direction)
    {
        float newXSize = LastCube.transform.localScale.x - Mathf.Abs(breakZ);
        float fallingBlockSize = transform.localScale.x - newXSize;
        float newXPosition = LastCube.transform.localPosition.x + (breakZ / 2);
        transform.localScale = new Vector3(newXSize,transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(newXPosition,transform.position.y, transform.position.z);

        float cubeEgde = transform.position.x + (newXSize / 2 * direction);
        float fallingXBlockPos = cubeEgde + fallingBlockSize / 2f * direction;

        DropCube(fallingBlockSize, fallingXBlockPos);

    }
    void DropCube(float fallingBlockSize, float fallingBlockPos)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        if (MoveDirection == MoveDirection.Z) { 
            cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
            cube.transform.position = new Vector3(transform.position.x,transform.position.y, fallingBlockPos);
        }
        else
        {
            cube.transform.localScale = new Vector3(fallingBlockSize,transform.localScale.y, transform.localScale.z);
            cube.transform.position = new Vector3(fallingBlockPos,transform.position.y, transform.position.z);
        }
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        Destroy(cube.gameObject, 1f);
    }
    private void Update()
    {
        if(MoveDirection == MoveDirection.Z)
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        else
            transform.position += transform.right * Time.deltaTime * moveSpeed;
    }
}
