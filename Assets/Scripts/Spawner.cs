using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PoolObject _poolSpawn;
    [SerializeField] private int _cooldown;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_cooldown);
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return _wait;
            Cube spawnedCube = _poolSpawn.GetCube();
            spawnedCube.gameObject.transform.position = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 center = transform.position;
        Vector3 extents = transform.localScale / 2f;

        float xPosition = Random.Range(center.x - extents.x, center.x + extents.x);
        float zPosition = Random.Range(center.z - extents.z, center.z + extents.z);

        Vector3 positionCube = new Vector3(xPosition, center.y, zPosition);

        return positionCube;
    }
}