using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable 
{

    [SerializeField] float maxHealth = 3;

    [SerializeField] bool dissablePhysicsSimulation = false;

    [SerializeField] GameObject damageText;

   [SerializeField] HealthBar healthBar = null;

    float currentHealth;

    Animator animator;

    bool IsAlive = true;
    new Rigidbody2D rigidbody;

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;

            if (value < 0)
            {
                print("hit");
                animator.SetTrigger("Hit");
            }


            if (currentHealth <= 0)
            {
                animator.SetTrigger("Defeated");
            }
                
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        if (healthBar != null)
            healthBar.SetMaxHealth(maxHealth);
    }

    void Defeated()
    {
        Destroy(gameObject);
    }

    public void OnHit(int damage, Vector3 otherObjectPosition, float knockbackForce)
    {
        currentHealth -= damage;

        //change healthbar if there is any
        if (healthBar != null)
            healthBar.SetHealth(currentHealth);

        //Damage text
        DamageText damageTextInstance = Instantiate(damageText).GetComponent<DamageText>();
        damageTextInstance.SetDamageNumber(damage.ToString());
        RectTransform rectTransform = damageTextInstance.GetComponent<RectTransform>();
        rectTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        rectTransform.SetParent(canvas.transform);

        animator.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            animator.SetBool("IsAlive", false);

            if (dissablePhysicsSimulation)
                rigidbody.simulated = false;
        }

        //knockback
        IKnockbackable knockbackableObject = gameObject.GetComponent<IKnockbackable>();

        if (knockbackableObject != null && rigidbody && knockbackForce > 0)
        {
            Vector2 knockbackDirection = (transform.position - otherObjectPosition).normalized;
            knockbackableObject.Knockback(knockbackDirection, knockbackForce);
        
        }
    }

    public void AddHealth(float health)
    {
        maxHealth += health;
        currentHealth += health;

    }
}
