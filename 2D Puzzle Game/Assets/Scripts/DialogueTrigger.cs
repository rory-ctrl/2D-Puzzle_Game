using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool hasTriggered = false;

    public void TriggerDialogue(){
        GameValues.score = 0;
        hasTriggered = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void Interact(){

    }

    void OnTriggerEnter2D(Collider2D trigger){
        GameObject player = GameObject.Find("TimeAgentPlayer");

        if(player!= null && !hasTriggered){
            // Interact();
            TriggerDialogue();
            
        }
    }

    void OnTriggerExit2D(Collider2D trigger){
        GameObject player = GameObject.Find("TimeAgentPlayer");

        if(player!= null){
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
}
