using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingDistances : MonoBehaviour
{
    // set the culling distances and culling shape
    void Start()
    {
        // distances
        Camera camera = GetComponent<Camera>();
        float[] distances = new float[32];
        distances[0] = 100;
        camera.layerCullDistances = distances;

        // shape
        camera.layerCullSpherical = true;
    }
}
