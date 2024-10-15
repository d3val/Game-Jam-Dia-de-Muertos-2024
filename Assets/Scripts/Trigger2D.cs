using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger2D : MonoBehaviour
{
    public UnityEvent On2DEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        On2DEnter.Invoke();
    }
}
