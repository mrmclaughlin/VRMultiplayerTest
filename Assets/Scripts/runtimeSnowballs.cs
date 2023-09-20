using UnityEngine;
using System.Collections.Generic;

public class runtimeSnowballs : MonoBehaviour
{
    public GameObject snowballPrefab;  // Drag your snowball prefab here
    public int numberOfSnowballs = 50; // Number of snowballs in the pile
    public float areaRadius = 2f;      // Radius of the pile

    void Start()
    {
        for (int i = 0; i < numberOfSnowballs; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-areaRadius, areaRadius),
                Random.Range(0, areaRadius),
                Random.Range(-areaRadius, areaRadius)
            );

            Instantiate(snowballPrefab, randomPosition + transform.position, Quaternion.identity);
        }
    }
}