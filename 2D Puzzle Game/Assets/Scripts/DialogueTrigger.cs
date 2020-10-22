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
        if(this.name =="JumpTrigger"){
            GameObject.Find("JumpDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }else if(this.name == "StartTrigger"){
            GameObject.Find("StartDialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue);
        }else if(this.name == "SecondLevelTrigger"){
            // Debug.Log("Chat triggered");
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
