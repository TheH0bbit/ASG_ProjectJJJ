using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //tubeParts = tube.transform.chi    
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform part = transform.GetChild(i);
            Vector3 oldPos = part.localPosition;
            oldPos.z -= Time.deltaTime;
            if (oldPos.z <= 0)
            {
                oldPos.z += 60;
            }
            part.localPosition = oldPos;

        }
        transform.Rotate(new Vector3(0, 0, Time.deltaTime));
    }
}
