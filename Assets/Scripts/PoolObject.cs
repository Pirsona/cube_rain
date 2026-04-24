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
        _pool = new ObjectPool<Cube>(CreateObject, ActionOnGet, ActionOnRelease, ActionOnDestroy, true, _countPoolObject, _maximumCountPoolObject);
    }

    public Cube CreateObject()
    {
        Cube cubeObject = Instantiate(_cube);
        cubeObject.SetPool(_pool);

        return cubeObject;
    }

    public void ActionOnGet(Cube cubeObject)
    {
        cubeObject.gameObject.SetActive(true);
    }

    public void ActionOnRelease(Cube cubeObject)
    {
        cubeObject.SetNormalStatus();
        cubeObject.gameObject.SetActive(false);
    }

    public void ActionOnDestroy(Cube cubeObject)
    {
        Destroy(cubeObject.gameObject);
    }

    public Cube GetCube()
    {
        return _pool.Get();
    }
}