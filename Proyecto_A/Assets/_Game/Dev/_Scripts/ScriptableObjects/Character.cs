using UnityEngine;
[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public string charName = "DefaultName";
    public GameObject character;
    public Sprite sprite;
    public Stats[] stats;
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
    public StatsType stat;
    public float value;
}
[System.Serializable]
public class Pasives
{

}
public enum StatsType
{
    attackDmg, health, armor, speed, magicDmg
}
