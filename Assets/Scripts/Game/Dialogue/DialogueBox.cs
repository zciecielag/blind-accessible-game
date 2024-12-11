using System.Collections;
using TMPro;
using UnityEditor;
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
    public GameObject player;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerRb.linearVelocity = Vector2.zero;

        StartDialogue();
    }
    private void Update()
    {
        // Jesli kliknieto przycisk myszy to pomija dialog
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == dialogueLines[index])
            {
                NextLineOfDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[index];
            }
        }
    }

    private void StartDialogue()
    {
        gameObject.GetComponent<AudioSource>().Play();
        playerRb.constraints = RigidbodyConstraints2D.FreezePosition;

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
            ActManager.Instance.CompleteSubQuest(actId, questId);
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

        if (InventoryManager.Instance != null) 
        {
            InventoryManager.Instance.ShowInventory();
        }
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;

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
