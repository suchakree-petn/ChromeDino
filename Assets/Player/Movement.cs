using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Collider2D _collider;
    [SerializeField] private float jumeForce = 30f;
    private float changecol = 0.185f;
    private float currentPosition, startPosition, originColider;
    private bool jump = false;
    public bool slide = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position.y;
        originColider = _collider.offset.y;
    }

    void Update()
    {
        currentPosition = rb.position.y;
        if (Input.GetKeyDown(KeyCode.Space) && jump == false && slide == false)
        {
            jump = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.AddForce(transform.up * jumeForce, ForceMode2D.Impulse);
        }
        if (currentPosition < startPosition)
        {
            rb.velocity = Vector2.zero;
            rb.position = new Vector3(0, startPosition, 0);
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            jump = false;
        }
        if (Input.GetKeyDown(KeyCode.S) && jump == false)
        {
            slide = true;
            _collider.offset = new Vector2(_collider.offset.x, _collider.offset.y - changecol);
        }
        else if (Input.GetKeyUp(KeyCode.S) && jump == false)
        {
            slide = false;
            _collider.offset = new Vector2(_collider.offset.x, originColider);
        }
    }
}
