using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))           //Reload main scene upon pressing R
        {
            Application.LoadLevel(0);
        }
    }
}
