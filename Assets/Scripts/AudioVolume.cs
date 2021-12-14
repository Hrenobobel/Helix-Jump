using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    [Min(0)]
    public float Volume;

    void Update()
    {
        AudioListener.volume = Volume;
    }
}
