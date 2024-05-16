using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLife : MonoBehaviour
{
    public Text lifeText;
    public void UpdateLifeText(int life)
    {
        if (lifeText != null)
        {
            lifeText.text = "Life: " + life.ToString();
        }
    }
}
