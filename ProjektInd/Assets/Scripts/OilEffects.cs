using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilEffects : MonoBehaviour
{
    float StartCountingTime;
    float DeltaTime;
    bool isTimerOn = false;
    Collider2D collider2d;

    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        collider2d.enabled = false;
        StartCountingTime = Time.realtimeSinceStartup;
        isTimerOn = true;

    }

    void Update()
    {
        Timer();
    }


    void Timer()
    {
        if (isTimerOn == true)
        {
            DeltaTime = Time.realtimeSinceStartup - StartCountingTime;
            if (DeltaTime > 8)
            {
                isTimerOn = false;
                Destroy(this.gameObject);
            }
            if (DeltaTime > 1)
            {
                collider2d.enabled = true;
            }
        }

    }
}