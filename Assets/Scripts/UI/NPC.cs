using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    [System.Serializable]
    public struct Dialogue
    {
        public string dialogueText;
        public UnityEvent OnDialogueStart;
    }

    [SerializeField] InputActionAsset primaryActions;
    InputAction interactAction;
    [SerializeField] List<Dialogue> dialogues;
    public UnityEvent OnInteractStart;
    int dialogueIndex = 0;

    bool canInteract = false;
    bool isOnDialogue = false;

    private void Awake()
    {
        interactAction = primaryActions.FindActionMap("NPC").FindAction("Interact");

        interactAction.performed += Interact;
    }

    private void OnEnable()
    {
        interactAction.Enable();
    }

    private void OnDisable()
    {
        interactAction.Disable();
    }

    public void StartDialogue()
    {
        isOnDialogue = true;
        dialogueIndex = 0;
        OnInteractStart.Invoke();
        PrintNextDialogue();
    }

    public void PrintNextDialogue()
    {
        if (dialogueIndex >= dialogues.Count)
        {
            EndDialogue();
            return;
        }

        dialogues?[dialogueIndex].OnDialogueStart.Invoke();
        DialogueManager.instance.PrintDialogue(dialogues?[dialogueIndex].dialogueText);
        dialogueIndex++;
    }


    public void EndDialogue()
    {
        isOnDialogue = false;
        dialogueIndex = 0;
        DialogueManager.instance.HideUI();
    }

    public void SkipDialogue()
    {
        dialogueIndex++;
    }

    void Interact(InputAction.CallbackContext ctx)
    {
        if (!canInteract) return;

        if (!isOnDialogue)
        {
            StartDialogue();
        }
        else
        {
            PrintNextDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            EndDialogue();
        }
    }
}
