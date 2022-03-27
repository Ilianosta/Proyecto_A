using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skill")]
public class Skill : ScriptableObject
{
    public string skillName = "Default skill";
    public string skillDesc = "Default description";
    public float damage, attackDmgScale, magicDmgScale;
    public Effects effect;
    public damageTypes damageType;
    Color c_Physical = new Color(1, 0.85f, 0.35f);
    Color c_Magic = new Color(0.8f, 0.5f, 1f);
    Color c_Hybrid = new Color(0.28f, 1, 0.28f);
    [ContextMenu("Recharge Colors")]
    void RechargeColors()
    {
        c_Physical = new Color(1, 0.85f, 0.35f);
        c_Magic = new Color(0.8f, 0.5f, 1f);
        c_Hybrid = new Color(0.28f, 1, 0.28f);
    }
    public float DoDamage(Character character)
    {
        float auxDamage = damage;
        float scale = 0;
        string _newDesc = skillDesc;

        switch (damageType)
        {
            case damageTypes.physical:
                scale = character.stats[(int)StatsType.attackDmg].value * attackDmgScale;
                auxDamage = damage + scale;
                break;
            case damageTypes.magic:
                scale = character.stats[(int)StatsType.magicDmg].value * magicDmgScale;
                auxDamage = damage + scale;
                break;
            case damageTypes.hybrid:
                scale = character.stats[(int)StatsType.attackDmg].value * attackDmgScale + character.stats[(int)StatsType.magicDmg].value * magicDmgScale;
                auxDamage = damage + scale;
                break;
        }
        skillDesc = string.Format(_newDesc, scale);
        return auxDamage;
    }

    public string GetDescription()
    {
        return skillDesc;
    }
}
[System.Serializable]
public class Effects
{

}
public enum damageTypes
{
    physical,
    magic,
    hybrid
}
