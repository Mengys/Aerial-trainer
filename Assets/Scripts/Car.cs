using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Car : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 360f;

    Dictionary<RotationType, Action> actions = new Dictionary<RotationType, Action>();

    public event Action RotateCar;

    private void Start() {
        actions.Add(RotationType.Front, RotateFront);
        actions.Add(RotationType.AirRollLeft, RotateAirRollLeft);
        actions.Add(RotationType.Left, RotateLeft);
        actions.Add(RotationType.Right, RotateRight);
        actions.Add(RotationType.AirRollRight, RotateAirRollRight);
        actions.Add(RotationType.Back, RotateBack);
    }

    void Update() {
        RotateCar?.Invoke();
    }

    public void SetCarRotation(RotationType[] rotations) {
        RotateCar = null;
        foreach (RotationType rotation in rotations) {
            actions.TryGetValue(rotation, out Action action);
            RotateCar += action;
        }
    }

    private void RotateFront() {
        transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
    }

    private void RotateBack() {
        transform.Rotate(Vector3.back, _rotationSpeed * Time.deltaTime);
    } 

    private void RotateRight() {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }

    private void RotateLeft() {
        transform.Rotate(Vector3.down, _rotationSpeed * Time.deltaTime);
    }  

    private void RotateAirRollLeft() {
        transform.Rotate(Vector3.left, _rotationSpeed * Time.deltaTime);
    } 

    private void RotateAirRollRight() {
        transform.Rotate(Vector3.right, _rotationSpeed * Time.deltaTime);
    }
    
    public void ResetTransform() {
        transform.eulerAngles = Vector3.zero;
        StopRotation();
    }

    public void StopRotation() {
        RotateCar = null;
    }
}
