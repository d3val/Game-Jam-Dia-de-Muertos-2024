using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [Tooltip("The room number where is placed this door")]
    [SerializeField] int room;
    public Room m_Room { get; private set; }
    [Tooltip("The other side door connected to this one")]
    [SerializeField] Door connectedDoor;
    [Tooltip("Where the player will be spawned when cross to this door")]
    public Transform spawnPos;
    public UnityEvent OnDogPass;
    public UnityEvent OnPlayerPass;

    private void Start()
    {
        m_Room = transform.parent.GetComponent<Room>();
    }

    void Pass(GameObject item, bool MoveCamera = true)
    {
        if (connectedDoor == null)
        {
            Debug.LogError("Connected door not founded");
            return;
        }

        // We move the player to the connected doos spawn position and init the translation of the camera.
        item.transform.position = connectedDoor.spawnPos.position;

        if (!MoveCamera)
            return;
        //If the door returns us to  the initial room, use fade effect
        if (connectedDoor.room == room)
            CameraMovement.Instance.MoveToRoom(connectedDoor.room);
        else
            CameraMovement.Instance.MoveToRoom(connectedDoor.room,true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pass(collision.gameObject);
            collision.GetComponent<NavMeshAgent>().isStopped = true;
            OnPlayerPass.Invoke();
        }
        else if (collision.CompareTag("Dog"))
        {
            Pass(collision.gameObject, false);
            Dog.Instance.ChangeRoom(connectedDoor.m_Room);
            OnDogPass.Invoke();
        }
    }
}
