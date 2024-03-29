using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    public override RotationType[] currentRotation { get; set; }
    public override Car car { get; set; }

    public Level1(GameObject carObject) {
        currentRotation = new RotationType[1];
        car = carObject.GetComponent<Car>();
    }

    public override RotationType[] GetNextRotation() {

        RotationType randomRotation;
        do {
            randomRotation = (RotationType)UnityEngine.Random.Range(0, 6);
        } while (randomRotation == currentRotation[0] || (int)randomRotation + (int)currentRotation[0] == 5);

        RotationType[] nextRotation = new RotationType[1];
        nextRotation[0] = randomRotation;
        currentRotation = nextRotation;
        return nextRotation;
    }

    public override void ResetCar() {
        car.ResetTransform();
    }
}
