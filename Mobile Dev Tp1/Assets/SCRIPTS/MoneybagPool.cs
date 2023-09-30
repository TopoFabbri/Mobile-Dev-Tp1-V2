using System.Collections.Generic;
using UnityEngine;

public class MoneybagPool : MonoBehaviour
{
    [SerializeField] private List<Transform> spawns;
    [SerializeField] private GameObject prefab;
    
    private List<GameObject> moneyBags = new();

    private void Awake()
    {
        spawns.ForEach(spawn => Instantiate(spawn.position));
    }

    private void Instantiate(Vector3 position)
    {
        GameObject moneyBag = FindUnusedBag();
        
        if (!moneyBag)
            moneyBags.Add(Instantiate(prefab, position, Quaternion.Euler(-90f, 0f, 0f)));
    }

    private GameObject FindUnusedBag()
    {
        foreach (GameObject moneyBag in moneyBags)
        {
            if (!moneyBag.activeSelf)
                return moneyBag;
        }
        
        return null;
    }
}