using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

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

    void Awake()
    {
        instance = this;
    }
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
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

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
            Vector3 direction = dashDirection * dashSpeed;
            transform.position += direction * Time.deltaTime;

            if (dashTimer >= dashDuration)
            {
                dashing = false;
            }
        }
        else
        {
            Vector3 direction = moveDirection * moveSpeed;
            transform.position += direction * Time.deltaTime;
        }

        dashTimer += Time.deltaTime;
    }
    void PlayerShooting()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = Vector3.Normalize(mousePosition - (Vector2)transform.position);
        Vector2 firePoint = (Vector2) transform.position + aimDirection * 0.5f;

        if (Input.GetMouseButton(0) && shootTimer > shootDelay)
        {
            Instantiate(projectile, firePoint, Quaternion.LookRotation(Vector3.forward, aimDirection));
            shootTimer = 0;
        }

        shootTimer += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Crystal")
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
