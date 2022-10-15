using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager inputManager;
    private LocomotionManager locomotionManager;
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        locomotionManager = GetComponent<LocomotionManager>();
    }

    void Update()
    {
        if(inputManager.enabled)
            inputManager.HandleInput();
    }
    private void FixedUpdate()
    {
        if(locomotionManager.enabled)
            locomotionManager.HandleLocomotion();
    }

}
