using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffects : MonoBehaviour
{
    float StartCountingTime;
    float DeltaTime;
    bool isTimerOn = false;
    Collider2D collider2d;
    public Animator animator;
    float delay = 1f;

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
                animator.SetBool("OnCollisionWithCar", true);
                Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
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
            animator.SetBool("OnCollisionWithCar", true);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
    }
}
