using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffects : MonoBehaviour
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
            if (DeltaTime > 5)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerOne") || collision.collider.CompareTag("PlayerTwo") == true)
        {
            Destroy(this.gameObject);
        }
    }
}
