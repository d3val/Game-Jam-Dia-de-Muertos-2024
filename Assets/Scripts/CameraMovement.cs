using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement Instance { get; private set; }
    [SerializeField] Transform[] rooms;
    [Tooltip("How many seconds is going to take the transition?")]
    [SerializeField] float transitionDuration = 1.0f;
    [Header("Fading settings")]
    [SerializeField] CanvasGroup canvas;
    [SerializeField] float fadeDuration = 0.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public void MoveToRoom(int roomIndex, bool fadeEnabled = false)
    {
        StartCoroutine(TranslateToRoom(roomIndex, fadeEnabled));
    }

    IEnumerator TranslateToRoom(int roomIndex, bool fadeEnabled)
    {
        if (fadeEnabled)
            yield return StartCoroutine(FadeIn());

        float interVar;
        Vector3 transitionVector = transform.position;
        Vector2 startPoint = transform.position;

        // Interpolation from current position to tarjet position
        for (float t = 0; t < transitionDuration; t += Time.deltaTime)
        {
            interVar = t / transitionDuration;
            // Vector's components separately calculated
            transitionVector.x = Mathf.Lerp(startPoint.x, rooms[roomIndex].position.x, interVar);
            transitionVector.y = Mathf.Lerp(startPoint.y, rooms[roomIndex].position.y, interVar);
            //Calculations applied
            transform.position = transitionVector;
            yield return null;
        }

        // To be sure that it is correctly placed
        transform.position = new Vector3(rooms[roomIndex].position.x, rooms[roomIndex].position.y, transform.position.z);

        if (fadeEnabled)
            yield return StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            canvas.alpha = t / fadeDuration;
            yield return null;
        }
        canvas.alpha = 1;
    }

    IEnumerator FadeOut()
    {
        for (float t = fadeDuration; t > 0; t -= Time.deltaTime)
        {
            canvas.alpha = t / fadeDuration;
            yield return null;
        }
        canvas.alpha = 0;
    }
}
