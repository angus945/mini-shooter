using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    //µo§b¡B²¾°Ê

    [SerializeField] float speed;

    [SerializeField] float moveTime;
    [SerializeField] float idleTime;

    float timer;
    bool moving;

    void Update()
    {
        if (moving)
        {
            Vector3 playerPosition = this.GetPlayerPosition();

            this.MovePosition(playerPosition, speed);
            this.LookPosition(playerPosition);

            if (timer > moveTime)
            {
                moving = false;
                timer = 0;
            }
        }
        else
        {
            if (timer > idleTime)
            {
                moving = true;
                timer = 0;
            }
        }

        timer += Time.deltaTime;
    }
}
