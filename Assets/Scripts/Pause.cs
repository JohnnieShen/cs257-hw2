using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button resumeButton;
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
    }
    public void ResumeGame() {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void QuitGame() {
        Time.timeScale = 1;
        // Application.Quit(); // Uncomment this line to quit the game when running in a build
        UnityEditor.EditorApplication.isPlaying = false; // Uncomment this line to stop play mode in the editor
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            pauseMenuUI.SetActive(true);
        }
    }
    private void OnDestroy() {
        Time.timeScale = 1;
    }
}
