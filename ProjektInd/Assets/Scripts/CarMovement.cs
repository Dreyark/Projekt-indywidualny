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

    Rigidbody2D m_Body;
    void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateEnginePower();
    }

    void UpdateEnginePower()
    {
        float acceleration = Acceleration;

        if(m_TargetEnginePower == 0f)
        {
            acceleration = Deacceleration;
        }

        m_EnginePower = Mathf.MoveTowards(m_EnginePower, m_TargetEnginePower, acceleration * Time.deltaTime);
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

        m_Body.AddForce(-transform.right * m_EnginePower * MaximumEngineForce, ForceMode2D.Force);
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
        m_SteeringDirection = steeringDirection;
    }
}
