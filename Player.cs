using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject deadEffectObj;
    public GameObject itemEffectObj;

    Rigidbody2D rb;
    float angle = 0;

    int xSpeed = 3;
    public int ySpeed = 30;

    public bool isDead = false;

    float hueValue;

    GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Start()
    {
        hueValue = Random.Range(0, 10) / 10.0f;
        SetBackgroundColor();
    }

    void Update()
    {
        if (isDead == true) return;
        MovePlayer();
        GetInput();
        CheckTime();

    }

    void MovePlayer()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 3;
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
    }

    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(new Vector2(0, ySpeed));
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                rb.AddForce(new Vector2(0, -ySpeed/2f));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Dead();
        }
        else if (collision.gameObject.tag == "Item")
        {
            GetItem(collision);
        }

    }

    void GetItem(Collider2D collision)
    {
        SetBackgroundColor();

        gameManager.AddScore();
        gameManager.AddTime();
        Destroy(Instantiate(itemEffectObj, collision.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(collision.gameObject.transform.parent.gameObject);
    }

    void Dead()
    {
        Destroy(Instantiate(deadEffectObj, transform.position, Quaternion.identity), 0.5f);

        StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());

        isDead = true;
        StopPlayer();

        gameManager.CallGameOver();
        Debug.Log("volal si ma?");

    }

    void StopPlayer()
    {
        rb.velocity = new Vector2(0, 0);

        if (isDead == true) rb.isKinematic = false;
    }

    void CheckTime()
    {
        if (gameManager.timeLeft < 0)
        {
            Dead();
        }
    }

    void SetBackgroundColor()
    {
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);
        hueValue += 0.1f;
        if (hueValue >= 1)
        {
            hueValue = 0;
        }
    }

    

} 
