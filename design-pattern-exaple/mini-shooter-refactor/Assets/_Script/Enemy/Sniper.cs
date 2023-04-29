using UnityEngine;

public class Sniper : Enemy
{

    [SerializeField] float speed;
    [SerializeField] float shootDistance;
    [SerializeField] float runDistance;

    [SerializeField] Projectile projectile;
    [SerializeField] float shootTime;

    float timer;

    void Update()
    {
        float playerDistance = GetPlayerDistance();

        if(playerDistance > shootDistance)
        {
            Vector3 playerDirection = GetPlayerDirection();

            MoveDirection(playerDirection, speed);
            LookPosition(playerDirection);

            timer = 0;
        }
        else if (playerDistance < runDistance)
        {
            Vector3 runDirection = -GetPlayerDirection();

            MoveDirection(runDirection, speed);
            LookPosition(runDirection);

            timer = 0;
        }
        else
        {
            Vector3 playerDirection = GetPlayerDirection();
            LookDirection(playerDirection);

            if (timer > shootTime)
            {
                ShootDirection(projectile, playerDirection);

                timer = 0;
            }
        }

        timer += Time.deltaTime;
    }
}
