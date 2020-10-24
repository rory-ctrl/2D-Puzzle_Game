using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class DialogueManager : MonoBehaviour
    {

        public Animator animator;
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

                foreach(string sentence in m_dialogue.sentences){
                    sentences.Enqueue(sentence);
                }

                foreach(string character in m_dialogue.names){
                    characters.Enqueue(character);
                }
                
                Debug.Log(sentences.Count);
                DisplayNextSentence();
            
        }

        public void DisplayNextSentence(){
            m_playerScript.setTalking(true);
            if(sentences.Count == 0){
                
                EndDialogue();
                return;
            }
            
            

            if(characters.Count > 1 ){
                string character = characters.Dequeue();
                nameText.text = character;
            }

            if(sentences.Count < 2){
                if(characters.Count > 0){
                    nameText.text = characters.Dequeue();
                }
            }        

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
                yield return new WaitForSeconds(0.04f);
            }
            
        }

        public void EndDialogue(){
            animator.SetBool("IsOpen",false);
            attachedButton.setActive(false);
            if(cor != null){
                StopCoroutine(cor);  
                Debug.Log("finished");
            }
            // m_beenDismissed = true;
            m_playerScript.setTalking(false);
        }

    }