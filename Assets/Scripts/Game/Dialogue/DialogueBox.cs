using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public int actId;
    public int questId;
    public bool completesQuest;
    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;


    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float textSpeed;
    private int index;
    public Rigidbody2D playerRb;

    private void OnEnable()
    {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //nie dziala, rusza sie gracz
        playerRb.linearVelocity = Vector2.zero;

        StartDialogue();
    }

    private void StartDialogue()
    {
        gameObject.GetComponent<AudioSource>().Play();

        if (deactivateObjects != null)
        {
            foreach (GameObject a in deactivateObjects)
            {
                a.SetActive(false);
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

        if (gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }

        if (completesQuest)
        {
            ActManager.Instance.CompleteSubQuest(questId);
            completesQuest = false;
        }

        if (deactivateObjects != null)
        {
            foreach (GameObject a in deactivateObjects)
            {
                a.SetActive(true);
            }
        }

        if (activateObjects != null)
        {
            foreach (GameObject a in activateObjects)
            {
                a.SetActive(true);
            }
            activateObjects = null;
        }

        InventoryManager.Instance.ShowInventory();

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
