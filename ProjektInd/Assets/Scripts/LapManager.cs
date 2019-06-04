using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    public float CurrentLapTime
    {
        get
        {
            DeltaTime = Time.realtimeSinceStartup;
            DeltaTime = DeltaTime - DeltaTime2;
            if (!PauseMenu.activeSelf)
            {
                Time.timeScale = 1f;
                if (m_IsLapStarted == false)
                {
                    return 0f;
                }
                return DeltaTime - m_currentLapStartTime;
            }
            else
            {
                DeltaTime2 += Time.deltaTime;
                return 0;
            }
        }
    }
    public float LastLapTime { get; private set; }
    public float BestLapTime { get; private set; }
    bool m_IsLapStarted = false;
    float m_currentLapStartTime;
    int m_lastLapLineIndex = 0;
    int m_HighestLapLine;
    float DeltaTime;
    float DeltaTime2;
    public GameObject PauseMenu;

    private void Start()
    {
        m_HighestLapLine = GetHighestLapLine();
    }

    void OnPauseScreen()
    {
        if (PauseMenu.activeSelf)
        {

        }
        else
        {

        }
    }

    int GetHighestLapLine()
    {
        int highestLapLine = 0;
        LapLine[] lapLines = GetComponentsInChildren<LapLine>();

        for (int i = 0; i < lapLines.Length; i++)
        {
            highestLapLine = Mathf.Max(m_HighestLapLine, lapLines[i].Index);
        }
        return highestLapLine;
    }

    public void OnLapLinePassed(int index)
    {
        if (index == 0)
        {
            if (m_IsLapStarted == false || m_lastLapLineIndex == m_HighestLapLine)
            {
                OnFinishLinePassed();
            }
        }
        else
        {
            if (index == m_lastLapLineIndex + 1)
            {
                m_lastLapLineIndex = index;
            }
        }

    }
    void OnFinishLinePassed()
    {
        if (m_IsLapStarted == true)
        {
            LastLapTime = Time.realtimeSinceStartup - m_currentLapStartTime;

            if (LastLapTime < BestLapTime || BestLapTime == 0f)
            {
                BestLapTime = LastLapTime;
            }
        }
        m_IsLapStarted = true;
        m_currentLapStartTime = Time.realtimeSinceStartup;
        m_lastLapLineIndex = 0;
    }
}
