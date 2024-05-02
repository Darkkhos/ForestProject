using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2D;

    public Vector2 friction = new Vector2(-.1f, 0);

    public float speed;
    public float speedRun;

    public float forceJump = 2;

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
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {           
            rb2D.velocity = Vector2.up * forceJump;
        }
    }
}
