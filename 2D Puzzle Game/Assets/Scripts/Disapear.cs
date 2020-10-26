using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear : MonoBehaviour
{
    private GameObject obj;
    public Color clear=new Color(1f,1f,1f,.3f);
    public Color solid=new Color(1f,1f,1f,1f);
    public float interval = 0.5f;
    public float timeRemaining;
    bool isActive=true; 
    // Start is called before the first frame update
    void Start()
    {
    obj=gameObject;
    timeRemaining=interval;
    }

    // Update is called once per frame
    void Update()
    {
        vanish();
    }
    void vanish(){
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else{
            //Hides Platform on interval of time
            if(isActive==false){
                obj.GetComponent<BoxCollider2D>().enabled=false;
                obj.GetComponent<SpriteRenderer>().color=clear;
            }
            else{
                obj.GetComponent<BoxCollider2D>().enabled=true;
                obj.GetComponent<SpriteRenderer>().color=solid;
            }
            isActive=!isActive;
            timeRemaining=interval;
        }
    }
}
