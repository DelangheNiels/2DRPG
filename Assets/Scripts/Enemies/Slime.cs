using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IKnockbackable
{
    [SerializeField] ObjectDetectionZone objectDetectionZone;

    [SerializeField] Rigidbody2D rigidbody;

    Movement movementComp;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
        movementComp = GetComponent<Movement>();
    }

    void FixedUpdate()
    {
        if(objectDetectionZone.detectableObjects.Count > 0)
        {
            Vector3 direction = (objectDetectionZone.detectableObjects[0].transform.position - transform.position).normalized;
            rigidbody.AddForce(direction * movementComp.MovementSpeed * Time.fixedDeltaTime);
            //print(direction * movementComp.MovementSpeed);
            //Vector3 newPos = transform.position + (direction * 1000 * Time.deltaTime);
            //transform.position.Set(newPos.x, newPos.y, newPos.z);
            
        }
    }

    public void Knockback(Vector2 direction, float force)
    {
        rigidbody.AddForce(direction * force);
    }
}
