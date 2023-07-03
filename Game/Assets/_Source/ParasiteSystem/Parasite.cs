using System.Collections;
using NPCSystem;
using UnityEngine;

namespace ParasiteSystem
{
    public class Parasite : MonoBehaviour
    {
        [SerializeField] private Transform projection;
        [SerializeField] private int restoringMovementTime;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask humanMask;

        private bool _canTransition;

        private const float WAIT = 1f;

        private void Update()
        {
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0, humanMask);
            
            if (hit.Length > 0
                && _canTransition)
            {
                projection.position = hit[0].transform.position;
                
                if (Input.GetMouseButtonDown(0))
                {
                    Transition(hit);
                }
            }
            else
            {
                projection.localPosition = Vector3.zero;
            }
        }

        private void OnEnable()
        {
            _canTransition = true;
        }

        // Change implementation
        private void Transition(RaycastHit2D[] hit)
        {
            Transform parent = transform.parent;
            Human human = parent.GetComponent<Human>();
            parent = null;
                
            human.Infection();
                
            parent = hit[0].transform;
            transform.parent = parent;

            parent.GetComponent<Human>().Infection();
            transform.localPosition = Vector3.zero;
            StartCoroutine(RestoringMovement());
        }

        private IEnumerator RestoringMovement()
        {
            _canTransition = false;

            int time = restoringMovementTime;
            while (time != 0)
            {
                yield return new WaitForSeconds(WAIT);
                time--;
            }

            _canTransition = true;
        }
    }
}
