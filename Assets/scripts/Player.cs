using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 

    private Vector3 direction;

    public float gravity = -9.8f;

    public float strength = 5f;

    private void OnEnable()
    {
        Vector3 position = transform.position;

        position.y = 0f;

        transform.position = position;

        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ostacolo")
        {

            FindObjectOfType<GameManager>().GameOver(); 

        } else if (other.gameObject.tag == "Scoring") {

            FindObjectOfType<GameManager>().IncreaseScore();

        }

    }   
}
