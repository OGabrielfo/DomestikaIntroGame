using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float damage = 1f;
	public float speed = 2f;
	public Vector2 direction;

	public float livingTime = 3f;
	public Color initialColor = Color.white;
	public Color finalColor;

	private SpriteRenderer _renderer;
	private float _startingTime;
	private Rigidbody2D _rigidbody;
	private bool _returning = false;

	void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
    {
		//  Save initial time
		_startingTime = Time.time;

		// Destroy the bullet after some time
		Destroy(gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
		// Change bullet's color over time
		float _timeSinceStarted = Time.time - _startingTime;
		float _percentageCompleted = _timeSinceStarted / livingTime;

		_renderer.color = Color.Lerp(initialColor, finalColor, _percentageCompleted);
    }

    private void FixedUpdate()
    {
		Vector2 movement = direction.normalized * speed;
		_rigidbody.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_returning == false && collision.CompareTag("Player"))
        {
			Destroy(gameObject);
			// Damage Player
			collision.SendMessageUpwards("AddDamage", damage);
		}

		if (_returning == true && collision.CompareTag("Enemy"))
        {
			collision.SendMessageUpwards("AddDamage");
			Destroy(gameObject);
        }
    }

	public void AddDamage()
    {
		_returning = true;
		direction = direction * -1;
    }
}
