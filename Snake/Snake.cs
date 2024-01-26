using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    public GameObject retry;
    public GameObject gameplay;
    public float moveSpeed;
    private Rigidbody2D rb;

    private List<Transform> _snakeSpawn;
    public Transform snakePrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity =  new Vector2(moveSpeed,0);

        _snakeSpawn = new List<Transform>();
        _snakeSpawn.Add(this.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(0,moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = new Vector2(0,-moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed,0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed,0);
        }
    }

    private void FixedUpdate()
    {
        for (int i = _snakeSpawn.Count -1 ; i > 0; i --)
        {
            _snakeSpawn[i].position = _snakeSpawn[i-1].position;
        }
    }

    private void grow()
    {
        Transform snakeSpawn = Instantiate(this.snakePrefab);
        snakeSpawn.position = _snakeSpawn[_snakeSpawn.Count - 1].position;

        _snakeSpawn.Add(snakeSpawn);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SnakeFood"))
        {
            grow();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            retry.SetActive(true);
            gameplay.SetActive(false);
        }
    }

    public void NewGame()
    {
        retry.SetActive(false);
        gameplay.SetActive(true);
        this.transform.position = new Vector3(3f,0f,0f);
    }

    
}
