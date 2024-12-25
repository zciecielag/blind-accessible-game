using UnityEngine;
using UnityEngine.UI;

public class SkipDialogue : MonoBehaviour
{
    private DialogueBox parentDialogueBox;
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(Skip);
        parentDialogueBox = this.gameObject.transform.parent.gameObject.GetComponent<DialogueBox>();
    }

    private void Skip()
    {
        
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction);
        // if(raycastHit.collider != null) {
        //     Debug.Log("1");
        //     if(raycastHit.collider.gameObject.tag == "DialogueBox") {
        //         Debug.Log("2");

        if (parentDialogueBox.skipDialogue)
        {
            if (parentDialogueBox.dialogueText.text == parentDialogueBox.dialogueLines[parentDialogueBox.index])
                {
                    parentDialogueBox.NextLineOfDialogue();
                }
                else
                {
                    StopAllCoroutines();
                    parentDialogueBox.dialogueText.text = parentDialogueBox.dialogueLines[parentDialogueBox.index];
                } 
        }
                  
        
    }
}
