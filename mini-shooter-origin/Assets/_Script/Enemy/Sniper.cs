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
        float playerDistance = this.GetPlayerDistance();

        if(playerDistance > shootDistance)
        {
            Vector3 playerDirection = this.GetPlayerDirection();

            this.MoveDirection(playerDirection, speed);
            this.LookPosition(playerDirection);

            timer = 0;
        }
        else if (playerDistance < runDistance)
        {
            Vector3 runDirection = -this.GetPlayerDirection();

            this.MoveDirection(runDirection, speed);
            this.LookPosition(runDirection);

            timer = 0;
        }
        else
        {
            Vector3 playerDirection = this.GetPlayerDirection();
            this.LookDirection(playerDirection);

            if (timer > shootTime)
            {
                this.ShootDirection(projectile, playerDirection);

                timer = 0;
            }
        }

        timer += Time.deltaTime;
    }
}
