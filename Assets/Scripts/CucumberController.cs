﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberController : EnemyController
{
    public float hp = 50;
    public float maxHp = 50;
    public GameObject Pickle;
    Animator anim;
    Vector3 startPos;
    public float chaseDistance;
    public float attackRange;
    public float spd;
    float cools = 0f;
    float chaseCools = 0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        startPos = transform.position;
        hp = maxHp;
        int animToPick = Random.Range(0, 2);
        if (animToPick == 0) anim.Play("Cucumber");
        else anim.Play("CucumberBack");
    }

    private void Update()
    {
        switch (curState)
        {
            case states.idle:
                Idle();
                break;
            case states.chase:
                Chase();
                break;
            case states.attack:
                Attack();
                break;
        }

        if (hp <= 0)
        {
            Instantiate(Pickle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (cools > 0)
        {
            cools -= Time.deltaTime;
        }

        if (chaseCools > 0) chaseCools -= Time.deltaTime;
    }

    public override void TakeDamage(float damage)
    {
        hp -= damage;
    }

    public override void Idle()
    {
        float distance = Vector3.Distance(transform.position, PlayerController.player.transform.position);
        if (distance <= chaseDistance)
        {
            curState = states.chase;
        }

        if (transform.position != startPos)
        {
            var step = spd * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
    }

    public override void Chase()
    {
        float distance = Vector3.Distance(transform.position, PlayerController.player.transform.position);
        if (distance > chaseDistance)
        {
            curState = states.idle;
        }
        if (distance < attackRange && cools <= 0)
        {
            chaseCools = 0.75f;
            curState = states.attack;
        }

        if (PlayerController.player.transform.position.y > transform.position.y)
        {
            anim.Play("CucumberBack");
        }
        else
        {
            anim.Play("Cucumber");
        }

        var step = spd * Time.deltaTime;

        if (distance > 1.5f) transform.position = Vector3.MoveTowards(transform.position, PlayerController.player.transform.position, step);
    }

    public override void Attack()
    {
        if (PlayerController.player.transform.position.y > transform.position.y)
        {
            anim.Play("CucumberAttackBack");
        }
        else
        {
            anim.Play("CucumberAttack");
        }
        if (chaseCools <= 0) curState = states.chase;
    }
}
