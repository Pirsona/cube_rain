using System;
using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private int _minTimeActive;
    [SerializeField] private int _maxTimeActive;

    public event Action<Cube> LifeTimeEnd;

    private bool _isNotHiting = true;

    private void OnEnable()
    {
        _collisionDetector.CollisionWithFloor += ConnectionWithFloor;
    }

    private void OnDisable()
    {
        _collisionDetector.CollisionWithFloor -= ConnectionWithFloor;
    }

    private void ConnectionWithFloor()
    {
        if(_isNotHiting)
        {
            _isNotHiting = false;
            _colorChanger.SetColor();

            StartCoroutine(StartDecay());
        }
    }

    private IEnumerator StartDecay()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(_minTimeActive,_maxTimeActive));
        LifeTimeEnd?.Invoke(this);
    }

    public void SetNormalStatus()
    {
        _isNotHiting = true;
        _colorChanger.SetDefaultColor();
    }
}