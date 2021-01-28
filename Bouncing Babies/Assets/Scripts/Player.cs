using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed = 2f;

    private float minX, maxX;

    private Camera _mainCam;
    private Vector2 moveToPosition;

    private void Awake() {
        _mainCam = Camera.main;
        SetupMoveBoundries();
    }

    void Update() {
        HandleMovement();
    }

    private void SetupMoveBoundries() {
        minX = _mainCam.ViewportToWorldPoint(new Vector3(0.15f, 0, 0)).x;
        maxX = _mainCam.ViewportToWorldPoint(new Vector3(0.8f, 0, 0)).x;
    }

    private void HandleMovement() {
        if (Input.GetMouseButton(0)) {
            Vector2 touchPosition = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            float deltaX = touchPosition.x * moveSpeed * Time.deltaTime;
            float newPositionX = deltaX + transform.position.x;
            if (newPositionX >= minX && newPositionX <= maxX) {
                moveToPosition.x = newPositionX;
                moveToPosition.y = transform.position.y;
                transform.position = moveToPosition;
            }
        }
        /*if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = _mainCam.ScreenToWorldPoint(touch.position);
            float newPosX = transform.position.x + touchPosition.x;
            print(newPosX);
            if (touchPosition.x > minX && touchPosition.x < maxX) {
                Vector2 moveToPosition = Vector2.MoveTowards(transform.position, touchPosition, moveSpeed * Time.deltaTime);
                moveToPosition.y = transform.position.y; //keep the same Y all the time
                transform.position = moveToPosition; //update to new position
            }
        }*/
    }

}