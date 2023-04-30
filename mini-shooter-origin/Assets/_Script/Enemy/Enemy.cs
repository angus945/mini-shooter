using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Action<Vector3> OnDestroyedEvent;
    private void Awake()
    {
        gameObject.tag = "Enemy";
    }
    void OnDestroy()
    {
        OnDestroyedEvent?.Invoke(transform.position);
    }


}
