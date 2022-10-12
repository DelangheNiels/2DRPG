using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : BasicAttack
{

    public Collider2D swordCollider;

    Vector2 rightSwordOffset;

    // Start is called before the first frame update
    void Start()
    {
        rightSwordOffset = transform.position;
    }

    void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightSwordOffset.x *-1, rightSwordOffset.y);
    }

    void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightSwordOffset;
    }

    public void StopAttacking()
    {
        swordCollider.enabled = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag.Equals("Enemy"))
        {

            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth)
                enemyHealth.OnHit(damage, transform.parent.position,knockbackForce);
        }
    }

    public override void Attack(Movement.FaceDirection faceDirection)
    {
        if (faceDirection == Movement.FaceDirection.left)
            AttackLeft();
        else
            AttackRight();
    }
}
