using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float MoveSpeed = .05f;

    protected Rigidbody RB { get; private set; }

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();    
    }

    protected virtual void Move()
    {
        Vector3 moveDelta = transform.right * MoveSpeed;
        RB.MovePosition(RB.position + moveDelta);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy();
        //if (other.gameObject.name == "Player")
        //{
            //Destroy();
        //}
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
