using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2D;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("Animation Setup")]
    public float jumpScaleX = 1.3f;
    public float jumpScaleY = 3.8f;    
    public float animationDurantion = .3f;
    public Ease ease = Ease.OutBack;

    public bool isGround;

    private float _currentSpeed;
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
            rb2D.transform.localScale = new Vector2(1.5f, 3);

            isGround = false;

            DOTween.Kill(rb2D.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump() 
    {
        rb2D.transform.DOScaleY(jumpScaleY, animationDurantion).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb2D.transform.DOScaleX(jumpScaleX, animationDurantion).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
