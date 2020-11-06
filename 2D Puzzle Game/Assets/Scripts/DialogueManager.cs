using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class DialogueManager : MonoBehaviour
    {

        public Animator animator;
        public Animator enemyAnim;
        public TriggerButtonWithKey attachedButton;
        public Text nameText;
        public Text dialogueText;
        public GameObject m_player;
        private Queue<string> sentences;
        private Queue<string> characters;
        private IEnumerator cor;
        private PlatformerCharacter2D m_playerScript;

        private Dialogue m_dialogue;
        // private bool m_beenDismissed;

        // Start is called before the first frame update
        void Start()
        {
            sentences = new Queue<string>();
            characters = new Queue<string>();
            // m_beenDismissed = false;
            m_playerScript = m_player.GetComponent<PlatformerCharacter2D>();
        }

        public void StartDialogue(Dialogue dialogue){
                attachedButton.setActive(true);
                m_dialogue = dialogue;
                m_playerScript.setTalking(true);
                animator.SetBool("IsOpen",true);

                sentences.Clear();
                characters.Clear();
                // m_player.GetComponent<PlatformerCharacter2D>

                foreach(Sentence m_sentence in m_dialogue.sentences){
                    sentences.Enqueue(m_sentence.sentence);
                    characters.Enqueue(m_sentence.name);
                }
                
                DisplayNextSentence();
            
        }

        public void DisplayNextSentence(){
            m_playerScript.setTalking(true);
            if(sentences.Count == 0){
                
                EndDialogue();
                return;
            }
            
            string character = characters.Dequeue();
            nameText.text = character;       

            string sentence = sentences.Dequeue();
            if(cor != null){
                StopCoroutine(cor);  
            }
            cor = TypeSentence(sentence);
            StartCoroutine(cor);
        }

        IEnumerator TypeSentence (string sentence){
            dialogueText.text = "";
            foreach(char letter in sentence.ToCharArray()){
                dialogueText.text +=letter;
                yield return new WaitForSeconds(0.03f);
            }
            
        }

        public void EndDialogue(){

            animator.SetBool("IsOpen",false);

            if(enemyAnim != null){
                enemyAnim.SetBool("ConvoDone", true);
            }
            
            attachedButton.setActive(false);
            if(cor != null){
                StopCoroutine(cor);  
            }

            if(gameObject.name == "DragonDialogueManager"){
                if(GameValues.score >= 1){
                    GameValues.score -= 1;
                }
            }

            if(gameObject.name == "SuitPickupDialogueManager"){
                Debug.Log("Firing");
                GameValues.shouldShoot = true;
            }

            // m_beenDismissed = true;
            m_playerScript.setTalking(false);
        }

    }