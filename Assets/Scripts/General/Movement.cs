using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 1.0f;

    [SerializeField] float collisionOffset = 0.05f;

    [SerializeField] ContactFilter2D contactFilter;

    Vector2 movementInput;

    Rigidbody2D rigidBody;

    Animator animator;
    SpriteRenderer spriteRenderer;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    public enum FaceDirection { left, right }

    FaceDirection faceDirection;

    public FaceDirection LookDirection
    {
        get { return faceDirection; }
    }

    public Vector2 MovementInput
    {
        get { return movementInput; }
        set { movementInput = value; }
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            if (movementInput != Vector2.zero && rigidBody && animator)
            {
                //try moving on x and y
                if (!TryMoving(movementInput))
                {
                    //try moving only in x direction
                    if (movementInput.x < 0 || movementInput.x > 0)
                        TryMoving(new Vector2(movementInput.x, 0));

                    //try moving only on y
                    if (movementInput.y < 0 || movementInput.y > 0)
                        TryMoving(new Vector2(0, movementInput.y));
                }

                animator.SetBool("IsMoving", true);
            }

            else
            {
                animator.SetBool("IsMoving", false);
            }

            //Set animation direction
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
                faceDirection = FaceDirection.left;
            }

            if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
                faceDirection = FaceDirection.right;
            }
        }
            
    }

    public bool TryMoving(Vector2 direction)
    {
        //collision check
        int amountOfCollisions = rigidBody.Cast(direction, contactFilter, castCollisions, (movementSpeed * Time.fixedDeltaTime) + collisionOffset);

        if (amountOfCollisions == 0)
        {
            rigidBody.MovePosition(rigidBody.position + movementSpeed * direction * Time.fixedDeltaTime);
            return true;
        }

        return false;
    }

    public void IncreaseMovementSpeed(float extraSpeed)
    {
        movementSpeed += extraSpeed;
    }
}
