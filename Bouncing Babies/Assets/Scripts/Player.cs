using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed = 2f;

    private float _minX, _maxX;

    private Camera _mainCam;
    private Vector2 _moveToPosition;

    private void Awake() {
        _mainCam = Camera.main;
        SetupMoveBoundries();
    }

    void Update() {
        HandleMovement();
    }

    private void SetupMoveBoundries() {
        _minX = _mainCam.ViewportToWorldPoint(new Vector3(0.15f, 0, 0)).x;
        _maxX = _mainCam.ViewportToWorldPoint(new Vector3(0.8f, 0, 0)).x;
    }

    private void HandleMovement() {
        if (Input.GetMouseButton(0)) {
            Vector2 touchPosition = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            float deltaX = touchPosition.x * moveSpeed * Time.deltaTime;
            float newPositionX = deltaX + transform.position.x;
            if (newPositionX >= _minX && newPositionX <= _maxX) {
                _moveToPosition.x = newPositionX;
                _moveToPosition.y = transform.position.y;
                transform.position = _moveToPosition;
            }
        }
    }

}