using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetectionZone : MonoBehaviour
{
    public List<Collider2D> detectableObjects = new List<Collider2D>();

    Collider2D detectionZone;

    [SerializeField] const string detectionTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        detectionZone = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals(detectionTag))
            detectableObjects.Add(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals(detectionTag))
            detectableObjects.Remove(collider);
    }
}
