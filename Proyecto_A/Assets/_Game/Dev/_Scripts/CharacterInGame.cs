using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterInGame : MonoBehaviour
{
    [SerializeField] Character character;
    Equipment equipment;
    float speed;
    float percent;
    int id;
    public static event UnityAction Stop, begin;

    bool canMove = true;

    void StopMove() => canMove = false;
    void ResumeMove() => canMove = true;
    private void Awake()
    {
        speed = character.stats[(int)StatsType.speed].value + Random.Range(-1f, 1f);
        //speed = character.stats.speed + Random.Range(-1f, 1f);
    }
    private void OnEnable()
    {
        Stop += StopMove;
        begin += ResumeMove;
        id = GameManager.instance.uIManager.SetSpriteInSpeedHUD(character.sprite);
    }

    private void OnDisable()
    {
        Stop -= StopMove;
        begin -= ResumeMove;
        try
        {
            GameManager.instance.uIManager.SetSpriteInSpeedHUD(character.sprite, false);
        }
        catch { }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Attack();
        if (!canMove) return;

        percent = GameManager.instance.uIManager.SetInPosition(speed, percent, id);

        if (percent >= 1)
        {
            Stop?.Invoke();
            StartCoroutine(Attack());
        }

    }
    public IEnumerator Attack()
    {
        Debug.Log("Character: " + character.charName + " with: " + speed + " speed, attacks");
        Debug.Log("has used: " + character.skills[0].skillName);
        Debug.Log("The skill has did: " + character.Attack() + " of " + character.skills[0].damageType + " damage");
        Debug.Log("The skill description is: " + character.skills[0].GetDescription());
        yield return new WaitForSeconds(1);
        percent = 0;
        begin?.Invoke();
    }
}
