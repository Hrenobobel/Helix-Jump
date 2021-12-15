using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text Text;
    public Player player;

    private void Update()
    {
        Text.text = (player.Scores).ToString();
    }
}
