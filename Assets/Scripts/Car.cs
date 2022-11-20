using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float Speed;
    public float Direction;
    public bool Crashed;

    // Start is called before the first frame update
    void Start() {
        var rb = gameObject.GetComponent<Rigidbody2D>();
        rb.rotation = Direction * 180 / Mathf.PI;
    }

    // Update is called once per frame
    void Update() {
        if (Crashed) {
            return;
        }

        var rb = gameObject.GetComponent<Rigidbody2D>();
        var xSpeed = Speed * Time.deltaTime * Mathf.Cos(Direction);
        var ySpeed = Speed * Time.deltaTime * Mathf.Sin(Direction);
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Crashed!");

        Crashed = true;

        var render = gameObject.GetComponent<SpriteRenderer>();
        render.color = Color.red;

        var rb = gameObject.GetComponent<Rigidbody2D>();
        rb.Sleep();
    }
}
