using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10f;  // ���� ������������
    public AudioClip clip;
    AudioSource playerAudio;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)  // ��������, ��� ����� ������ �� �����, � �� ������������ �����
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, bounceForce);
                if (!playerAudio.isPlaying)
                {
                    playerAudio.Play();
                }
            }
        }
    }
}