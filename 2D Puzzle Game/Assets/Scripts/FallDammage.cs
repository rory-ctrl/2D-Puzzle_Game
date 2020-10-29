using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FallDammage : MonoBehaviour
{
    public GameObject startposition;
    public int damage=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D target){
        switch(target.tag){
            case "Player":
                target.gameObject.GetComponent<PlatformerCharacter2D>().TakeDamage(damage);
                GameValues.respawns +=1;
                 target.gameObject.transform.position=startposition.transform.position;
                break;
            default:
                break;
        
    }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
