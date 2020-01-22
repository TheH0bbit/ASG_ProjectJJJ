using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(PointManager.lives){

            case 1:
                
                    text.text = "O";
                break;
            case 2:

                text.text = "OO";
                break;
            case 3:

                text.text = "OOO";
                break;
            default:
                text.text = "";
                break;

        }
    }
}
