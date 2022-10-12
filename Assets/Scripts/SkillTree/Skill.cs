using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMeshProTextBox;

    [SerializeField] string descriptionText;

    [SerializeField] Image statusImage;

    bool isActivated = false;
    [SerializeField] bool canBeActivated = false;

    [SerializeField] Color unlockableColor;

    [SerializeField] List<SkillConnection> connectionList;

    [SerializeField] protected PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        if(!isActivated && canBeActivated && player.SkillPoints > 0)
        {
            player.SkillPoints--;

            statusImage.gameObject.SetActive(false);

            foreach (var connection in connectionList)
            {
                connection.SetUnlockable();
            }

            DoEffect();
        }
    }

    public void SetUnlockable()
    {
        canBeActivated = true;
        statusImage.color = unlockableColor;
    }

    protected virtual void DoEffect() { }

    //Added this functon because base start does not get called in children
    protected void Initialize()
    {
        textMeshProTextBox.SetText(descriptionText);

        if (canBeActivated)
            SetUnlockable();
    }
}
