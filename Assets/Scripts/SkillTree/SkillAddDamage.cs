using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAddDamage : Skill
{

    [SerializeField] int addedDamage;

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
        player.GetAttack().IncreaseDamage(addedDamage);
    }
}
