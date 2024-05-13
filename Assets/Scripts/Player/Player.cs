using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2D;

    [Header("Speed Setup")]
    public Vector2 friction = new (-.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("Animation Setup")]
    public float jumpScaleX = 1.3f;
    public float jumpScaleY = 3.5f;    
    public float jumpScaleTime = .03f;

    public Ease ease = Ease.OutBack;

    public bool isGround;

    private float _currentSpeed;

    private void Start()
    {
        isGround = true;
    }
    private void Update()
    {
        HandleJump();
        HandleMovements();
    }

    
    private void HandleMovements()
    {
        if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;


        #region Move X
        if (UnityEngine.Input.GetKey(KeyCode.A))
        {
            rb2D.velocity = new Vector2(-_currentSpeed, rb2D.velocity.y);
        }
        else if (UnityEngine.Input.GetKey(KeyCode.D))
        {
            rb2D.velocity = new Vector2(_currentSpeed, rb2D.velocity.y);
        }
        #endregion

        #region Move Y

        if (rb2D.velocity.x > 0)
        {
            rb2D.velocity -= friction;
        }
        else if (rb2D.velocity.x < 0)
        {
            rb2D.velocity += friction;
        }

        #endregion
    }


    private void HandleJump()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && isGround)
        {           
            rb2D.velocity = Vector2.up * forceJump;          

            HandleScaleJump();
        }
    }

    private void HandleScaleJump() 
    {
        rb2D.transform.DOScaleY(jumpScaleY, jumpScaleTime).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb2D.transform.DOScaleX(jumpScaleX, jumpScaleTime).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
