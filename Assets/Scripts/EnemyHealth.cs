using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float points;

    private void Start()
    {
        
    }
    public void AddDamage()
    {
        gameObject.SetActive(false);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.SendMessageUpwards("AddPoints", points);
    }
}
