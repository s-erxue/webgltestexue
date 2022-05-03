using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class StartListener : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;

    private void Awake()
    {
        InputAction start = actions.FindActionMap("UI").FindAction("Start");
        start.performed += Start_Performed;
    }

    private void Start()
    {
        if (Gamepad.current != null)
        {
            GameObject.Find("Try Again Text").GetComponent<TextMeshProUGUI>().text = "Press B";
        }

        if (!GameVariables.IsGameOver)
        {
            GameObject.Find("Game Over Text").GetComponent<TextMeshProUGUI>().text = "Test Game";
        }
    }

    private void Start_Performed(InputAction.CallbackContext obj)
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
