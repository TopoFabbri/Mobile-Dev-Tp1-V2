using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pool : MonoBehaviour
{
    [Serializable]
    public struct Object
    {
        public GameObject prefab;
        public float odds;
        public int typeId;
    }

    [Header("Spawn Settings:")] [SerializeField]
    protected List<Transform> spawns;

    [SerializeField] protected Object[] prefabs;
    [SerializeField] private bool repeatSpawn;
    [SerializeField] private bool keepSpawning;
    [SerializeField] private float interval = 1f;

    protected List<Object> pool = new();

    private void Awake()
    {
        for (int i = 0; i < prefabs.Length; i++)
            prefabs[i].typeId = i;
    }

    private void Start()
    {
        do
        {
            StartCoroutine(SpawnLoop());
        } while (keepSpawning && spawns.Count > 0);
    }

    /// <summary>
    /// Spawn object, wait for interval, repeat if should
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnLoop()
    {
        SpawnRandomObject();
        yield return new WaitForSeconds(interval);
    }

    /// <summary>
    /// Randomize objects and spawn one
    /// </summary>
    protected void SpawnRandomObject()
    {
        if (spawns.Count <= 0)
            return;

        float totalOdds = 0;
        float[] odds = new float[prefabs.Length];

        for (int i = 0; i < prefabs.Length; i++)
        {
            prefabs[i].prefab.SetActive(true);
            totalOdds += prefabs[i].odds;
            odds[i] = totalOdds;
        }

        float random = Random.Range(0f, totalOdds);

        for (int i = 0; i < prefabs.Length; i++)
        {
            if (random < odds[i])
            {
                int randomSpawn = Random.Range(0, spawns.Count);

                Instantiate(prefabs[i], spawns[randomSpawn].position);

                if (!repeatSpawn)
                {
                    GameObject spawn= spawns[randomSpawn].gameObject;
                    spawns.Remove(spawns[randomSpawn]);
                    Destroy(spawn);
                }

                return;
            }
        }
    }

    /// <summary>
    /// Spawns the given object on scene
    /// </summary>
    /// <param name="obj">Object to spawn</param>
    /// <param name="pos">Position to spawn</param>
    private void Instantiate(Object obj, Vector3 pos)
    {
        GameObject newObject = FindUnusedObject(obj.typeId);

        if (!newObject)
        {
            obj.prefab = Instantiate(obj.prefab, pos, Quaternion.identity);
            obj.prefab.transform.parent = transform;
            pool.Add(obj);
        }
    }

    /// <summary>
    /// Get if there is an unused object and return it
    /// </summary>
    /// <param name="id">type id of the object to find</param>
    /// <returns>Found game object (null if not found)</returns>
    private GameObject FindUnusedObject(int id)
    {
        foreach (Object obj in pool)
        {
            if (!obj.prefab.activeSelf && obj.typeId == id)
                return obj.prefab;
        }

        return null;
    }
}