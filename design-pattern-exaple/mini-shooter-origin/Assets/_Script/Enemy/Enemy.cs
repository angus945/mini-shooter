using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Action<Vector3> OnDestroyedEvent;
    void OnDestroy()
    {
        OnDestroyedEvent?.Invoke(transform.position);
    }

    protected Vector3 GetPlayerPosition()
    {
        if (Player.instance != null)
        {
            return Player.instance.transform.position;
        }
        else return Vector3.zero;
    }
    protected Vector3 GetPlayerDirection()
    {
        return Vector3.Normalize(GetPlayerPosition() - transform.position);
    }
    protected float GetPlayerDistance()
    {
        Vector3 playerPos = GetPlayerPosition();
        return Vector3.Distance(transform.position, playerPos);
    }

    protected void MoveDirection(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;
        transform.up = direction;
    }
    protected void MovePosition(Vector3 position, float speed)
    {
        Vector3 direction = Vector3.Normalize(position - transform.position);
        transform.position += direction * speed * Time.deltaTime;
    }

    protected void LookPosition(Vector3 position)
    {
        Vector3 direction = Vector3.Normalize(position - transform.position);
        transform.up = direction;
    }
    protected void LookDirection(Vector3 direction)
    {
        transform.up = direction;
    }

    protected void ShootDirection(Projectile projectile, Vector2 direction)
    {
        Vector2 firePoint = (Vector2)transform.position + direction * 0.5f;

        Instantiate(projectile, firePoint, Quaternion.LookRotation(Vector3.forward, direction));
    }
}
