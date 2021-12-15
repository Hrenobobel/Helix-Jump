using UnityEngine;
using UnityEngine.UI;

public class BestScores : MonoBehaviour
{
    public Text Text;
    public Player player;

    private void Update()
    {
        Text.text = ("BEST: " + (player.Record).ToString());
    }
}
