using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    private int lifes;
    private void Start() {
        animator = GetComponent<Animator>();
        lifes = 10;
    }

    public GameObject bullet;
    public Transform gun_1;
    public AudioClip shootSFX;

    public float shot_delay = 0.1f;
    private float _last_shot_timestamp = 0.0f; 
    public void Shoot() {
        if (Time.time - _last_shot_timestamp < shot_delay) return; 
        AudioManager.PlaySFX(shootSFX);
        _last_shot_timestamp = Time.time;
        Instantiate(bullet, gun_1.position, Quaternion.identity);
    }

    public void TakeDamage() {
        lifes--;
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        
        if(yInput !=0 || xInput != 0) {
            animator.SetFloat("Velocity", 1.0f);
        } else {
            animator.SetFloat("Velocity", 0.0f);
        }


        if(Input.GetAxisRaw("Fire1") != 0) {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }  


    
}
