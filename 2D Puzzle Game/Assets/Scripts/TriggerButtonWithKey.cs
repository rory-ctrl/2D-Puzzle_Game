using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerButtonWithKey : MonoBehaviour
{
    private Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        myButton = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Return))
         {
            //  Debug.Log("Button pressed");
            if(myButton != null){
                myButton.onClick.Invoke();
            }
         }
    }
}
