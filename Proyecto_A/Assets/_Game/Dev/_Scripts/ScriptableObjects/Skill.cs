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
    public Color c_Physical, c_Magic, c_Hybrid;
    public float DoDamage(Character character)
    {
        float auxDamage = damage;
        float scale = 0;
        string _newDesc = skillDesc;

        switch (damageType)
        {
            case damageTypes.physical:
                scale = character.stats.attackDmg * attackDmgScale;
                auxDamage = damage + scale;
                break;
            case damageTypes.magic:
                scale = character.stats.magicDmg * magicDmgScale;
                auxDamage = damage + scale;
                break;
            case damageTypes.hybrid:
                scale = character.stats.attackDmg * attackDmgScale + character.stats.magicDmg * magicDmgScale;
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
