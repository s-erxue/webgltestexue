using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartListener : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;

    private void Awake()
    {
        InputAction start = actions.FindActionMap("UI").FindAction("Start");
        start.performed += Start_Performed;
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
