using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    // private PlatformerCharacter2D m_playerScript;
    // public GameObject m_player;
    // public GameObject weapon;
    public Image m_weapon;    
    public Image m_bulletType;

    private void Start(){
        m_weapon.enabled = false;
        m_bulletType.enabled = false;
    }

    public void toggleVisible(){
        m_weapon.enabled = !m_weapon.enabled;
        m_bulletType.enabled = !m_bulletType.enabled;
    }
    

}
