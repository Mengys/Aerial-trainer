using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _carObject;
    [SerializeField] private GameObject _LevelMenu;


    private Level _level;
    private RotationType[] _currentRotations;
    private List<RotationType> _inputList = new List<RotationType>();


    private void Start() {
        InputManager.Instance.PlayerInput.actions["Pause"].performed += Pause;

    }

    public void LoadLevel1() {
        Debug.Log("Load level 1");

        InputManager.Instance.PlayerInput.actions["Start"].performed += StartGame;
        _level = new Level1(_carObject);

        Debug.Log("Level 1 loaded");
    }

    public void LoadLevel2() {
        Debug.Log("Load level 2");

        InputManager.Instance.PlayerInput.actions["Start"].performed += StartGame;
        _level = new Level2(_carObject);

        Debug.Log("Level 2 loaded");
    }

    private void UnloadLevel() {
        InputManager.Instance.PlayerInput.actions["Start"].performed -= StartGame;
        _carObject.GetComponent<Car>().ResetTransform();
        _level = null;
    }

    private void StartGame(InputAction.CallbackContext context) {
        Debug.Log("Game started");
        InputManager.Instance.PlayerInput.actions["Start"].performed -= StartGame;

        StartRound();
        StartRegisteringInput();
    }

    private void Pause(InputAction.CallbackContext context) {
        UnloadLevel();
        _LevelMenu.SetActive(true);
    }

    private void StartRound() {
        Debug.Log("Start round");
        _currentRotations = _level.GetNextRotation();
        _carObject.GetComponent<Car>().SetCarRotation(_currentRotations);
    }

    private void NextRound() {
        _level.ResetCar();


    }

    private void Restart() {
        _level.ResetCar();


    }

    private void PrepareForRound() {
        _level.ResetCar();
        _inputList.Clear();
    }

    private void CheckInput() {
        int count = _currentRotations.Length;
        //bug if all buttons pressed in one frame
        foreach(var rotation in _currentRotations) {
            if (!_inputList.Contains(rotation)) {
                Restart();
            } else {
                count--;
            }
        }
        if (count == 0) {
            RoundComplete();
        }
        //start timer for next input if rotations > 1
    }

    private void RoundComplete() {
        PrepareForRound();
        StartRound();
    }

    private void StartRegisteringInput() {
        InputManager.Instance.PlayerInput.actions["LeftAirRoll"].performed += RegisterInputAirRollLeft;
        InputManager.Instance.PlayerInput.actions["RightAirRoll"].performed += RegisterInputAirRollRight;
        InputManager.Instance.PlayerInput.actions["LeftSpin"].performed += RegisterInputLeftSpin;
        InputManager.Instance.PlayerInput.actions["RightSpin"].performed += RegisterInputRightSpin;
        InputManager.Instance.PlayerInput.actions["FrontSpin"].performed += RegisterInputFrontSpin;
        InputManager.Instance.PlayerInput.actions["BackSpin"].performed += RegisterInputBackSpin;
    }    
    
    private void StopRegisteringInput() {
        InputManager.Instance.PlayerInput.actions["LeftAirRoll"].performed -= RegisterInputAirRollLeft;
        InputManager.Instance.PlayerInput.actions["RightAirRoll"].performed -= RegisterInputAirRollRight;
        InputManager.Instance.PlayerInput.actions["LeftSpin"].performed -= RegisterInputLeftSpin;
        InputManager.Instance.PlayerInput.actions["RightSpin"].performed -= RegisterInputRightSpin;
        InputManager.Instance.PlayerInput.actions["FrontSpin"].performed -= RegisterInputFrontSpin;
        InputManager.Instance.PlayerInput.actions["BackSpin"].performed -= RegisterInputBackSpin;
    }

    private void RegisterInputFrontSpin(InputAction.CallbackContext context) {
        if (context.performed) {
            _inputList.Add(RotationType.Front);
            CheckInput();
        }
    }

    private void RegisterInputBackSpin(InputAction.CallbackContext context) {
        if (context.performed) {
            _inputList.Add(RotationType.Back);
            CheckInput();
        }
    }

    private void RegisterInputRightSpin(InputAction.CallbackContext context) {
        if (context.performed) {
            _inputList.Add(RotationType.Right);
            CheckInput();
        }
    }

    private void RegisterInputLeftSpin(InputAction.CallbackContext context) {
        if (context.performed) {
            _inputList.Add(RotationType.Left);
            CheckInput();
        }
    }

    private void RegisterInputAirRollLeft(InputAction.CallbackContext context) {
        if (context.performed) {
            _inputList.Add(RotationType.AirRollLeft);
            CheckInput();
        }
    }

    private void RegisterInputAirRollRight(InputAction.CallbackContext context) {
        if (context.performed) {
            _inputList.Add(RotationType.AirRollRight);
            CheckInput();
        }
    }
}
