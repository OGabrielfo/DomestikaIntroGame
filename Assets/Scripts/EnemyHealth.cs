using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int points;

    private void Start()
    {
        
    }
    public void AddDamage()
    {
        gameObject.SetActive(false);
    }
}
