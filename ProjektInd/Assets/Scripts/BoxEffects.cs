using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEffects : MonoBehaviour
{
    public Vector3 Pos;
    Vector3 SecPos;
    bool isTimerOn = false;
    float StartCountingTime;
    float DeltaTime;

    void Start()
    {
        Pos = transform.localPosition;
    }

    void Update()
    {
        Timer();
    }

    public void Effect()
    {
        isTimerOn = true;
        StartCountingTime = Time.realtimeSinceStartup;
        SecPos.z = -10;
        SecPos.x = 300;
        SecPos.y = 300;
        transform.position = SecPos;
    }

    void Timer()
    {
        if (isTimerOn == true)
        {
            DeltaTime = Time.realtimeSinceStartup - StartCountingTime;
            if (DeltaTime > 10)
            {
                transform.localPosition = Pos;
                isTimerOn = false;
                DeltaTime = 0;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("PlayerOne") || otherCollider.CompareTag("PlayerTwo") == true)
        {
            Effect();
        }
    }
}
