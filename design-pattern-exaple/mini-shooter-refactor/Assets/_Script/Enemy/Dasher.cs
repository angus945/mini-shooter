using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : Enemy
{
    [SerializeField] float speed;

    [SerializeField] float dashSpeed;
    [SerializeField] float dashColldown;
    [SerializeField] float dashDuration;

    [SerializeField] float dashDistance;
    [SerializeField] float dashDelay;

    bool dashing;
    float timer;

    Vector3 dashDirection;

    void Update()
    {
        if (GetPlayerDistance() <= dashDistance && timer >= dashColldown)
        {
            dashing = true;
            timer = 0;

            dashDirection = GetPlayerDirection();
        }
        else if(dashing)
        {
            if(timer > dashDelay)
            {
                MoveDirection(dashDirection, dashSpeed);
            }

            if(timer > dashDelay + dashDuration)
            {
                dashing = false;
                timer = 0;
            }
        }
        else
        {
            Vector3 playerPosition = GetPlayerPosition();

            MovePosition(playerPosition, speed);
            LookPosition(playerPosition);
        }


        timer += Time.deltaTime;
    }
}
