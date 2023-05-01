using UnityEngine;

public class Player : MonoBehaviour
{
    //¯¸¥ß¡B²¾°Ê¡B½Ä¨ë
    //®gÀ»
    [Space]
    [SerializeField] int playerScore;

    [Space]
    [SerializeField] float moveSpeed;

    [Space]
    [SerializeField] float dashCoolDown;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;

    [Space]
    [SerializeField] Projectile projectile;
    [SerializeField] float shootDelay;

    float dashTimer;
    bool dashing;
    Vector2 dashDirection;

    float shootTimer;

    void Update()
    {
        Vector2 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            GameObject[] crystals = GameObject.FindGameObjectsWithTag("Crystal");
            for (int i = 0; i < crystals.Length; i++)
            {
                crystals[i].transform.position += Vector3.Normalize(transform.position - crystals[i].transform.position) * Time.deltaTime;
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
            Vector3 movement = dashDirection * dashSpeed;
            transform.position += movement * Time.deltaTime;

            if (dashTimer >= dashDuration)
            {
                dashing = false;
            }
        }
        else
        {
            Vector3 movement = moveDirection * moveSpeed;
            transform.position += movement * Time.deltaTime;
        }

        dashTimer += Time.deltaTime;

        //
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseInWorld.z = 0;

        Vector2 aimDirection = Vector3.Normalize(mouseInWorld - transform.position);

        if (Input.GetMouseButton(0) && shootTimer > shootDelay)
        {
            this.ShootDirection(projectile, aimDirection);

            shootTimer = 0;
        }

        shootTimer += Time.deltaTime;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Crystal")
        {
            playerScore++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }


}
