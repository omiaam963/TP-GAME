using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class Enemy : MonoBehaviour
{
private string currentState = "IdleState";
private Transform target;
public float chaseRage = 5;
public float attackRange = 2;
public float speed = 3;
public int health;
public int maxHealth;

public Animator animator;
void Start()
{
target = GameObject.FindGameObjectWithTag("Player").transform;
health = maxHealth;
}
void Update()
{
float distance = Vector3.Distance(transform.position, target.position);
if (currentState == "IdleState")
{
if (distance < chaseRage)

currentState = "ChaseState";
}else if (currentState == "ChaseState")
{
//Play the run animation
animator.SetTrigger("chase");
animator.SetBool("isAttacking", false);
if(distance < attackRange)
{
currentState = "AttackState";
}
//Move towards the player
if(target.position.x > transform.position.x)
{
//move right
transform.Translate(transform.right * speed * Time.deltaTime);
transform.rotation = Quaternion.Euler(0, 180, 0);
}
else
{
//move left
transform.Translate(-transform.right * speed * Time.deltaTime);
transform.rotation = Quaternion.identity;
}
}else if (currentState == "AttackState")
{
animator.SetBool("isAttacking", true);
if (distance > attackRange)
{
currentState = "ChaseState";
}
}
}
public void TakeDamage(int damage)
{
health -= damage;
currentState = "ChaseState";
if (health < 0)
{
Die();
}
}
private void Die()
{

//animación muerte
animator.SetTrigger("isDead");
//desactivar script y colisionador
GetComponent<CapsuleCollider>().enabled = false;
this.enabled = false;
}
}