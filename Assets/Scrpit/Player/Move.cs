using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 input;
    private Rigidbody2D rigidbody2D;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = input * _speed;
    }
}
