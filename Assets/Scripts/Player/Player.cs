using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2D;

    public Vector2 velocity;

    public float speed;

    private void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.A))
        {
            //rb2D.MovePosition(rb2D.position - velocity * Time.deltaTime);
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
        }
        else if (UnityEngine.Input.GetKey(KeyCode.D))
        {
            //rb2D.MovePosition(rb2D.position + velocity * Time.deltaTime);
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
        }
    }


}
