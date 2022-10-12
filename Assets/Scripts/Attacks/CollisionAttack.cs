using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAttack : BasicAttack
{

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health healthComp = collision.GetComponent<Health>();

        if (healthComp)
        {
            healthComp.OnHit(damage, transform.position, knockbackForce);
        }
    }
}
