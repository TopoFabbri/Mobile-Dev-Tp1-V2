using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteAlways]
public class Gameobjs : MonoBehaviour
{
    public bool run;
    public List<Transform> objs;

    private void Update()
    {
        if (!run)
            return;

        run = false;

        for (int i = 0; i < objs.Count; i++)
        {
            
            GameObject go = Instantiate(new GameObject("BoxSpawn"), objs[i].position, objs[i].rotation, transform);
            objs[i].parent = go.transform;
        }
    }
}