using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level
{
    public abstract RotationType[] currentRotation { get; set; }
    public abstract Car car { get; set; }
    public abstract RotationType[] GetNextRotation();
    public abstract void ResetCar();
}