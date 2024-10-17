using UnityEngine;
using UnityEngine.AI;

public class NavMeshTarget : MonoBehaviour
{
    [SerializeField] private bool lookingRight;

    private NavMeshAgent agent;
    [SerializeField] Camera cam;
    bool canMove = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (!canMove) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                SetDestination(hit.point);
            }
        }
    }

    private void SetDestination(Vector3 destination)
    {
        agent.isStopped = false;
        agent.SetDestination(destination);
        Vector3 direction = (destination - transform.position).normalized;
        if (direction.x > 0 && !lookingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && lookingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        lookingRight = !lookingRight;
        transform.Rotate(0, 180, 0);
    }

    public void ActivePlayerMove(bool state)
    {
       canMove = state;
    }
}
