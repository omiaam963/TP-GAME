using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
public CharacterController controller;
private Vector3 direction;
public float speed = 9;
public float jumpForce = 9;
public float gravity = -18;
public Transform groundCheck;
public LayerMask groundLayer;
public bool ableToMakeADoubleJump = true;
public Animator animator;
public Transform model;
// Start is called before the first frame update
void Start()
{
}
// Update is called once per frame
void Update()
{
if (PlayerManager.gameOver)
{
animator.SetTrigger("die");
this.enabled= false;
}
float hinput = Input.GetAxis("Horizontal");
direction.x = hinput * speed;
animator.SetFloat("speed", Mathf.Abs(hinput));
bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
animator.SetBool("isGrounded", isGrounded);
if (isGrounded)
{
direction.y = 0;
ableToMakeADoubleJump = true;

if (Input.GetButtonDown("Jump"))
{
Jump();
}
if(Input.GetKeyDown(KeyCode.F))
{
animator.SetTrigger("FireballAttack");
}
if(Input.GetKeyDown(KeyCode.G))
{
animator.SetTrigger("SuperFireballAttack");
}
}
else
{
direction.y += gravity * Time.deltaTime;
if (ableToMakeADoubleJump & Input.GetButtonDown("Jump"))
{
DoubleJump();
}
}
if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fireball Attack"))
return;
if (animator.GetCurrentAnimatorStateInfo(0).IsName("Super Fireball Attack"))
return;
if (hinput != 0)
{
Quaternion newRotation = Quaternion.LookRotation(new Vector3(hinput, 0, 0));
model.rotation = newRotation;
}
controller.Move(direction * Time.deltaTime);
if(transform.position.z !=0)
transform.position=new Vector3(transform.position.x,transform.position.y,0);
}
private void DoubleJump()
{
animator.SetTrigger("doubleJump");
direction.y = jumpForce;
ableToMakeADoubleJump = false;
}
private void Jump()
{
direction.y = jumpForce;
}
}