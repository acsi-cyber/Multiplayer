using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public GameManager manager;
    public int money;

    public float speed = 5.0f; // Скорость движения персонажа
    public float jumpForce = 8.0f; // Сила прыжка
    public LayerMask groundLayer; // Слой земли

    private Rigidbody2D rb;
    private Camera mainCam;
    private bool isGrounded;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void CameraMovement()
    {
        mainCam.transform.localPosition = new Vector3(transform.position.x, transform.position.y, -1f);
        transform.position = Vector2.MoveTowards(transform.position, mainCam.transform.localPosition, Time.deltaTime);
    }
        
    private void Update()
    {
        if (!isLocalPlayer) return;

        manager.globalMoneyText.text = "Global Money: " + manager.globalMoney;
        manager.moneyText.text = "Money: " + money;

        // Проверяем, находится ли персонаж на земле
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, groundLayer);

        // Получаем ввод с клавиатуры
        float moveX = Input.GetAxis("Horizontal");

        // Применяем ввод к Rigidbody для движения
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if (moveX > 0)
        {
            transform.localScale = new Vector3(0.35f, 0.35f, 0.35f); // Отражение вправо
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f); // Отражение влево
        }

        // Прыжок
        if (isGrounded & Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        CameraMovement();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Apple")
        {
            Destroy(collider.gameObject);
            money += 1;

            RpcGlobalMoney();
        }

        if (collider.gameObject.tag == "Trap")
        {
            if (!isLocalPlayer) return;
            gameObject.transform.position = new Vector2(0f, 2f);
        }
    }

    [ClientRpc]
    public void RpcGlobalMoney()
    {
        manager.globalMoney += 1;
    }
}
