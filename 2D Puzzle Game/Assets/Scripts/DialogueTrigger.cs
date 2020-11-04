using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool hasTriggered = false;

    public void TriggerDialogue(){
        
        if(this.name =="JumpTrigger"){
            hasTriggered = true;
            GameObject.Find("JumpDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }else if(this.name == "StartTrigger"){
            GameValues.score = 0;
            GameValues.respawns = 0;
            hasTriggered = true;
            GameObject.Find("StartDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }else if(this.name == "SecondLevelTrigger"){
            hasTriggered = true;
            GameObject.Find("SecondLevelDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }else if(this.name == "DeathDialogueTrigger"){
            // Debug.Log(GameValues.respawns);
            if(GameValues.respawns >= 1){
                hasTriggered = true;
                GameObject.Find("DeathDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
            }

        }
        else if(this.name == "GapDialogueTrigger"){
            hasTriggered = true;
            GameObject.Find("DeathDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        else if(this.name == "CrouchDialogueTrigger"){
            hasTriggered = true;
            GameObject.Find("CrouchDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        else if(this.name == "CrouchHelpDialogueTrigger"){
            hasTriggered = true;
            GameObject.Find("CrouchDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        else if(this.name == "DragonDialogueTrigger"){
            hasTriggered = true;
            GameObject.Find("DragonDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        else if(this.name == "SuitDialogueTrigger"){
            hasTriggered = true;
            GameObject.Find("SuitDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        else if(this.name == "SuitPickupTrigger"){
            hasTriggered = true;
            GameObject.Find("SuitDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        else if(this.name == "AntagonistDialogueTrigger"){
            hasTriggered = true;
            GameObject.Find("AntagonistDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        else if(this.name == "RepeatDialogueTrigger"){
            hasTriggered = true;
            GameObject.Find("RepeatDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }
        else if(this.name == "NopeDialogueTrigger"){
            hasTriggered = true;
            GameObject.Find("RepeatDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
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
