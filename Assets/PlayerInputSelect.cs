using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSelect : MonoBehaviour
{
    public string Scheme;
    public void OnJoined(PlayerInput input)
    {
        input.gameObject.GetComponent<InputManager>().Scheme = Scheme;
    }
}
