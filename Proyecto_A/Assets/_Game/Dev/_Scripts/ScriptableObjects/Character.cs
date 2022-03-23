using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public string charName = "DefaultName";
    public GameObject character;
    public Stats stats;
    public Pasives pasive;
    public Skill[] skills;

    public float Attack(int skill = 0)
    {
        return skills[skill].DoDamage(this);
    }
}
[System.Serializable]
public class Stats
{
    public float attackDmg, health, armor, speed, magicDmg;
}
[System.Serializable]
public class Pasives
{

}
