﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask grassLayer;

    public event Action OnEncountered;

    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input.x != 0)
            {
                input.y = 0;
            }

            if(input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (isWalkAble(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
                
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
        CheckForEncounters();
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null)
        {
            if(Random.Range(1, 101) <= 10)
            {
                animator.SetBool("isMoving", false);
                OnEncountered();
            }
        }
    }

    private bool isWalkAble(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
