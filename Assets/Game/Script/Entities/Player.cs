using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] public int _hitPoints = 3;

    [SerializeField] public int _foodPoints = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trash01")
        {
            _hitPoints -= 1;

            if (_hitPoints <= 0)
            {
                Kill();
            }
        }

        if (other.gameObject.name == "Food01")
        {
            _foodPoints += 1;
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
