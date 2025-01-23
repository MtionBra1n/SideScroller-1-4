using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShielderEnemyBehaviour : MonoBehaviour
{
    public static readonly int Hash_MovementValue = Animator.StringToHash("MovementValue");
    public static readonly int Hash_ActionTriggerValue = Animator.StringToHash("ActionTrigger");
    public static readonly int Hash_ActionIdValue = Animator.StringToHash("ActionId");
    
    #region Inspektor
    [SerializeField] private Animator anim;
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float chaseSpeed = 4f;
    [SerializeField] private float endAttackTimer = 0.5f;
    [SerializeField] private float patrolAreaWidth = 5f;
    [SerializeField] private GameObject attackTrigger;
    #endregion

    #region Private Variables
    private Rigidbody2D rb;

    private Vector2 patrolStartPos;
    private Transform player;

    private bool isAttacking = false;
    private bool isChasing = false;
    private bool isMovingRight = true;
    private float patrolBoundaryLeft;
    private float patrolBoundaryRight;
    
    #endregion

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        rb = GetComponent<Rigidbody2D>();
        patrolStartPos = transform.position;
        
        patrolBoundaryLeft = patrolStartPos.x - patrolAreaWidth / 2;
        patrolBoundaryRight = patrolStartPos.x + patrolAreaWidth / 2;
    }

    private void Update()
    {
        if (isAttacking) return;
        if (!isChasing)
        {
            Patrol();
        }
        else
        {
            ChasePlayer();
        }
        
        
    }

    private void LateUpdate()
    {
        UpdateAnimator();
    }

    void Patrol()
    {
        if (isMovingRight)
        {
            print("right");
            rb.velocity = new Vector2(patrolSpeed, rb.velocity.y);

            print($"{transform.position.x} > {patrolBoundaryRight}");
            if (transform.position.x > patrolBoundaryRight)
            {
                print("flip");
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(-patrolSpeed, rb.velocity.y);
            if (transform.position.x < patrolBoundaryLeft)
            {
                Flip();
            }
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * chaseSpeed, rb.velocity.y);

        if (direction.x > 0 && !isMovingRight || direction.x < 0 && isMovingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isMovingRight = !isMovingRight;
        transform.eulerAngles = new Vector3(0, isMovingRight ? 0 : 180, 0);
    }

    public void StartDetectPlayer()
    {
        isChasing = true;
    }
    
    public void EndDetectPlayer()
    {
        isChasing = false;
        rb.velocity = Vector2.zero;
    }

    public void AttackPlayer()
    {
        if(isAttacking) return;
        
        attackTrigger.SetActive(false);
        isAttacking = true;
        rb.velocity = Vector2.zero;
        
        AnimAction(10);
    }

    public void EndAttack()
    {
        StartCoroutine(InitiateEndAttack());
    }

    IEnumerator InitiateEndAttack()
    {
        yield return new WaitForSeconds(Random.Range(0, endAttackTimer));
        isAttacking = false;
        attackTrigger.SetActive(true);
    }
    
    #region Animation

    void UpdateAnimator()
    {
        anim.SetFloat(Hash_MovementValue, Mathf.Abs(rb.velocity.x));
    }

    void AnimAction(int actionId)
    {
        anim.SetTrigger(Hash_ActionTriggerValue);
        anim.SetInteger(Hash_ActionIdValue, actionId);
    }
    
    #endregion
}
