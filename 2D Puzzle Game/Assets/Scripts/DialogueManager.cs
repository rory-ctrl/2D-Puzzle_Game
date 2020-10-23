using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class DialogueManager : MonoBehaviour
    {

        public Animator animator;
        public Text nameText;
        public Text dialogueText;
        public GameObject m_player;
        private Queue<string> sentences;
        private Queue<string> characters;
        private IEnumerator cor;
        private PlatformerCharacter2D m_playerScript;

        private Dialogue m_dialogue;
        private bool m_beenDismissed;

        // Start is called before the first frame update
        void Start()
        {
            sentences = new Queue<string>();
            characters = new Queue<string>();
            m_beenDismissed = false;
            m_playerScript = m_player.GetComponent<PlatformerCharacter2D>();
        }

        public void StartDialogue(Dialogue dialogue){
                m_dialogue = dialogue;
                // Debug.Log("Starting convo with " + dialogue.name);
                animator.SetBool("IsOpen",true);

                m_playerScript.setTalking(true);
                sentences.Clear();
                characters.Clear();
                // m_player.GetComponent<PlatformerCharacter2D>

                foreach(string sentence in m_dialogue.sentences){
                    sentences.Enqueue(sentence);
                }

                foreach(string character in m_dialogue.names){
                    characters.Enqueue(character);
                }
                
                DisplayNextSentence();
            
        }

        public void DisplayNextSentence(){
            
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
            StopAllCoroutines();
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
            if(cor != null){
                StopCoroutine(cor);  
            }
            m_beenDismissed = true;
            m_playerScript.setTalking(false);
        }

    }