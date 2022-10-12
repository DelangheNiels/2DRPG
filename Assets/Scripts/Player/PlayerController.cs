using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IKnockbackable
{
    [SerializeField] SwordAttack swordAttack;

    [SerializeField] SkillTree skillTree;

    [SerializeField] int skillPoints = 10;

    Movement movementComp;

    Animator animator;

    Rigidbody2D rigidbody;

    public int SkillPoints
    {
        get { return skillPoints; }
        set { skillPoints = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
      
        movementComp = GetComponent<Movement>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue movementValue)
    {
        movementComp.MovementInput = movementValue.Get<Vector2>();
    }

    void OnAttack()
    {
        animator.SetTrigger("SwordAttack");
        swordAttack.Attack(movementComp.LookDirection);

    }

   void LockMovement()
    {
        movementComp.CanMove = false;
    }

    void UnlockMovement()
    {
        movementComp.CanMove = true;
        swordAttack.StopAttacking();
    }

    public void Knockback(Vector2 direction, float force)
    {
        print("knock back player");
        rigidbody.AddForce(direction * force, ForceMode2D.Impulse);
    }

    void OnToggleSkillTree()
    {
        skillTree.ToggleSkillTree();
    }

    public BasicAttack GetAttack()
    {
        return swordAttack;
    }

    
}
