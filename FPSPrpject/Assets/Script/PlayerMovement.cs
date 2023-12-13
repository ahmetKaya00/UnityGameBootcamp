using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float _speed = 4f;
    public float _Xspeed = 6f;
    public float _gravity = -9.8f;
    public float _jump = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    Vector3 _velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right*x + transform.forward * z;
        characterController.Move(move * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(move * _Xspeed * Time.deltaTime);
        }


        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jump * -2f * _gravity);
        }
        _velocity.y += _gravity * Time.deltaTime;

        characterController.Move(_velocity * Time.deltaTime);
    }
}
