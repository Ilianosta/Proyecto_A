using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInGame : MonoBehaviour
{
    [SerializeField] Character character;
    private void Awake()
    {
        character.Attack();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Attack();
    }
    public void Attack()
    {
        Debug.Log("Character: " + character.charName + " has used: " + character.skills[0].skillName);
        Debug.Log("The skill has did: " + character.Attack() + " of " + character.skills[0].damageType + " damage");
        Debug.Log("The skill description is: " + character.skills[0].GetDescription());
    }
}
