using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenBoss : Boss
{
    public static Transform target;

    public bool isFollowingPlayer = false;

    protected new virtual void Start()
    {
        base.Start();
        target = Player.Instance.transform;
    }

    private void FixedUpdate()
    {
        if (target == null || EnemiesPaused)
        {
            return;
        }

        if (isFollowingPlayer)
        {
            Vector3 targetPosition = target.position;
            targetPosition.y = transform.position.y;
            transform.position = targetPosition;
        }
    }

    public void startFollowingPlayer()
    {
        isFollowingPlayer = true;
    }

    public void stopFollowingPlayer()
    {
        isFollowingPlayer = false;
    }

    public void DeactivateCollider()
    {
        GetComponent<Collider>().enabled = false;
    }

    public void ActivateCollider()
    {
        GetComponent<Collider>().enabled = true;
    }
}
