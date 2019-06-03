using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deployer : MonoBehaviour
{
    Vector3 Pos;
    float StartCountingTime;
    public GameObject OilObject;
    public GameObject BombObject;


    public void SetOil(Transform CarPos)
    {
        StartCountingTime = Time.realtimeSinceStartup;
        Pos = CarPos.position;
        Pos.z = -0.2f;
        Instantiate(OilObject, Pos, CarPos.rotation);
    }

    public void SetBomb(Transform CarPos)
    {
        StartCountingTime = Time.realtimeSinceStartup;
        Pos = CarPos.position;
        Pos.z = -0.2f;
        Instantiate(BombObject, Pos, CarPos.rotation);
    }
}