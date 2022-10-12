using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAddHealth : Skill
{
    [SerializeField] float addedHealth;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void DoEffect()
    {
        Health playerHealth = player.GetComponent<Health>();

        if (playerHealth)
            playerHealth.AddHealth(addedHealth);
    }
}
