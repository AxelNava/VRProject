using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatedHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimation;
    public InputActionProperty gripAnimation;

    public Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggedValued = pinchAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger",triggedValued);
        float gripValue = gripAnimation.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
    
}
