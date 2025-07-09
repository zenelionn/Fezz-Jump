using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject platformPrefab;

    //public int platformCount = 300;

    [SerializeField] private float xRange = 5;
    [SerializeField] private float yRangeMin = 0.5f;
    [SerializeField] private float yRangeMax = 2f;

    [SerializeField] private Transform player;
    [SerializeField] private float spawnDistanceAhead = 10f;
    [SerializeField] private float despawnDistanceBelow = 15f;

    private float lastSpawnY = 0f;
    private List<GameObject> activePlatforms = new List<GameObject>();


    // Update is called once per frame
    

    private void Update()
    {
        DespawnPlatforms();

        if (player.position.y + spawnDistanceAhead > lastSpawnY)
        {
            SpawnPlatform();
        }
    }

    private void DespawnPlatforms()
    {
        for (int i = activePlatforms.Count - 1; i >= 0; i--)
        {
            GameObject platform = activePlatforms[i];
            if (platform != null && platform.transform.position.y < player.position.y - despawnDistanceBelow)
            {
                Destroy(platform);
                activePlatforms.RemoveAt(i);
            }
        }
    }


    private void SpawnPlatform()
    {
        float y = lastSpawnY + Random.Range(yRangeMin, yRangeMax);
        float x = Random.Range(-xRange, xRange);
        Vector3 spawnPosition = new Vector3(x, y, 0f);

        GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        activePlatforms.Add(platform);

        lastSpawnY = y;
    }
}
