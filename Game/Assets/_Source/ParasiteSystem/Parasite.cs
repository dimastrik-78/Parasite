using System.Collections;
using NPCSystem;
using UnityEngine;

namespace ParasiteSystem
{
    public class Parasite : MonoBehaviour
    {
        [SerializeField] private int restoringMovementTime;
        [SerializeField] private LayerMask humanMask;

        private bool _canTransition = true;

        private const float WAIT = 1f;

        private void Update()
        {
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 3f, Vector2.up, 0, humanMask);
            
            if (hit.Length > 0
                && Input.GetMouseButtonDown(0)
                && _canTransition)
            {
                Transition(hit);
            }
        }

        // Change implementation
        private void Transition(RaycastHit2D[] hit)
        {
            Transform parent = transform.parent;
            Human human = parent.GetComponent<Human>();
            parent = null;
                
            human.ChangeState();
                
            parent = hit[0].transform;
            transform.parent = parent;

            parent.GetComponent<Human>().ChangeState();
            transform.localPosition = Vector3.zero;
            StartCoroutine(RestoringMovement());
        }

        private IEnumerator RestoringMovement()
        {
            Debug.Log("cant");
            _canTransition = false;
            
            int time = restoringMovementTime;
            while (time != 0)
            {
                yield return new WaitForSeconds(WAIT);
                time--;
            }

            _canTransition = true;
            Debug.Log("can");
        }
    }
}
