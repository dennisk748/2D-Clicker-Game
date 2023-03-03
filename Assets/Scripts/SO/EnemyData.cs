using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public string m_enemyName;
    public Sprite m_sprite;
    public FloatVariable m_HealthPoints;
    public FloatVariable m_StartingHP;
    public FloatVariable TimerValue;
    public FloatVariable StartTimerValue;
}
