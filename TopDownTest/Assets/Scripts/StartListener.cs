using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartListener : MonoBehaviour
{

    private void Start()
    {
        GameObject start = GameObject.Find("Start Button");
        if (!GameVariables.IsGameOver)
        {
            GameObject.Find("Game Over Text").GetComponent<TextMeshProUGUI>().text = "Test Game";
            start.GetComponentInChildren<TextMeshProUGUI>().text = "Start";
        }

        start.GetComponent<Button>().onClick.AddListener(Start_OnClick);
        GameObject.Find("Quit Button").GetComponent<Button>().onClick.AddListener(Quit_OnClick);
    }

    private void Start_OnClick()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    private void Quit_OnClick()
    {
        Application.Quit();
    }
}
