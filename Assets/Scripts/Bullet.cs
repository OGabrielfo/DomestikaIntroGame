using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;

    public float livingTime = 3f;
    public Color initialColor = Color.white;
    public Color finalColor;

    private SpriteRenderer _renderer;
    private float _startingTime;
    // Start is called before the first frame update

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        //Save initial time
        _startingTime = Time.time;

        //Destroy the bullet after some time
        Destroy(gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Move object
        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        transform.Translate(movement);

        //Change bullet color
        float _timeSinceStarted = Time.time - _startingTime;
        float _percentageCompleted = _timeSinceStarted / livingTime;

        _renderer.color = Color.Lerp(initialColor, finalColor, _percentageCompleted);
    }
}
