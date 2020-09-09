using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D trigger){
        GameObject player = GameObject.Find("Player");

        if(player!= null){
            TriggerDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D trigger){
        GameObject player = GameObject.Find("Player");

        if(player!= null){
             FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
}
