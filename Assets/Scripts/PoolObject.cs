using UnityEngine;
using UnityEngine.Pool;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _countPoolObject;
    [SerializeField] private int _maximumCountPoolObject;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(CreateObject, ActivateCube, DeactivateCube, DestroyCube, true, _countPoolObject, _maximumCountPoolObject);
    }

    private void ReturnObject(Cube cube)
    {
        _pool.Release(cube);
    }

    private Cube CreateObject()
    {
        Cube cubeObject = Instantiate(_cube);
        cubeObject.LifeTimeEnd += ReturnObject;
        return cubeObject;
    }

    private void ActivateCube(Cube cubeObject)
    {
        cubeObject.gameObject.SetActive(true);
    }

    private void DeactivateCube(Cube cubeObject)
    {
        cubeObject.SetNormalStatus();
        cubeObject.gameObject.SetActive(false);
    }

    private void DestroyCube(Cube cubeObject)
    {
        Destroy(cubeObject.gameObject);
    }

    public Cube GetCube()
    {
        return _pool.Get();
    }
}