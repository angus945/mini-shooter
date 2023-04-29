using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy
{

    [SerializeField] float speed;

    [SerializeField] Projectile projectile;
    [SerializeField] float shootTime;
    [SerializeField] float shootDelay;

    float timer;
    bool shooting;

    void Update()
    {
        if (shooting)
        {
            Vector3 playerDirection = GetPlayerDirection();
            LookDirection(playerDirection);

            if (timer > shootDelay)
            {
                ShootDirection(projectile, playerDirection);

                shooting = false;
                timer = 0;
            }
        }
        else
        {
            Vector3 playerPosition = GetPlayerPosition();

            MovePosition(playerPosition, speed);
            LookPosition(playerPosition);

            if (timer > shootTime)
            {
                shooting = true;
                timer = 0;
            }
        }

        timer += Time.deltaTime;
    }
}
