using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform FinishPlatform;
    public Slider Slider;
    public float PlayerOffset = 1f;

    private float _startY;
    private float _reachedY;

    private void Start()
    {
        _startY = Player.transform.position.y;
    }

    private void Update()
    {
        _reachedY = Mathf.Min(_reachedY, Player.transform.position.y);
        float finishY = FinishPlatform.transform.position.y;
        float t = Mathf.InverseLerp(_startY, finishY + PlayerOffset, _reachedY);
        Slider.value = t;
    }
}
