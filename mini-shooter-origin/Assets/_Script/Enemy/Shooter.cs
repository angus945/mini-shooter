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
            Vector3 playerDirection = this.GetPlayerDirection();
            this.LookDirection(playerDirection);

            if (timer > shootDelay)
            {
                this.ShootDirection(projectile, playerDirection);

                shooting = false;
                timer = 0;
            }
        }
        else
        {
            Vector3 playerPosition = this.GetPlayerPosition();

            this.MovePosition(playerPosition, speed);
            this.LookPosition(playerPosition);

            if (timer > shootTime)
            {
                shooting = true;
                timer = 0;
            }
        }

        timer += Time.deltaTime;
    }
}
