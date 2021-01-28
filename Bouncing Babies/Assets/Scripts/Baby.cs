using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour {
    
    [SerializeField] private float pushForce = 5f;
    [SerializeField] private float pushX = 2.5f;
    [SerializeField] private float pushy = 2.5f;
    
    private Rigidbody2D _rigidbody2D;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {
        _rigidbody2D.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Trampoline")) {
            _rigidbody2D.velocity += new Vector2(pushX,pushy);
            AudioManager.GetInstance().PlayBabyJumpSfx();
        }
    }
}