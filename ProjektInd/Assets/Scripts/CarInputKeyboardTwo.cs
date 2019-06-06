using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputKeyboardTwo : CarInputBase
{
    Vector3 pos;
    public GameObject menu;
    float smoothnes;

    private void Start()
    {
        pos = transform.localPosition;
        pos.x = -48;
        pos.y = -111;
        pos.z = -3;
        transform.localPosition = pos;
    }

    void Update()
    {
        if (!menu.activeSelf)
        {
            UpdateSteering();
            UpdateEnginePower();
            UseEquipment();
        }
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            smoothnes += 0.006f;
            if (smoothnes < -0.4)
            {
                smoothnes += 0.01f;
            }
            if (smoothnes > 1f)
            {
                smoothnes = 1f;
            }
            SetEnginePower(smoothnes);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            smoothnes -= 0.004f;
            if (smoothnes > 0.5)
            {
                smoothnes -= 0.01f;
            }
            if (smoothnes < -0.5f)
            {
                smoothnes = -0.5f;
            }
            SetEnginePower(smoothnes);
        }
        else
        {
            smoothnes = smoothnes * 0.99f;
        }
    }

    void UseEquipment()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            ActivateWeapon();
        }
    }
}
