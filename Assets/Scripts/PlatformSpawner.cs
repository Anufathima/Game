using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int initialPlatforms = 5;
    public float platformLength = 10f;
    public Transform player;

    private List<GameObject> activePlatforms = new List<GameObject>();
    private float spawnPositionZ = 0f;
    private float safeZone = 15f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<initialPlatforms; i++)
        {
            SpawnPlatform();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            Debug.LogWarning("Player referenc is missing in PlatformSpawner script.");
            return;
        }
        if(player.position.z-safeZone>(spawnPositionZ-(initialPlatforms*platformLength)))
        {
            SpawnPlatform();
            DeleteOldPlatform();
        }
        
    }

    void SpawnPlatform()
    {
        GameObject newPlatform = Instantiate(platformPrefab, new Vector3(0,0,spawnPositionZ),Quaternion.identity);
        activePlatforms.Add(newPlatform);
        spawnPositionZ += platformLength;
    }

    void DeleteOldPlatform()
    {
        Destroy(activePlatforms[0]);
        activePlatforms.RemoveAt(0);
    }
}
