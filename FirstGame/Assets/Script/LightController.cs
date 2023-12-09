using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightController : MonoBehaviour
{
    public UnityEvent onLightOn;
    public UnityEvent onLightOff;

    private Light lightComponent;
    private bool isLightOn = false;
    
    void Start()
    {
        lightComponent = GetComponent<Light>();
    }   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleLight();
        }
    }
    public void ToggleLight()
    {
        isLightOn = !isLightOn;
        lightComponent.enabled = isLightOn;

        if (isLightOn)
        {
            onLightOn.Invoke();
        }
        else
        {
            onLightOff.Invoke();
        }
    }
}
