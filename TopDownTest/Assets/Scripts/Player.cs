using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    private TextMeshProUGUI coinsText;
    private TextMeshProUGUI livesText;

    private int _coins = 0;
    private int _lives = 5;

    private int Coins
    {
        get => _coins;
        set
        {
            coinsText.text = $"Coins: {value}";
            _coins = value;
        }
    }
    private int Lives
    {
        get => _lives;
        set
        {
            livesText.text = $"Lives: {value}";
            _lives = value;
        }
    }

    private void Start()
    {
        coinsText = GameObject.Find("Coin Text").GetComponent<TextMeshProUGUI>();
        livesText = GameObject.Find("Lives Text").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.layer)
        {
            case 3:
                if (collision.CompareTag("Coin"))
                {
                    CollectCoin();
                    Destroy(collision.gameObject);
                }
                break;
            case 6:
                LoseLife();
                break;
        }
    }

    private void CollectCoin()
    {
        Coins++;
        if (Coins == 100)
        {
            Coins = 0;
            Lives++;
        }
    }

    private void LoseLife()
    {
        Lives--;
        if (Lives == 0)
        {
            GameVariables.IsGameOver = true;
            SceneManager.LoadSceneAsync("GameOverScene");
        }
    }
}
