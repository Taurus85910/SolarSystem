using Unity.VisualScripting;
using UnityEngine;

public class Planet : CelestialBody
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;
    private float _angle;
    private float _timer = 0.5f;
    private float _elapsedTime;
    private bool _isStarted = false;
    private void Start()
    {
        transform.position = new Vector3(_radius, 0, 0);
        
        _angle = Random.Range(1f, 2f);
        
    }

    public float GetRadius() => _radius;
    protected override void Move()
    {
        if (!_isStarted)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _timer)
            {
                GetComponent<TrailRenderer>().enabled = true;
                _isStarted = true;
            }
        }

        _angle += Mathf.Deg2Rad * Time.deltaTime * _speed;

        if (_angle > 2 * Mathf.PI)
            _angle = 0;

        Vector3 position = transform.position;
        Vector3 parentPosition = transform.parent.position;
        position = Vector3.MoveTowards(position,
            new Vector3(Mathf.Cos(_angle) * _radius + parentPosition.x, position.y, 
                Mathf.Sin(_angle) * _radius + parentPosition.z), Mathf.Infinity);
        transform.position = position;
    }
} 
