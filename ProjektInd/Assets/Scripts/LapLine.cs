using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapLine : MonoBehaviour
{
    public string TagName;
    public int Index;

    LapManager m_LapManager;

    private void Awake()
    {
        m_LapManager = GetComponentInParent<LapManager>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag(TagName) == true)
        {
            m_LapManager.OnLapLinePassed(Index);
        }
    }
}
