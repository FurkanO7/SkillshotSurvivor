using UnityEngine;

public class Fireball : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Fireball trigger entered: {other.name} (Tag: {other.tag})");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by fireball!");
            Time.timeScale = 0f;

            var playerMovement = other.GetComponent<PlayerMovement2D>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            var gameOver = FindObjectOfType<GameOverUI>();
            var scoreUI = FindObjectOfType<ScoreTimerUI>();
            if (gameOver != null && scoreUI != null)
            {
                gameOver.Show(scoreUI.GetScore());
                scoreUI.gameObject.SetActive(false); 
            }
        }
    }
}
