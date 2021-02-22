using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class TimeControl : MonoBehaviour
{

    GlobalClock gl;

    // Start is called before the first frame update
    void Start()
    {
        gl = GetComponent<GlobalClock>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (gl.localTimeScale == 1)
            {
                gl.localTimeScale = 2;
            }

            else if(gl.localTimeScale == 2)
            {
                gl.localTimeScale = 3;
            }

            else if (gl.localTimeScale == 3)
            {
                gl.localTimeScale = 1;
            }

        }

    }
}
