using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputKeyboardTwo : CarInputBase
{
    void Update()
    {
        UpdateSteering();
        UpdateEnginePower();
    }

    void UpdateSteering()
    {
        //SetSteeringDirection(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SetSteeringDirection(-1f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SetEnginePower(1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SetEnginePower(-0.5f);
        }
    }
}
