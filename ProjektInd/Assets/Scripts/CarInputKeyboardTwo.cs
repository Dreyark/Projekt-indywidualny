using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputKeyboardTwo : CarInputBase
{
    Vector3 pos;
    public GameObject menu;

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

    void UseEquipment()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            ActivateWeapon();
        }
    }
}
