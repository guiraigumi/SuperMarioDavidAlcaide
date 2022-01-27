using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1000f;
    public float jumpForce = 10f;

    public bool isGrounded;

    float dirx;

    public SpriteRenderer renderer;
    public Animator _animator;
    Rigidbody2D _rBody;

    void Awake ()
    {
        _animator = GetComponent<Animator>();
        _rBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        
        Debug.Log(dirx);

        transform.position += new Vector3(dirx, 0, 0) * speed * Time.deltaTime;

         if(dirx == -1)
        {
            renderer.flipX = true;
            _animator.SetBool("Running", true);
        }
        else if(dirx == 1)
        {
            renderer.flipX = false;
            _animator.SetBool("Running", true);
        }
        else
        {
            _animator.SetBool("Running", false);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("Jumping", true);
        }


        


    }
}
