﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    private void Start() {
        animator = GetComponent<Animator>();
    }

    public GameObject bullet;
    public void Shoot() {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
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