using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float timeToLive = 1.0f;
    [SerializeField] float floatSpeed = 300.0f;
    [SerializeField] Vector3 floatDirection = new Vector3(0, 1, 0);
    [SerializeField]TextMeshProUGUI textMeshPro;

    RectTransform rectTransform;
    Color startingColor;

    float elasedTime = 0.0f;

    void Start()
    {
        startingColor = textMeshPro.color;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        textMeshPro.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (elasedTime / timeToLive));

        elasedTime += Time.deltaTime;

        if (elasedTime >= timeToLive)
            Destroy(gameObject);
    }

    public void SetDamageNumber(string damageNumber)
    {
        textMeshPro.text = damageNumber;
    }
}
