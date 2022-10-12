using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillConnection : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Image image;

    [SerializeField] Color lockedColor;

    [SerializeField] Color unlockableColor;

    [SerializeField] Skill skill;

    void Start()
    {
        image.color = lockedColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUnlockable()
    {
        image.color = unlockableColor;
        skill.SetUnlockable();
    }


}
