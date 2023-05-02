using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float attackDmg = 10f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private float alphaMultipleIndex = 5f;

    [SerializeField] private Animator anim;
    float time = 0f;
    private enum PlayerState { Run, Jump, Attack}

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            anim.SetInteger("State", (int)PlayerState.Jump);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        else if(rb2d.velocity.y < 0.1f && IsGrounded())
        {
            anim.SetInteger("State", (int)PlayerState.Run);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            particle.Play();
            float alpha = particle.startColor.a;

            float previousTime = time;
            float currentTime = time;
            time += Time.deltaTime;
            attackDmg += attackDmg * time * 10f;
            alpha += Time.deltaTime * alphaMultipleIndex;

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Invoke("ParticleStop", 0.25f);
            if (IsGrounded())
            {
                anim.SetInteger("State", (int)PlayerState.Attack);
            }
            Debug.Log(attackDmg);
        }

        
    }

    private void ParticleStop()
    {
        particle.Clear();
        particle.Stop();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.transform.position, 0.3f, layerMask);
    }


}
