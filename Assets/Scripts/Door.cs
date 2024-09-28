using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Tooltip("The room number where is placed this door")]
    [SerializeField] int room;
    [Tooltip("The other side door connected to this one")]
    [SerializeField] Door connectedDoor;
    [Tooltip("Where the player will be spawned when cross to this door")]
    public Transform spawnPos;

    void Pass(GameObject item)
    {
        if (connectedDoor == null)
        {
            Debug.LogError("Connected door not founded");
            return;
        }

        // We move the player to the connected doos spawn position and init the translation of the camera.
        item.transform.position = connectedDoor.spawnPos.position;
        CameraMovement.Instance.MoveToRoom(connectedDoor.room);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pass(collision.gameObject);
        }
    }
}
