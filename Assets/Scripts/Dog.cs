using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Dog : MonoBehaviour
{
    public static Dog Instance { get; private set; }
    //This variable will be changed depending on the dialogue system
    List<string> currentDialogues = new List<string>();
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Room currentRoom;
    NavMeshAgent agent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToDoor()
    {
        agent.SetDestination(currentRoom.correctDoor.position);
    }

    public void ChangeRoom(Room NewRoom)
    {
        currentRoom = NewRoom;
        currentDialogues.Clear();
        currentDialogues = NewRoom.roomDialoges;
        agent.SetDestination(currentRoom.DogInitPos.position);
    }

    public void SetAlpha(float alpha)
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
    }
}
