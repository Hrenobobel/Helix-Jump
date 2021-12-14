using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player player;
    public Vector3 PlatformCameraOffset;
    public float Speed;

    void Update()
    {
        if (player.CurrentPlatform == null) return;

        Vector3 targetposition = player.CurrentPlatform.transform.position + PlatformCameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, targetposition,Speed * Time.deltaTime);
    }
}
