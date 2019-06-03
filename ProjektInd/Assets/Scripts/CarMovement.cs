using System;
using System.Collections;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float MaximumReverseEngineForce;
    public float MaximumSteeringTorque;
    public float MaximumEngineForce;
    public float ReversePower;
    public float Acceleration;
    public float Deacceleration;


    float m_EnginePower = 0f;
    float m_SteeringDirection = 0f;
    float m_TargetEnginePower = 0f;
    float m_CurrentMaximumEnginePower = 0.9f;
    float StartCountingTime;
    float DeltaTime;
    bool isTimerOn = false;
    int equipment = 0;
    int ChangeSteeringKeys = 1;
    Transform CarPos;

    public Deployer deployer;
    Rigidbody2D m_Body;

    void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CarPos = transform;
        UpdateEnginePower();
        Timer();
    }

    void UpdateEnginePower()
    {
        float acceleration = Acceleration;

        if (m_TargetEnginePower == 0f)
        {
            acceleration = Deacceleration;
        }

        float targetEnginePower = m_TargetEnginePower * m_CurrentMaximumEnginePower;

        m_EnginePower = Mathf.MoveTowards(m_EnginePower, targetEnginePower, acceleration * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteeringForce();
    }
    void ApplyEngineForce()
    {
        float maximumEngineForce = MaximumEngineForce;

        if (m_EnginePower < 0f)
        {
            maximumEngineForce = MaximumReverseEngineForce;
        }

        m_Body.AddForce(-transform.right * m_EnginePower * m_CurrentMaximumEnginePower * MaximumEngineForce, ForceMode2D.Force);
    }
    void ApplySteeringForce()
    {
        m_Body.AddTorque(-m_SteeringDirection * MaximumSteeringTorque, ForceMode2D.Force);
    }

    public void SetEnginePower(float engineForce)
    {
        m_EnginePower = Mathf.Clamp(engineForce, -1f, 1f);
    }

    public void SetSteeringDirection(float steeringDirection)
    {
        m_SteeringDirection = Mathf.Clamp(steeringDirection, -1f, 1f) * ChangeSteeringKeys;
    }

    void Timer()
    {
        if (isTimerOn == true)
        {
            DeltaTime = Time.realtimeSinceStartup - StartCountingTime;
            if (DeltaTime > 3)
            {
                isTimerOn = false;
                m_CurrentMaximumEnginePower = 1;
            }
            else
            {
                m_CurrentMaximumEnginePower = 0;
            }
        }
    }

    public void OnCollideWithObstacle()
    {
        m_EnginePower = 0f;
    }

    public void OnEnterOil()
    {
        ChangeSteeringKeys = -3;
    }

    public void OnCollideWithBomb()
    {
        isTimerOn = true;
        StartCountingTime = Time.realtimeSinceStartup;

    }

    public void OnExitOffOil()
    {
        ChangeSteeringKeys = 1;
    }

    public void OnEnterOffCourseArea()
    {
        m_CurrentMaximumEnginePower = 0.6f;
    }

    public void OnExitOffCourseArea()
    {
        m_CurrentMaximumEnginePower = 1f;
    }

    public void OnEnterBox()
    {
        System.Random rnd = new System.Random();
        equipment = rnd.Next(1, 3); // 1 - boost 2 - oil
        Debug.Log(equipment);

    }

    public void UseEquipment()
    {
        if (equipment == 1)
        {
            deployer.SetOil(CarPos);
            equipment = 0;
        }
        else if (equipment == 2)
        {
            deployer.SetBomb(CarPos);
            equipment = 0;
        }
        else
        {
        }
    }
    void BoostTime(int Time)
    {

    }

}
