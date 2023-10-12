using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking.Types;

public class PlayerController : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;

    public float Speed;
    public float JumpForce;
    public float MoveInput;

    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask GroundLayerMask;
    public int extrajumps;

    public HealthBarController healthBarController;
    public LevelManager levelManager;

    [SerializeField]
    private int extraJumpMax;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private bool IsHealPossible;
    [SerializeField]
    private bool IsOutOfLight;
    [SerializeField]
    private bool faceingRight = true;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float healthDraining=0.05f;
    [SerializeField]
    private float healthGaining=0.1f;

    private void Awake()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        extrajumps = extraJumpMax;
        rb = GetComponent<Rigidbody2D>();
        healthBarController.SetMaxHealth(MaxHealth);
    }
    private void Update()
    {
        Jump();
        Heal();
        TakeDamage();
    }

    private void TakeDamage()
    {
        if (IsOutOfLight)
        {
            CurrentHealth -= healthDraining;
        }
        healthBarController.SetHealth(CurrentHealth);
        if (CurrentHealth < 0)
        {
            Death();
        }
    }

    private void Heal()
    {
        if (IsHealPossible)
        {
            if (CurrentHealth < MaxHealth)
            {
                CurrentHealth += healthGaining;
            }
        }
        healthBarController.SetHealth(CurrentHealth);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            extrajumps = extraJumpMax;
        }
        if (Input.GetKeyDown(KeyCode.W) && extrajumps > 0){
            rb.velocity = Vector2.up * JumpForce;
            extrajumps--;
        }else if (Input.GetKeyDown(KeyCode.W) && extrajumps == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * JumpForce;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, GroundLayerMask);
        movement();
    }
    private void movement()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveInput * Speed, rb.velocity.y);
        if(!faceingRight&&MoveInput > 0)
        {
            flip();
        }else if(faceingRight&&MoveInput < 0)
        {
            flip();
        }
    }
    private void flip()
    {
        faceingRight = !faceingRight;
        Vector3 Scalar = transform.localScale;
        Scalar.x *= -1;
        transform.localScale = Scalar;
    }
    public void AddHealth()
    {
        IsHealPossible = true;
        IsOutOfLight = false;
    }

    public void DecHealth()
    {
        IsHealPossible=false;
        IsOutOfLight = true;
    }
    public void Death()
    {
        SoundController.Instance.Play(Sounds.PlayerDied);
        Debug.Log("Player has Died");
        levelManager.GameOver();
        this.gameObject.SetActive(false);
    }

    public void LevelCompleted()
    {
        SoundController.Instance.Play(Sounds.LevelFinished);
        levelManager.GameWon();
        this.enabled = false;
    }
}
