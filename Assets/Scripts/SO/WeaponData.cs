using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName ="CreateNewWeapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private string m_weaponName;
    public float m_DamageAmount;
}
