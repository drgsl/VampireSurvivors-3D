using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : Enemy
{
    public static Transform target;

    public Vector3 initPos;

    protected virtual void Awake()
    {
        target = Player.Instance.transform;

        initPos = transform.position;
    }


    protected void FixedUpdate()
    {
        if(target == null)
        {
            return;
        }

        // Move towards target (player) using Vector3.MoveTowards
        transform.position = Vector3.MoveTowards(transform.position, target.position, data.Speed * 0.01f);
        transform.position = new Vector3(transform.position.x, initPos.y, transform.position.z);

        // // Rotate towards target (player) using Quaternion.LookRotation
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
    }

}
