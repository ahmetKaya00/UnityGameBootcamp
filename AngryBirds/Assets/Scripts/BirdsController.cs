using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsController : MonoBehaviour
{
    Vector2 _startPosition;

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    private float _force = 500;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _startPosition = rigidBody.position;
        rigidBody.isKinematic = true;
    }

    private void OnMouseDown()
    {
        spriteRenderer.color = Color.red;
    }

    private void OnMouseUp()
    {
        Vector2 currentPosition = rigidBody.position;
        Vector2 _direction = _startPosition - currentPosition;
        _direction.Normalize();
        rigidBody.isKinematic = false;
        rigidBody.AddForce(_direction * _force);

        spriteRenderer.color = Color.white;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        rigidBody.position = _startPosition;
        rigidBody.isKinematic = true;
        rigidBody.velocity = Vector2.zero;
    }
}
