using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControlTest : Basetime
{
    private float moveSpeed = 1.0f;

    private void Update()
    {
        if(time.timeScale > 0)
        {
            time.rigidbody.velocity = new Vector3(transform.localScale.x * moveSpeed, time.rigidbody.velocity.y, 0);
        }

        
    }
}
