using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Equipment", menuName = "Equip")]
public class Equipment : ScriptableObject
{
    public EquipType type;
    public Stats[] stats;
}
public enum EquipType
{
    weapon,
    chest,
    boots,
    ring,
    necklace
}

