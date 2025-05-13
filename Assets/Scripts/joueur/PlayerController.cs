using System;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public Vector2 AttackOffset;
    public Transform AttackPoint;
    public ColliderCheck GroundColliderCheck;
    public ColliderCheck AttackColliderCheck;
    public LayerMask GroundLayer;
    public float attackCooldown = 2f;
    private float nextAttackTime = 2f;
    
    public bool isJumping;
    
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    public float timeBetweenAttack;
    public float attackTime;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        bool isJumping = Input.GetButtonDown("Jump");
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(horizontal * Time.deltaTime * MoveSpeed, 0, 0);

        if (isJumping && GroundColliderCheck.IsCheck)
        {
            _rigidBody.AddForce(Vector2.up * JumpForce);
        }

        _animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        _animator.SetFloat("Vertical", _rigidBody.linearVelocity.y);

        if (horizontal > 0)
        {
            _spriteRenderer.flipX = false;
            AttackPoint.localPosition = AttackOffset;
        }
        else if (horizontal < 0)
        {
            _spriteRenderer.flipX = true;
            AttackPoint.localPosition = new Vector2(-AttackOffset.x, AttackOffset.y);
        }
            
        
        if (Input.GetButtonDown("Fire1") && GroundColliderCheck.IsCheck)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                _animator.SetTrigger("Attack");
                _rigidBody.linearVelocity = Vector2.zero;

                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
    public void Attack()
    {
        GameObject checkedObject = AttackColliderCheck.checkedObject;
        if (checkedObject) 
            checkedObject.GetComponent<Enemy>().TakeDamage(1);
    }
}  