﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool hasTriggered = false;

    public void TriggerDialogue(){
        hasTriggered = true;
        if(this.name =="JumpTrigger"){
            GameObject.Find("JumpDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }else if(this.name == "StartTrigger"){
            GameValues.score = 0;
            GameObject.Find("StartDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }else if(this.name == "SecondLevelTrigger"){
            GameObject.Find("SecondLevelDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }else if(this.name == "DeathDialogueTrigger"){
            if(GameValues.respawns == 1){
                GameObject.Find("DeathDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
            }
        }else if(this.name == "CrouchDialogueTrigger"){
            GameObject.Find("CrouchDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        else if(this.name == "CrouchHelpDialogueTrigger"){
            GameObject.Find("CrouchDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        
    }

    public void Interact(){

    }

    void OnTriggerEnter2D(Collider2D trigger){
        GameObject player = GameObject.Find("TimeAgentPlayer");

        if(player!= null && !hasTriggered){
            // Debug.Log("Entered");
            TriggerDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D trigger){
        GameObject player = GameObject.Find("TimeAgentPlayer");

        if(player!= null){
            // Debug.Log("left");
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
}
