using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager uIManager;
    [SerializeField] Transform[] alliesPositions, enemiesPositions;
    [SerializeField] List<Character> characters = new List<Character>();
    int amountOfAllies, amountOfEnemies = 0;
    //public bool canMove;
    [SerializeField] int spawnAllies, spawnEnemies;

    [ContextMenu("Load All Shop Items")]
    private void LoadAllShopItems()
    {
        characters = ScriptableObjectUtilities.FindAllScriptableObjectsOfType<Character>("t:Character", "Assets/_Game/Dev/ScriptableObjects/Characters/");
    }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(SpawnCharactersIn(alliesPositions, amountOfAllies, spawnAllies));
        StartCoroutine(SpawnCharactersIn(enemiesPositions, amountOfEnemies, spawnEnemies));
    }
    IEnumerator SpawnCharactersIn(Transform[] sidePositions, int aux, int amountToSpawn)
    {
        //Debug.Log("Entrance when aux: " + aux + " // called by: " + side);
        if (sidePositions.Length < amountToSpawn)
        {
            Debug.Log("Not enough space to place units");
            yield return null;
        }
        if (aux >= amountToSpawn) yield return null;
        for (int i = 0; i < sidePositions.Length; i++)
        {
            bool a = Random.Range(0, 2) == 0 ? true : false;
            if (a && !sidePositions[i].gameObject.activeSelf)
            {
                aux++;
                Instantiate(characters[Random.Range(0, characters.Count)].character, sidePositions[i]);
                sidePositions[i].gameObject.SetActive(true);
                if (aux >= amountToSpawn) break;
            }
        }
        if (aux < amountToSpawn) StartCoroutine(SpawnCharactersIn(sidePositions, aux, amountToSpawn));
    }
}
public static class ScriptableObjectUtilities
{

    public static List<T> FindAllScriptableObjectsOfType<T>(string filter, string folder = "Assets")
        where T : ScriptableObject
    {
        return AssetDatabase.FindAssets(filter, new[] { folder })
            .Select(guid => AssetDatabase.LoadAssetAtPath<ScriptableObject>(AssetDatabase.GUIDToAssetPath(guid)))
            .Cast<T>().ToList();
    }
}
