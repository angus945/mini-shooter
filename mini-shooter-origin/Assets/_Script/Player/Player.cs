using UnityEngine;

public class Player : PlayerBase
{
    [Space]
    [SerializeField] float moveSpeed;

    [Space]
    [SerializeField] float dashCoolDown;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;

    [Space]
    [SerializeField] Projectile projectile;
    [SerializeField] float shootDelay;

    void Start()
    {

    }
    void Update()
    {
        PlayerMovement();
        PlayerShooting();
    }

    float dashTimer;
    bool dashing;
    Vector2 dashDirection;

    float shootTimer;

    void PlayerMovement()
    {
        Vector2 moveDirection = this.GetInputDirection();

        if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            GameObject[] crystals = GameObject.FindGameObjectsWithTag("Crystal");
            for (int i = 0; i < crystals.Length; i++)
            {
                Vector3 crystalPosition = crystals[i].transform.position;
                Vector3 suckDirection = Vector3.Normalize(transform.position - crystalPosition);
                crystals[i].transform.position += suckDirection * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.Space) && dashTimer > dashCoolDown && !dashing)
        {
            dashing = true;
            dashDirection = moveDirection;
            dashTimer = 0;
        }
        else if (dashing)
        {
            this.MoveDirection(dashDirection, dashSpeed);

            if (dashTimer >= dashDuration)
            {
                dashing = false;
            }
        }
        else
        {
            this.MoveDirection(moveDirection, moveSpeed);
        }

        dashTimer += Time.deltaTime;
    }
    void PlayerShooting()
    {
        Vector2 aimDirection = this.GetMouseDirection();

        if (Input.GetMouseButton(0) && shootTimer > shootDelay)
        {
            this.ShootDirection(projectile, aimDirection);

            shootTimer = 0;
        }

        shootTimer += Time.deltaTime;
    }

}
