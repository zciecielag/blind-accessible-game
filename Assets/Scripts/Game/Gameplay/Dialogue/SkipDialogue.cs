using UnityEngine;
using UnityEngine.UI;

public class SkipDialogue : MonoBehaviour
{
    private GameObject parent;
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(Skip);
        parent = this.gameObject.transform.parent.gameObject;
    }

    private void Skip()
    {
        Debug.Log("clicked");
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction);
        // if(raycastHit.collider != null) {
        //     Debug.Log("1");
        //     if(raycastHit.collider.gameObject.tag == "DialogueBox") {
        //         Debug.Log("2");
        if (parent.GetComponent<DialogueBox>().skipDialogue)
        {
            if (parent.GetComponent<DialogueBox>().dialogueText.text == parent.GetComponent<DialogueBox>().dialogueLines[parent.GetComponent<DialogueBox>().index])
                {
                    parent.GetComponent<DialogueBox>().NextLineOfDialogue();
                }
                else
                {
                    StopAllCoroutines();
                    parent.GetComponent<DialogueBox>().dialogueText.text = parent.GetComponent<DialogueBox>().dialogueLines[parent.GetComponent<DialogueBox>().index];
                } 
        }
                  
        
    }
}
