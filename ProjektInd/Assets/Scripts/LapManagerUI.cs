using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LapManager))]
public class LapManagerUI : MonoBehaviour
{
    public Text LapTimeText;
    LapManager m_LapManager;
    private void Awake()
    {
        m_LapManager = GetComponent<LapManager>();
    }

    private void Update()
    {
        UpdateLapTimeInfoText();
    }

    void UpdateLapTimeInfoText()
    {
        LapTimeText.text = "Current:" + TimeChanger(m_LapManager.CurrentLapTime) + "\n"
            + "Last:" + TimeChanger(m_LapManager.LastLapTime) + "\n" + "Best:" + TimeChanger(m_LapManager.BestLapTime) + "";
    }

    string TimeChanger(float seconds)
    {
        int DisplayMinutes = Mathf.FloorToInt(seconds / 60f);
        int DisplaySeconds = Mathf.FloorToInt(seconds % 60f);
        int DisplayFractionSeconds = Mathf.FloorToInt((seconds - DisplaySeconds) * 100f);

        return DisplayMinutes + ":" + DisplaySeconds.ToString("00") + ":" + DisplayFractionSeconds.ToString("00");
    }
}
