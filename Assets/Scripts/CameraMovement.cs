using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement Instance { get; private set; }
    [SerializeField] Transform[] rooms;
    [Tooltip("How many seconds is going to take the transition?")]
    [SerializeField] float transitionDuration = 1.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public void MoveToRoom(int roomIndex)
    {
        StartCoroutine(TranslateToRoom(roomIndex));
    }

    IEnumerator TranslateToRoom(int roomIndex)
    {
        float interVar;
        Vector3 transitionVector = transform.position;
        Vector2 startPoint = transform.position;

        // Interpolation from current position to tarjet position
        for (float t = 0; t < transitionDuration; t += Time.deltaTime)
        {
            interVar = t / transitionDuration;
            // Vector's components separately calculated
            transitionVector.x =Mathf.Lerp(startPoint.x, rooms[roomIndex].position.x, interVar);
            transitionVector.y =Mathf.Lerp(startPoint.y, rooms[roomIndex].position.y, interVar);
            //Calculations applied
            transform.position = transitionVector;
            yield return null;
        }

        // To be sure that it is correctly placed
        transform.position = new Vector3(rooms[roomIndex].position.x, rooms[roomIndex].position.y, transform.position.z);

    }
}
