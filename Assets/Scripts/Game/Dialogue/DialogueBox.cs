using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public int actId;
    public int questId;
    public bool completesQuest;
    public bool skipDialogue;
    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;
    public GameObject[] deactivateObjectsPermanent;


    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float textSpeed;
    public int index;
    public Rigidbody2D playerRb;
    public GameObject player;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //playerRb.linearVelocity = Vector2.zero;
        if (gameObject.GetComponent<Button>() != null) { gameObject.GetComponent<Button>().onClick.AddListener(SkipDialogue); }

        StartDialogue();
    }

    private void SkipDialogue()
    {
        if(skipDialogue) {
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
    private void Update()
    {
        // Jesli kliknieto przycisk myszy to pomija dialog
        // if (skipDialogue && Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("clicked");
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction);
        //     if(raycastHit.collider != null) {
        //         Debug.Log("1");
        //         if(raycastHit.collider.gameObject.tag == "DialogueBox") {
        //             Debug.Log("2");
        //             if (dialogueText.text == dialogueLines[index])
        //             {
        //                 NextLineOfDialogue();
        //             }
        //             else
        //             {
        //                 StopAllCoroutines();
        //                 dialogueText.text = dialogueLines[index];
        //             }   
        //         }   
        //     }
        //     // if (dialogueText.text == dialogueLines[index])
        //     // {
        //     //     NextLineOfDialogue();
        //     // }
        //     // else
        //     // {
        //     //     StopAllCoroutines();
        //     //     dialogueText.text = dialogueLines[index];
        //     // }
        // }
    }

    private void StartDialogue()
    {
        gameObject.GetComponent<AudioSource>().Play();
        //playerRb.constraints = RigidbodyConstraints2D.FreezePosition;

        if (deactivateObjects != null)
        {
            foreach (GameObject a in deactivateObjects)
            {
                a.SetActive(false);
                if (a.GetComponent<EnableableObject>() != null)
                {
                    a.GetComponent<EnableableObject>().isEnabled = false;
                }
            }
        }

        if (deactivateObjectsPermanent != null)
        {
            foreach (GameObject a in deactivateObjectsPermanent)
            {
                a.SetActive(false);
                if (a.GetComponent<EnableableObject>() != null)
                {
                    a.GetComponent<EnableableObject>().isEnabled = false;
                }
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
                if (a.GetComponent<EnableableObject>() != null)
                {
                    a.GetComponent<EnableableObject>().isEnabled = true;
                }
            }
        }

        if (activateObjects != null)
        {
            foreach (GameObject a in activateObjects)
            {
                a.SetActive(true);
                if (a.GetComponent<EnableableObject>() != null)
                {
                    a.GetComponent<EnableableObject>().isEnabled = true;
                }
            }
            activateObjects = null;
        }

        if (InventoryManager.Instance != null) 
        {
            InventoryManager.Instance.ShowInventory();
        }
        //playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;

        gameObject.SetActive(false);
    }

    public void NextLineOfDialogue()
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
