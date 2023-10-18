using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public GameManager manager;
    public int money;
    public Animator anim;
    public Vector2 moveVector;

    public float speed = 5.0f; // �������� �������� ���������
    public float jumpForce = 8.0f; // ���� ������
    public LayerMask groundLayer; // ���� �����

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
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        anim = GameObject.FindGameObjectWithTag("Animator").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void CameraMovement()
    {
        mainCam.transform.localPosition = new Vector3(transform.position.x, transform.position.y, -1f);
        transform.position = Vector2.MoveTowards(transform.position, mainCam.transform.localPosition, Time.deltaTime);
    }

    public void Update()
    {
        if (!isLocalPlayer) return;

        manager.globalMoneyText.text = "Global Money: " + manager.globalMoney;
        manager.moneyText.text = "Money: " + money;

        // ���������, ��������� �� �������� �� �����
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, groundLayer);

        // �������� ���� � ����������
        moveVector.x = Input.GetAxis("Horizontal");

        // ��������� ���� � Rigidbody ��� ��������
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);

        if (moveVector.x > 0)
        {
            transform.localScale = new Vector3(0.35f, 0.35f, 0.35f); // ��������� ������
        }
        else if (moveVector.x < 0)
        {
            transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f); // ��������� �����
        }

        // ������
        if (isGrounded & Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
