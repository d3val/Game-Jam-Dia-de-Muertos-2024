using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }
    [SerializeField] GameObject dialogueUI;
    [SerializeField] TextMeshProUGUI dialogueText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public void PrintDialogue(string dialogue)
    {
        dialogueUI.SetActive(true);
        dialogueText.SetText(dialogue);
    }

    public void HideUI()
    {
        dialogueText.SetText("");
        dialogueUI?.SetActive(false);
    }
}
