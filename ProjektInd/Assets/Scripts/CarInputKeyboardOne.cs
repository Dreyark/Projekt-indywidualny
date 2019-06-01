using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputKeyboardOne : CarInputBase
{
    void Update()
    {
        UpdateSteering();
        UpdateEnginePower();
    }

    void UpdateSteering()
    {
        //SetSteeringDirection(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKey(KeyCode.A))
        {
            SetSteeringDirection(-1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            SetSteeringDirection(1f);
        }
        else
        {
            SetSteeringDirection(0);
        }
    }
    void UpdateEnginePower()
    {
        //SetEnginePower(Input.GetAxisRaw("Vertical"));
        if (Input.GetKey(KeyCode.W))
        {
            SetEnginePower(1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            SetEnginePower(-0.5f);
        }
    }
}
