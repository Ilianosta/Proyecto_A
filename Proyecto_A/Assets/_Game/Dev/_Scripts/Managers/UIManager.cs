using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.Krownz.Maths;
public class UIManager : MonoBehaviour
{
    [SerializeField] Transform test, testStart, testEnd, speedBar;
    [SerializeField][Range(0, 1)] float percent;
    [SerializeField] Transform[] charMarker;
    List<Transform> charImg = new List<Transform>();
    int ids = 0;
    [ContextMenu("Repos")]
    public float SetInPosition(float charSpeed, float percent, int id)
    {
        //Debug.Log($"Percent: {percent} // id: {id} // speed: {charSpeed}");
        percent += (charSpeed / 100) * Time.deltaTime;
        KrownzMaths.ReposObjBetween(charImg[id], testStart.position, testEnd.position, percent);
        return percent;
    }
    public int SetSpriteInSpeedHUD(Sprite sprite, bool active = true)
    {
        GameObject obj = new GameObject();
        obj.transform.parent = speedBar;
        obj.AddComponent<Image>().sprite = sprite;
        obj.transform.position = testStart.position;

        charImg.Add(obj.transform);
        int id = ids;
        ids++;
        return id;
    }
}
