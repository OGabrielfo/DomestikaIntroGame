using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;

    private Transform _firePoint;

    void Awake()
    {
        _firePoint = transform.Find("FirePoint");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        
        float horizontal = Input.GetAxis("Horizontal");
        //Changing side
        if (horizontal > 0f){
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        } else if (horizontal < 0f) {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        
        //Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        */
          
    }

    public void Shoot()
    {
        if (bulletPrefab != null && _firePoint != null && shooter != null) {
            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;

            Bullet bulletComponent = myBullet.GetComponent<Bullet>();

            if (shooter.transform.localScale.x < 0f) {
                //Left
                bulletComponent.direction = Vector2.left;
            } else {
                //Right
                bulletComponent.direction = Vector2.right;
            }
        }
    }
}
