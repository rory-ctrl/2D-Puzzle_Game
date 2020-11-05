using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource m_AudioSource;
    bool m_ToggleChange;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            m_AudioSource.Play();
        }
    }
}
