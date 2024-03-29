using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance = null;

    public PlayerInput PlayerInput;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if(Instance == this) {
            Destroy(gameObject);
        }

        PlayerInput = GetComponent<PlayerInput>();
    }

    private void Start() {
        PlayerInput.actions["Pause"].performed += Test;
        PlayerInput.actions["Pause"].performed += OnPause;
    }

    private void Test(InputAction.CallbackContext context) {
        Debug.Log(context.ToString());
    }

    public void DisabelActions() {
        foreach (var action in PlayerInput.actions) {
            action.Disable();
        }
    }

    public void EnableActions() {
        foreach(var action in PlayerInput.actions) {
            action.Enable();
        }
    }

    public void OnLeftAirRoll(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("Left Air Roll");
        }
    }

    public void OnRightAirRoll(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("Right Air Roll");
        }
    }

    public void OnLeftSpin(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("Left Spin");
        }
    }

    public void OnRightSpin(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("Right Spin");
        }
    }

    public void OnFrontSpin(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("Front Spin");
        }
    }

    public void OnBackSpin(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("Back Spin");
        }
    }

    public void OnPause(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("Pause");
        }
    }
}
