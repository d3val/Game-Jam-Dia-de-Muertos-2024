using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [System.Serializable]
    public struct Dialogue
    {
        [TextArea] public string dialogueText;
        public UnityEvent OnDialogueStart;
    }

    [SerializeField] InputActionAsset primaryActions;
    InputAction interactAction;
    [SerializeField] List<Dialogue> dialogues;
    [SerializeField] List<Dialogue> secondaryDialogues;
    public UnityEvent OnInteractStart;
    public UnityEvent OnDialogueFirstEnd;
    bool firstEnd = true;
    public UnityEvent OnDialogueEnd;
    int dialogueIndex = 0;

    bool canInteract = false;
    public bool isOnDialogue { private set; get; }

    private void Awake()
    {
        interactAction = primaryActions.FindActionMap("NPC").FindAction("Interact");

        interactAction.performed += Interact;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        if (firstEnd)
        {
            OnDialogueFirstEnd.Invoke();
            firstEnd = false;
        }
        OnDialogueEnd.Invoke();
       // DialogueManager.instance.EnablePlayerMove();
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
            DialogueManager.instance.currentNPC = this;
            DialogueManager.instance.EnableInteractionButton(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogueManager.instance.EnableInteractionButton(false);
            canInteract = false;
            isOnDialogue = false;
            dialogueIndex = 0;
            DialogueManager.instance.HideUI();
        }
    }

    public void StartWalking()
    {
        animator.SetTrigger("Walk");
    }

    public void ChangeDialogues()
    {
        if (secondaryDialogues == null) return;
        dialogues = secondaryDialogues;
    }
}
