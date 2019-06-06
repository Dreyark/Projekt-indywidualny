using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputKeyboardOne : CarInputBase
{
    Vector3 pos;
    public GameObject menu;
    float smoothnes;

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
        if (!menu.activeSelf)
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
        else if (Input.GetKey(KeyCode.S))
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
        if (Input.GetKey(KeyCode.Space))
        {
            ActivateWeapon();
        }
    }

    void OpenMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
