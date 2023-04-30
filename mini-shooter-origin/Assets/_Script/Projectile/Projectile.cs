using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 20;
    [SerializeField] float duration = 2;

    [SerializeField] string targetTag;

    float lifeTime;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        lifeTime += Time.deltaTime;
        if(lifeTime > duration)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
