using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private void TriggerDialogueBox(GameObject dialogueBox)
    {
        dialogueBox.SetActive(true);
    }
}
