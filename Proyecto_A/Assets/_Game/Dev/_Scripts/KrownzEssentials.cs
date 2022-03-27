using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Krownz.Maths
{
    public class KrownzMaths : MonoBehaviour
    {
        public static void ReposObjBetween(Transform obj, Vector3 pos1, Vector3 pos2, float percentBetween)
        {
            obj.position = pos1;
            Vector3 pos = obj.position;
            float distance = Vector3.Distance(pos1, pos2);
            pos.x += distance * percentBetween;
            obj.position = pos;
        }
    }
}
namespace com.Krownz._2D
{
    public class Krownz2D : MonoBehaviour
    {

    }
}
namespace com.Krownz._3D
{
    public class Krownz3D : MonoBehaviour
    {

    }
}
