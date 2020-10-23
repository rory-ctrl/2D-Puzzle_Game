using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
#pragma warning disable 649
    public class PlatformerCharacter2D : MonoBehaviour
    {
        
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
        private Transform pickup;
        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        public static bool holding_Weapon=false;  //Boolean for wether the palyer is holding a weapon 
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        BoxCollider2D m_Collider;
        public CircleCollider2D grounddetect;

        private bool m_isTalking = false;
        private GameObject m_weapon;

        private HealthBar healthBar;
        private TimeBar timeBar;

        private int m_crystals;
        public int m_maxHealth = 100;
        public int m_maxTime = 100;
        public int m_currentHealth;
        public int m_currentTime;
        private Inventory m_inventory;
        // [SerializeField] private UI_Inventory ui_Inventory;
        public AudioClip jumpSound;
        private AudioSource playerAudio;
         
        private void Awake()
        {
            // Setting up references.
            healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
            timeBar = GameObject.Find("TimeBar").GetComponent<TimeBar>();

            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Collider = GetComponent<BoxCollider2D>();
            m_crystals = 0;

            

            m_currentHealth = GameValues.getPlayerHealth();
            m_currentTime = m_maxTime;
            m_weapon = GameObject.Find("GunPlaceholder");
            
            m_inventory = new Inventory();
        // ui_Inventory.setInventory(m_inventory);
            playerAudio = GetComponent<AudioSource>();
            healthBar.setMaxHealth(m_maxHealth);
            healthBar.setHealth(m_currentHealth);
            timeBar.setMaxTime(m_maxTime);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && m_Grounded && !(m_isTalking))
            {

                playerAudio.PlayOneShot(jumpSound, 0.5f);

            }

            if(m_isTalking){
                m_Rigidbody2D.velocity = new Vector2(0f,0f);
            }
        }
    
     //Function for killing the player, plays the death animation and then waits 2 seconds before reloading the scene
     IEnumerator die(){
        m_Anim.SetBool("death",true);
        yield return new WaitForSeconds(2);
        //Reloads the scene on death
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        GameValues.respawns += 1;
    }
    private void FixedUpdate()
        {
            

            if(holding_Weapon){
                m_weapon.GetComponent<DisplayController>().toggleVisible();
            }

            //Disables collision if the player is currently sliding
            if(m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Slide")){
                m_Collider.enabled=false;
                //m_Collider.size=new Vector2(1,2);
                 Debug.Log("Current BoxCollider Size : " + m_Collider.size);
            }
            if(m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch")||m_Anim.GetCurrentAnimatorStateInfo(0).IsName("CrouchingWalk")){
                //m_Collider.enabled=false;
                m_Collider.size=new Vector2(1,2);
            }
            else{
                //m_Collider.size=new Vector2(1,2);
                m_Collider.enabled=true;
            }
            m_Grounded = false;


            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);
            m_Anim.SetBool("HoldingWeapon",holding_Weapon);
            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
            //Hides the weapon if the player is currently sliding or crouching
            if(m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Jumping")||m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Slide")||m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch")||m_Anim.GetCurrentAnimatorStateInfo(0).IsName("CrouchingWalk")){
               foreach (Transform child in transform)
                    {
                    child.gameObject.SetActive(false);
                     } 
            }
            else{
                foreach (Transform child in transform)
                    {
                    child.gameObject.SetActive(true);
                     } 
            }

            GameValues.setPlayerHealth(m_currentHealth);
        }


        public void Move(float move, bool crouch, bool jump, bool slide)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }
            
            // Set whether or not the character is crouching in the animator
            if(!m_isTalking){
                m_Anim.SetBool("Crouch", crouch);
            }
            

            //only control the player if grounded or airControl is turned on
            if ((m_Grounded || m_AirControl) && (!m_isTalking))
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                Debug.Log("Can control now");
                move = (crouch ? move*m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight && !m_isTalking)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight && !m_isTalking)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground") && !m_isTalking)
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));

            }
            if(slide && m_Grounded)
            {
                //Can be used to add force to the player if needed
                m_Rigidbody2D.AddForce(new Vector2(0f, 0f));
                m_Anim.Play("Slide");
            }
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;
            transform.Rotate(0f,180f,0f);
            // Multiply the player's x local scale by -1.
          /*  Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;*/
        }

        public int getCrystals(){
            return m_crystals;
        }

        public void addCrystals(int amount){
            m_crystals += amount;
        }

        public void TakeDamage(int damage){
            m_currentHealth -= damage;
            healthBar.setHealth(m_currentHealth);
            if( m_currentHealth<=0){
                StartCoroutine(die()); 
            }
        }

        private void UseTime(int time){
            m_currentTime -= time;

            timeBar.setTime(m_currentTime);
        }
        
        public void setTalking(bool check){
            m_isTalking = check;
        }

        public bool getTalking(){
            return m_isTalking;
        }
    }
