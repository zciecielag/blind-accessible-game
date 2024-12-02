using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float textSpeed;

    private int index;

    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;

    private void OnEnable()
    {
        StartDialogue();
    }

    private void StartDialogue()
    {
        if (deactivateObjects != null)
        {
            foreach (GameObject a in deactivateObjects)
            {
                a.SetActive(false);
                Debug.Log(a.activeSelf);
            }
        }
        index = 0;
        dialogueText.text = string.Empty;
        StartCoroutine(TypeDialogue());
    }

    IEnumerator TypeDialogue()
    {
        foreach(char c in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        StartCoroutine(WaitAndNextLine());
    }

    IEnumerator WaitAndNextLine()
    {
        yield return new WaitForSeconds(1.0f);
        NextLineOfDialogue();
    }

    IEnumerator WaitAndEnd()
    {
        yield return new WaitForSeconds(1.0f);
        if (activateObjects != null)
        {
            foreach (GameObject a in activateObjects)
            {
                a.SetActive(true);
            }
        }
        if (deactivateObjects != null)
        {
            foreach (GameObject a in deactivateObjects)
            {
                a.SetActive(true);
            }
        }
        gameObject.SetActive(false);
    }

    private void NextLineOfDialogue()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            StartCoroutine(WaitAndEnd());
        }
    }
}
