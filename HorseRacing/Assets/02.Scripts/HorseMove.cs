using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMove : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float minspeed = 2.0f;
    [SerializeField] private float maxspeed = 5.0f;
    private float _moveDistance;
    private float _targetDistance;
    private bool _doMove;

    public bool isFinished
    {
        get
        {
            return _moveDistance >= _targetDistance;
        }
    }

    public void StartMove(float targetDistance)
    {
        _doMove = true;
        _targetDistance = targetDistance;
    }

    private void Awake()
    {
        _transform = transform;
    }
  
    private void FixedUpdate()
    {
        if (_doMove &&
            _moveDistance < _targetDistance)
            Move();
    }

    private void Move()
    {
        float speed = Random.Range(minspeed, maxspeed);
        Vector3 moveVec = Vector3.forward * speed * Time.fixedDeltaTime;
        _transform.Translate(moveVec);
        _moveDistance += moveVec.z;
    }
}
