using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    void Start()
    {
        gameObject.tag = "Player";  // Ensure the player's tag is properly set
    }

    // For non-physical interaction
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            TakeDamage(1);
        }
    }

    // For physical interaction
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOverScene");
    }
}
