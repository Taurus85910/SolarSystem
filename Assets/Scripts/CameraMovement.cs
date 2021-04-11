using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private float _cameraSpeed;
    [Space(10)] [SerializeField] private float _scrollWheelSensitivity;
    [SerializeField] private float _scrollSpeed;
    [SerializeField]  private float _cameraDistance;
    [FormerlySerializedAs("_minDistans")] [SerializeField] private float _minDistance;
    [FormerlySerializedAs("_maxDistans")] [SerializeField] private float _maxDistance;
    
    private Transform _transform;
    private Transform _parent;
    private Vector3 _localRotation;
    private float _scrollWheelInput;
    private bool _isCameraMovementEnabled;
    
    private void Start()
    {
        _transform = transform;
        _parent = _transform.parent;
        transform.position = new Vector3(0,0,_cameraDistance);
        _localRotation = _parent.transform.rotation.eulerAngles;
    }
    private void LateUpdate()
    {
        if ((Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) && Input.GetMouseButton(1))
        {
            _localRotation.x += Input.GetAxis("Mouse X") * _mouseSensitivity;
            _localRotation.y += Input.GetAxis("Mouse Y") * _mouseSensitivity;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            _scrollWheelInput = Input.GetAxis("Mouse ScrollWheel") * _scrollWheelSensitivity;
            _scrollWheelInput *= _cameraDistance * .3f;
            _cameraDistance -= _scrollWheelInput;

            _cameraDistance = Mathf.Clamp(_cameraDistance, _minDistance, _maxDistance);
        }
        

        Quaternion angle = Quaternion.Euler(_localRotation.y, _localRotation.x, 0);
        _parent.rotation = Quaternion.Lerp(_parent.rotation, angle, Time.deltaTime * _cameraSpeed);

        if (Math.Abs(transform.localPosition.z - _cameraDistance) > .01f)
        {
            _transform.localPosition = new Vector3(0, 0,
                Mathf.MoveTowards(transform.localPosition.z, -_cameraDistance, _scrollSpeed * Time.deltaTime));
        }
    }
}