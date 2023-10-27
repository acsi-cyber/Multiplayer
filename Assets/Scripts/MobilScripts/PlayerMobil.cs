using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobil : MonoBehaviour
{
    public GameManager manager;
    public static int money;
    public Animator anim;
    public Vector2 moveVector;
    public Joystick joystick;
    public AudioClip clip;
    AudioSource playerAudio;

    public float speed = 5.0f; // Скорость движения персонажа
    public float jumpForce = 8.0f; // Сила прыжка
    public LayerMask groundLayer; // Слой земли

    private Rigidbody2D rb;
    private Camera mainCam;
    private bool isGrounded;
    public static bool isJump;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void CameraMovement()
    {
        mainCam.transform.localPosition = new Vector3(transform.position.x, transform.position.y, -1f);
        transform.position = Vector2.MoveTowards(transform.position, mainCam.transform.localPosition, Time.deltaTime);
    }

    public void Update()
    {

        manager.globalMoneyText.text = "Global Money: " + manager.globalMoney;
        manager.moneyText.text = "Money: " + money;

        // Проверяем, находится ли персонаж на земле
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, groundLayer);

        // Получаем ввод с клавиатуры
        moveVector.x = Input.GetAxis("Horizontal");

        // Применяем ввод к Rigidbody для движения
        rb.velocity = new Vector2(joystick.Horizontal * speed, rb.velocity.y);

        if (joystick.Horizontal > 0)
        {
            transform.localScale = new Vector3(0.35f, 0.35f, 0.35f); // Отражение вправо
            if (!playerAudio.isPlaying & isGrounded == true)
            {
                playerAudio.Play();
            }
        }
        else if (joystick.Horizontal < 0)
        {
            transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f); // Отражение влево
            if (!playerAudio.isPlaying & isGrounded == true)
            {
                playerAudio.Play();
            }
        }

        if (isGrounded == false)
        {
            isJump = true;
        }

        else if (isGrounded == true)
        {
            isJump = false;
        }

        CameraMovement();
    }

    public void Jump()
    {
        
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
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
            gameObject.transform.position = new Vector2(0f, 2f);
        }
    }

    public void RpcGlobalMoney()
    {
        manager.globalMoney += 1;
    }
}
