using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerButtonWithKey : MonoBehaviour
{
    // private Button myButton;
    private Button myButton;
    private bool active;
    // Start is called before the first frame update
    void Awake()
    {
        myButton = this.gameObject.GetComponent<Button>();
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Return))
         {
            //  Debug.Log("Button pressed");
            if(myButton != null && active){
                myButton.onClick.Invoke();
            }
         }
    }

    public void setActive(bool active){
        this.active = active;
    }
}
