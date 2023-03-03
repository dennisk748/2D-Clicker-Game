using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField]
    private EnemyData m_EnemyData;
    [SerializeField]
    private bool m_timeOn;

    public bool ResetHP;

    private float m_maxValue;

    [Tooltip("Image to set the fill amount on.")]
    public Image Image;

    [SerializeField]
    private UnityEvent m_onTimerRunOut;

    public void Start()
    {
        if (ResetHP)
            m_EnemyData.TimerValue.SetValue(m_EnemyData.StartTimerValue);
        m_maxValue = m_EnemyData.TimerValue.Value;
    }

    private void Update()
    {
        if (m_timeOn)
        {
            if(m_EnemyData.TimerValue.Value > 0)
            {
                m_EnemyData.TimerValue.Value -= Time.deltaTime;
            }
            else
            {
                m_onTimerRunOut.Invoke();
                m_EnemyData.TimerValue.Value = 0;
                m_timeOn = false;
            }
        }
        Image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(0, m_maxValue, m_EnemyData.TimerValue.Value));
    }

    public void SetTimerOn(bool timer)
    {
        m_timeOn = timer;
    }

    public void NextEnemy(EnemyData newEnemyData)
    {
        m_EnemyData = newEnemyData;
        m_timeOn = true;
    }
}
