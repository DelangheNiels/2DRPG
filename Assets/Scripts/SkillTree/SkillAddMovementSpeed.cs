using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAddMovementSpeed : Skill
{
    [SerializeField] float addedMovementSpeed;

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
        Movement playerMovement = player.GetComponent<Movement>();

        if (playerMovement)
            playerMovement.IncreaseMovementSpeed(addedMovementSpeed);
            
    }
}
