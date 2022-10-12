using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{

    [SerializeField] GameObject skillTreeHUD;

    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        skillTreeHUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowSkillTree()
    {
        skillTreeHUD.SetActive(true);
        isVisible = true;
        Time.timeScale = 0.0f;
    }

    void HideSkillTree()
    {
        skillTreeHUD.SetActive(false);
        isVisible = false;
        Time.timeScale = 1.0f;
    }

    public void ToggleSkillTree()
    {
        if (isVisible)
            HideSkillTree();
        else
            ShowSkillTree();
    }
}
