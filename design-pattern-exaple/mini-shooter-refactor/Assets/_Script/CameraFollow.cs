using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.z = 0;

        transform.position += direction * speed * Time.deltaTime;
    }
}
