using UnityEngine;

//TODO Satisfaction with color
public class ClientSpawner : MonoBehaviour
{
    private Transform[] clientSpawnPoints = new Transform[3];

    private void Start()
    {
        for (int i = 0; i < clientSpawnPoints.Length; i++)
        {
            clientSpawnPoints[i] = gameObject.transform.GetChild(i);
        }
    }
}