using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Taxis : MonoBehaviour
{
    public bool run;
    public List<Transform> taxies;

    private void Update()
    {
        if (!run)
            return;

        run = false;

        foreach (Transform taxi in taxies)
        {
            GameObject go = Instantiate(new GameObject(), taxi.position, Quaternion.identity);
            taxi.parent = go.transform;
        }
    }
}