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
        private IEnumerator cor;
        private PlatformerCharacter2D m_playerScript;
        private bool m_beenDismissed;

        // Start is called before the first frame update
        void Start()
        {
            sentences = new Queue<string>();
            m_beenDismissed = false;
            m_playerScript = m_player.GetComponent<PlatformerCharacter2D>();
        }

        public void StartDialogue(Dialogue dialogue){
            if(!m_beenDismissed){
                // Debug.Log("Starting convo with " + dialogue.name);
                animator.SetBool("IsOpen",true);
                nameText.text = dialogue.name;

                m_playerScript.setTalking(true);
                sentences.Clear();
                // m_player.GetComponent<PlatformerCharacter2D>

                foreach(string sentence in dialogue.sentences){
                    sentences.Enqueue(sentence);
                }
                
                DisplayNextSentence();
            }
            
        }

        public void DisplayNextSentence(){
            if(sentences.Count == 0){
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();

            StopAllCoroutines();
            cor=TypeSentence(sentence);
            StartCoroutine(cor);
            // Debug.Log(sentence);
            // dialogueText.text = sentence;
        }

        IEnumerator TypeSentence (string sentence){
            dialogueText.text = "";
            foreach(char letter in sentence.ToCharArray()){
                dialogueText.text +=letter;
                yield return new WaitForSeconds(0.08f);
            }
        }
        public void EndDialogue(){
            // Debug.Log("End of convo");
            animator.SetBool("IsOpen",false);
            StopCoroutine(cor);
            m_beenDismissed = true;
            m_playerScript.setTalking(false);
        }

    }