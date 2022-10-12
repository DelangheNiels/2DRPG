using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{

    [SerializeField] protected int damage;

    [SerializeField] protected float knockbackForce;

    public int Dmg
    {
        get { return damage; }
    }

    public float KnockbackForce
    {
        get { return knockbackForce; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Attack(Movement.FaceDirection faceDirection)
    { }

    public void IncreaseDamage(int extraDamage)
    {
        damage += extraDamage;
        
    }
}
