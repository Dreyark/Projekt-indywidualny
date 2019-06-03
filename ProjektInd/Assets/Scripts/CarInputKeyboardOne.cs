using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputKeyboardOne : CarInputBase
{
    Vector3 pos;
    public Menu menu;

    private void Start()
    {
        pos = transform.localPosition;
        pos.x = -48;
        pos.y = -106;
        pos.z = -3;
        transform.localPosition = pos;
    }

    void Update()
    {
        if (!menu.gameObject.activeSelf)
        {
            UpdateSteering();
            UpdateEnginePower();
            UseEquipment();
            OpenMenu();
        }
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

    void UseEquipment()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ActivateWeapon();
        }
    }

    void  OpenMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menu.gameObject.SetActive(!menu.gameObject.activeSelf);
        }
    }
}
