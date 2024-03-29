using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerInputControllerObject;

    private InputManager _playerInputController;

    private void Awake() {
        _playerInputController = PlayerInputControllerObject.GetComponent<InputManager>();
    }

    private void OnEnable() {
        _playerInputController.DisabelActions();
    }

    private void OnDisable() {
        _playerInputController.EnableActions();
    }
}
