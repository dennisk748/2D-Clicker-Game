using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int m_weaponSelected;
    private float m_weaponDamage;

    [SerializeField]
    private EnemyData enemyHp;
    [SerializeField]
    private GameObject m_damageDealtText;
    [SerializeField]
    private UnityEvent DamageEvent;
    [SerializeField]
    private UnityEvent DeathEvent;
    private bool doOnce = true;
    private int m_checkWeaponSelect = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(m_weaponSelected == m_checkWeaponSelect)
            {
                enemyHp.m_HealthPoints.ApplyChange(-m_weaponDamage);
                DamageEvent.Invoke();
                Debug.Log(enemyHp.m_HealthPoints.Value);
            }
        }
        if (enemyHp.m_HealthPoints.Value <= 0.0f && doOnce)
        {
            DeathEvent.Invoke();
            Debug.Log("Change Weapon to Fire Thrower");
            m_checkWeaponSelect++;
            doOnce = false;
        }
    }
    public void Weapon(int weaponIndex)
    {
        m_weaponSelected = weaponIndex;
    }

    public void WeaponInfo(WeaponData weaponData)
    {
        m_weaponDamage = weaponData.m_DamageAmount;
    }

    public void DisplayText()
    {
        m_damageDealtText.GetComponent<TextMeshProUGUI>().text = "- " + m_weaponDamage.ToString();
        
    }

    public void NextEnemy(EnemyData newEnemyData)
    {
        enemyHp = newEnemyData;
    }

}
