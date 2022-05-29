using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    private const float DISTANCE_OFFSET = 0.1f;

    [SerializeField] private float _movementSpeed = 5f;

    private Vector2 _destination;

    private void Start()
    {
        _destination = transform.position;
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _destination) > DISTANCE_OFFSET)
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, _movementSpeed * Time.deltaTime);
        }
    }

    public void MoveTo(Vector2 destination)
    {
        _destination = destination;
    }
}
