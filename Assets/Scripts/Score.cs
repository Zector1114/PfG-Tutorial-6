using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class Score : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI scoreText;

    public void ScoreUpdater(float ammoDisplay)
    {
        scoreText.text = "Ammo: " + ammoDisplay.ToString();
    }

    private static Score instance = null;

    private void Start()
    {
        instance = this;
    }

    public static Score Instance
    {
        get
        {
            return instance;
        }
    }
}