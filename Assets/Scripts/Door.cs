using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Door connectedDoor;
    public Transform spawnPos;


    void Pass(GameObject item)
    {
        if (connectedDoor == null)
        {
            Debug.LogError("Connected door not founded");
            return;
        }
        item.transform.position = connectedDoor.spawnPos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pass(collision.gameObject);
        }
    }
}
