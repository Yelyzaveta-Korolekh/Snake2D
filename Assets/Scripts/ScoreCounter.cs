using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoBehaviour
{
    private static int applesCollected = 0;
    private string score;
    [SerializeField] TextMeshProUGUI textMesh;
    private void Start()
    {
        score = textMesh.text;
        textMesh.text += "0";
    }
    public void IncrementAppleCount()
    {
        applesCollected++;
        Debug.Log("Apples Collected: " + applesCollected);
        ChangeScore();
    }

    private void ChangeScore()
    {
        textMesh.text = score + applesCollected;
    }
}
