using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void Interact(){

    }

    void OnTriggerEnter2D(Collider2D trigger){
        GameObject player = GameObject.Find("TimeAgentPlayer");

        if(player!= null){
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
