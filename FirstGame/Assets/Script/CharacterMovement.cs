using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private bool isMovementEnable = true;    
    public void SetMovementEnabled(bool isEnable)
    {
        isMovementEnable = isEnable;
    }
    private void OnEnable()
    {
        //eventa abone olundu
        FindObjectOfType<LightController>().onLightOn.AddListener(EnableMovement);
        FindObjectOfType<LightController>().onLightOff.AddListener(DisableMovement);
    }
    private void OnDisable()
    {
        //event aboneliði kalktý
        FindObjectOfType<LightController>().onLightOn.RemoveListener(EnableMovement);
        FindObjectOfType<LightController>().onLightOff.RemoveListener(DisableMovement);
    }
    
    private void EnableMovement()
    {
        isMovementEnable = true;
    }
    private void DisableMovement()
    {
        isMovementEnable = false;
        Debug.Log("Lamba kapalý olduðu için hareket edemezsin");
    }

    private void Update()
    {
        if (isMovementEnable) {

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3 (horizontalInput, 0.0f,verticalInput)*Time.deltaTime;
            transform.Translate(movement);
        
        }
    }
}
