using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    private Transform _thisTransform;
    private float _speed = 100f;
    private void Start() => _thisTransform = transform;
    public void SetState(bool value) => gameObject.SetActive(value);
    private void Update()=>_thisTransform.Rotate(Vector3.up, Time.deltaTime * _speed);
}
