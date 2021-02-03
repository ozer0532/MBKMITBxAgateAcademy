using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Rigidbody 2D bola api
    private Rigidbody2D rigidBody2D;

    // Besarnya gaya awal yang diberikan untuk mendorong bola api
    public float xInitialForce;
    public float yInitialForce;
    public float force;

    // Player
    public PlayerControl player1;
    public PlayerControl player2;

    // Ball
    public BallControl ball;

    // Game Manager
    public GameManager gameManager;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    public void ResetFireball()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;

        PushFireball();
    }

    void PushFireball()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        // Jika nilainya di bawah 1, bola bergerak ke kiri. 
        // Jika tidak, bola bergerak ke kanan.
        if (randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakkan bola ini.
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce).normalized * force);
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce).normalized * force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player1")
        {
            MakeWin(player2);
        }
        else if (collision.name == "Player2")
        {
            MakeWin(player1);
        }
    }

    private void MakeWin(PlayerControl player)
    {
        player.IncrementScore();
        if (player.Score < gameManager.maxScore)
        {
            ball.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
        }
        gameObject.SetActive(false);
    }
}
