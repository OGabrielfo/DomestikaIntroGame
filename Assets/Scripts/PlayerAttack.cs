using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    public TextMeshProUGUI visualPoints;
    private float points = 0f;

    
    private bool _isAttacking;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        } else
        {
            _isAttacking = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isAttacking == true)
        {
            if(collision.CompareTag("Enemy"))
            {
                collision.SendMessageUpwards("AddDamage");
            } 
            else if (collision.CompareTag("Big Bullet"))
            {
                collision.SendMessageUpwards("AddDamage");
            }
        }
    }

    private void AddPoints(float addPoints)
    {
        points += addPoints;
        Debug.Log(points);
        visualPoints.text = points.ToString();
    }
}
