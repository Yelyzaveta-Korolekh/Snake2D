using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{
    [SerializeField] BoxCollider2D gridArea;
    private ScoreCounter appleCounter;

    private void Start()
    {
        RandomizePos();
    }

    private void RandomizePos()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
        appleCounter = FindObjectOfType<ScoreCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RandomizePos();
            appleCounter.IncrementAppleCount();
        }
    }
}
