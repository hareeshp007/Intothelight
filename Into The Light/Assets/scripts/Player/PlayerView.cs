using IntoTheLight.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask GroundLayerMask;
    public Animator Animator;
    

    public HealthBarController healthBarController;

    [SerializeField]
    private float MoveInput;
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
    private PlayerController controller;

    public void SetController(PlayerController playerController)
    {
        controller = playerController;

    }

    

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
        Animator =GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Jump();
        
        if (IsOutOfLight)
        {
            TakeDamage();
        }
        else
        {
            Heal();
        }
        
    }

    private void TakeDamage()
    { 
        if (IsOutOfLight)
        {
            Debug.Log("health Drainging");
            controller.HealthDraining();
            UpdateHealth();
        }
    }
    private void UpdateHealth()
    {
        float CurrentHealth = controller.GetCurrentHealth();
        healthBarController.SetHealth(CurrentHealth);
        if (CurrentHealth < 0)
        {
            Death();
        }
    }

    private void Heal()
    {
        Debug.Log("Healing");
        controller.HealUnderTheLight();
        UpdateHealth();
    }

   

    private void Jump()
    {
        
        int CurrentExtraJumps = controller.GetCurrentExtraJumps();
        float jumpForce = controller.GetJumpForce();
        if (isGrounded)
        {
            
            Animator.SetBool("isFalling", false);
            controller.SetJumpsOnGround();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Animator.SetBool("IsJumping", true);
            if (CurrentExtraJumps > 0)
            {
                
                rb.velocity = Vector2.up * controller.GetJumpForce();
                controller.SetJumps();
            }
            else if (CurrentExtraJumps == 0 && isGrounded)
            {
                Animator.SetBool("isFalling", false);
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        
        if (rb.velocity.y < 0)
        {
            Animator.SetBool("IsJumping", false);
            Animator.SetBool("isFalling", true);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, GroundLayerMask);
        Animator.SetBool("OnGround", isGrounded);
        movement();
        
    }
    private void movement()
    {
        float speed = controller.GetSpeed();
        MoveInput = Input.GetAxisRaw("Horizontal");
        Animator.SetFloat("speed", Mathf.Abs(MoveInput));
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);
        if (!faceingRight && MoveInput > 0)
        {
            flip();
        }
        else if (faceingRight && MoveInput < 0)
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
        IsOutOfLight = false;
    }

    public void DecHealth()
    {
        IsOutOfLight = true;
    }
    public void Death()
    {
        Animator.SetBool("IsAlive", false);
        //SoundController.Instance.Play(Sounds.PlayerDied);
        Debug.Log("Player has Died");
    }

    private void playerDeath( )
    {
        this.gameObject.SetActive(false);
    }

    public void LevelCompleted()
    {
        //SoundController.Instance.Play(Sounds.LevelFinished);
        this.enabled = false;
    }

    public void SetHealthBar(HealthBarController healthBar)
    {
        int MaxExtraJumps = controller.GetCurrentExtraJumps();
        float MaxHealth = controller.GetCurrentHealth();
        healthBarController = healthBar;
        healthBarController.SetMaxHealth(MaxHealth);
        Debug.Log(MaxHealth);
    }
}
