using System.Collections.Generic;
using UnityEngine;

namespace _Source.LevelSystem
{
    public class MovementPoints : MonoBehaviour
    {
        [SerializeField] private List<MovementPoints> points;

        public List<Transform> GetTransformPoints()
        {
            List<Transform> transformList = new List<Transform>();
            foreach (MovementPoints point in points)
            {
                transformList.Add(point.transform);
            }

            return transformList;
        }

        public List<MovementPoints> GetMovementPoints()
        {
            return points;
        }
    }
}
