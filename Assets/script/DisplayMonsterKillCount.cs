using UnityEngine;
using UnityEngine.UI;

public class DisplayMonsterKillCount : MonoBehaviour
{
    public Text monsterKillText;

    private void Start()
    {
        if (monsterKillText == null)
        {
            monsterKillText = GetComponent<Text>();
        }
    }

    public void UpdateMonsterKillText(int monsterKillCount)
    {
        if (monsterKillText != null)
        {
            monsterKillText.text = "Monster Kills: " + monsterKillCount.ToString();
        }
    }
}
