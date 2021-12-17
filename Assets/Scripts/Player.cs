using Assets.Scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody RigidBody;
    public Game Game;
    public Platform CurrentPlatform;
    public Material DissolveMaterial;

    public GameObject LoseParticle;
    public GameObject WinParticle;
    public Transform FinishPlatform;
    public Vector3 Confettivector1;
    public Vector3 Confettivector2;

    public AudioClip AudioClip;
    [Min(0)]
    public float Volume;

    private AudioSource _audio;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void ReachedFinish()
    {
        Quaternion Rotation1 = Quaternion.Euler(Confettivector1);
        Instantiate(WinParticle, transform.position, Rotation1);

        Quaternion Rotation2 = Quaternion.Euler(Confettivector2);
        Instantiate(WinParticle, transform.position, Rotation2);

        Game.OnPlayerReachedFinish(); 
        RigidBody.velocity = Vector3.zero;

        if (Scores > Record)
            Record = Scores;
    }

    public void Bounce()
    {
        RigidBody.velocity = new Vector3(0, BounceSpeed, 0);

        _audio.Play();
    }

    public void Die()
    {
        _audio.PlayOneShot(AudioClip, Volume);
        Instantiate(LoseParticle, transform);

        Game.OnPlayerDie();
        RigidBody.velocity = Vector3.zero;

        Renderer SectorRenderer = GetComponent<Renderer>();
        SectorRenderer.sharedMaterial = DissolveMaterial;

        Scores = 0;
    }
    public int Scores
    {
        get => PlayerPrefs.GetInt(ScoresKey, 0);
        set
        {
            PlayerPrefs.SetInt(ScoresKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string ScoresKey = "Scores";

    public int Record
    {
        get => PlayerPrefs.GetInt(RecordKey, 0);
        set
        {
            PlayerPrefs.SetInt(RecordKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string RecordKey = "Record";
}
