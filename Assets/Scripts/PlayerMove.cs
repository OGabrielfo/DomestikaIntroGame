using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // PUBLIC VARIABLES
    public float velocity;
    public float jumpPower;
    public int jumpLimit;
    public GameObject GroundCheck;
    public int longIdleLimit;

    // PRIVATE VARIABLES
    private Rigidbody2D _playerRigidbody;
    private Animator _animator;
    private int jumps;
    private bool canMove = true;
    private int longIdleCounter;

    // SERIALIZED VARIABLES
    [SerializeField] LayerMask groundMask;



    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Walk();

        Attack();

        //Jump
        IsGrounded();
        if(Input.GetButtonDown("Jump") && jumps < jumpLimit)
        {
            Jump();
        }
        _animator.SetFloat("VerticalVelocity",_playerRigidbody.velocity.y);
    }


    // FUNCTIONS

    // Long Idle Function
    private void LongIdleCounter()
    {
        longIdleCounter++;
        if(longIdleCounter >= longIdleLimit)
        {
            _animator.SetTrigger("LongIdle");
        }
    }

    // Walk Functions
    private void Walk()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (canMove)
        {
            _playerRigidbody.velocity = new Vector2(horizontal * velocity, _playerRigidbody.velocity.y);
            _animator.SetBool("Idle", false);
            
            if (horizontal != 0f || _playerRigidbody.velocity.y != 0f)
            {
                longIdleCounter = 0;
                _animator.ResetTrigger("LongIdle");
            }
            

            if (horizontal > 0f)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                _animator.SetBool("Idle", true);
            }
        } else {
            _playerRigidbody.velocity = new Vector2(0, _playerRigidbody.velocity.y);
        }
        
    }

    private void CanMove()
    {
        if (canMove == true)
        {
            canMove = false;
            //Debug.Log(canMove);
        } else
        {
            canMove = true;
        }
        

        Debug.Log(canMove);
    }


    // Jump and Ground Check Function
    private bool IsGrounded()
    {
        if (_playerRigidbody.velocity.y == 0)
        {
            jumps = 0;
            _animator.ResetTrigger("Jump");
            return true;
        } else
        {
            return false;
        }
    }

    private void Jump()
    {
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, jumpPower);
        _animator.SetTrigger("Jump");
        jumps++;
    }


    // Attack Functions
    private void Attack()
    {
        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) && IsGrounded())
        {
            _animator.SetTrigger("Attack");
        }
    }
}
