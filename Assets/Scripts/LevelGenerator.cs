using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float DistanceBetweenPlatforms;
    public Transform FinishPlatform;
    public Transform CylinderRoot;
    public Game Game;

    private void Awake()
    {
        int LevelIndex = Game.LevelIndex;
        Random random = new Random(LevelIndex);
        int platformsCount = RandomRange(random, MinPlatforms, MaxPlatforms);

        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, PlatformPrefabs.Length);

            GameObject PlatformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(PlatformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);
        }
        FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);
        CylinderRoot.localScale = new Vector3(1, platformsCount * DistanceBetweenPlatforms + CylinderRoot.localPosition.y, 1);
    }

    private int RandomRange(Random random, int min, int maxExlusive)
    {
        int number = random.Next();
        int length = maxExlusive - min;
        number %= length;
        return min + number;
    }

    private float RandomRange(Random random, float min, float maxExlusive)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, maxExlusive, t);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlatforms * platformIndex, 0);
    }
}