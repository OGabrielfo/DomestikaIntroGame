using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 3;
    public RectTransform heartUI;

    // Game over
    public RectTransform gameOverMenu;
    public GameObject hordes;
    public GameObject startingPoint;

    private float heartSize = 16f;
    private int health;

    private SpriteRenderer _renderer;
    private Animator _animator;
    private PlayerController _controller;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Start()
    {
        
    }

    public void AddDamage(int amount)
    {
        health = health - amount;

        // Visual Feedback
        StartCoroutine("VisualFeedback");

        // Game Over
        if (health <=0)
        {
            health = 0;
            gameObject.SetActive(false);
        }

        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
        Debug.Log("Player got damage. His current health is " + health);
    }

    public void AddHealth(int amount)
    {
        health = health + amount;

        //Max health
        if (health > totalHealth)
        {
            health = totalHealth;
        }

        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
        Debug.Log("Player got some life. His current health is " + health);
    }

    private IEnumerator VisualFeedback()
    {
        _renderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _renderer.color = Color.white;
    }

    private void OnEnable()
    {
        this.transform.position = new Vector2(startingPoint.transform.position.x, startingPoint.transform.position.y);
        health = totalHealth;
    }

    private void OnDisable()
    {
        gameOverMenu.gameObject.SetActive(true);

        hordes.SetActive(false);
        _animator.enabled = false;
        _controller.enabled = false;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
