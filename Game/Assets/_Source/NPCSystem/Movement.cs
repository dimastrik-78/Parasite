using System.Collections.Generic;
using _Source.LevelSystem;
using UnityEngine;

namespace _Source.NPCSystem
{
    public class Movement
    {
        private int _pointPassed;

        public void Move(Transform npc, List<Transform> path, ref int pointPassed)
        {
            npc.position = Vector3.MoveTowards(npc.position, path[pointPassed].position, 0.1f);
            
            if (npc.position == path[pointPassed].position)
            {
                pointPassed++;
            }
        }
        
        public List<Transform> FindPath(MovementPoints start, MovementPoints end)
        {
            List<MovementPoints> movementPointsList = new List<MovementPoints>();
            List<MovementPoints> noNeed = new List<MovementPoints>();
            List<Transform> points = start.GetTransformPoints();

            while (true)
            {
                foreach (var point in points)
                {
                    if (point.position == end.transform.position)
                    {
                        movementPointsList.Add(start);
                        movementPointsList.Add(end);
                        return GetListTransform(movementPointsList);
                    }
                }
                
                AddElement(ref noNeed, start);
                movementPointsList.Add(start);

                var t = start.GetMovementPoints();
                for (int i = 0; i < t.Count; i++)
                {
                    if (CheckUnnecessaryPoints(t[i], noNeed))
                    {
                        start = t[i];
                        points = start.GetTransformPoints();
                        break;
                    }
                }

                if (!CheckAroundPoint(start, noNeed))
                {
                    movementPointsList.Remove(movementPointsList[^1]);
                    start = movementPointsList[^1];
                }
            }
        }

        private bool CheckUnnecessaryPoints(MovementPoints point, List<MovementPoints> noNeedPoints)
        {
            for (int i = 0; i < noNeedPoints.Count; i++)
            {
                if (point == noNeedPoints[i])
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckAroundPoint(MovementPoints point, List<MovementPoints> noNeedPoints)
        {
            var position = point.GetTransformPoints();
            int count = 0;
            
            for (int i = 0; i < position.Count; i++)
            {
                for (int j = 0; j < noNeedPoints.Count; j++)
                {
                    if (position[i].position == noNeedPoints[j].transform.position)
                    {
                        count++;
                    }
                }
            }

            if (count == position.Count)
            {
                return false;
            }
            
            return true;
        }

        private List<Transform> GetListTransform(List<MovementPoints> movementPointsList)
        {
            List<Transform> transformList = new List<Transform>();

            for (int i = 0; i < movementPointsList.Count; i++)
            {
                transformList.Add(movementPointsList[i].transform);
            }

            return transformList;
        }

        private void AddElement(ref List<MovementPoints> pointsList, MovementPoints newElement)
        {
            for (int i = 0; i < pointsList.Count; i++)
            {
                if (newElement == pointsList[i])
                {
                    return;
                }
            }
            
            pointsList.Add(newElement);
        }
    }
}