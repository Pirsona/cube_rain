using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Cube : MonoBehaviour
{
    [SerializeField] ColorChanger _colorChanger;
    [SerializeField] private int _minTimeActive;
    [SerializeField] private int _maxTimeActive;

    private ObjectPool<Cube> _poolSpawn;
    private bool _isNotHiting = true;
 
    private void OnCollisionEnter(Collision collision)
    {
        if (_isNotHiting && collision.transform.TryGetComponent(out Floor floor))
        {
            _isNotHiting = false;
            _colorChanger.SetColor();

            StartCoroutine(StartDecay());
        }
    }

    private IEnumerator StartDecay()
    {
        yield return new WaitForSeconds(Random.Range(_minTimeActive,_maxTimeActive));
        _poolSpawn.Release(this);
    }

    public void SetPool(ObjectPool<Cube> pool)
    {
        _poolSpawn = pool;
    }

    public void SetNormalStatus()
    {
        _isNotHiting = true;
        _colorChanger.SetDefaultColor();
    }
}