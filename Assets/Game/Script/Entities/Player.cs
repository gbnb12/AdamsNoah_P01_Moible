using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] public int _hitPoints = 3;

    [SerializeField] public int _foodPoints = 0;

    [SerializeField] Text _foodText;
    [SerializeField] Text _hitText;

    [SerializeField] protected AudioClip _foodSound;
    [SerializeField] protected AudioClip _hitSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trash01")
        {
            _hitPoints -= 1;
            HitFeedback();
            _hitText.GetComponent<Text>().text = "Food Points: " + _hitPoints;
            if (_hitPoints <= 0)
            {
                Kill();
            }
        }

        if (other.gameObject.name == "Food01")
        {
            _foodPoints += 1;
            FoodFeedback();
            _foodText.GetComponent<Text>().text = "Food Points: " + _foodPoints;
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void HitFeedback()
    {
        if (_hitSound != null)
        {
            AudioHelper.PlayClip2D(_hitSound, 1f);

        }
    }

    private void FoodFeedback()
    {
        if (_foodSound != null)
        {
            AudioHelper.PlayClip2D(_foodSound, 1f);

        }
    }
}
