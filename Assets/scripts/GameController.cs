using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPause = false;
    public GameObject canvas;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandlePauseGame();
        ActivePauseMenu();
    }
    void HandlePauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPause) isPause = false;
            else isPause = true;

        }
    }
    public void ActivePauseMenu()
    {
        if (isPause)
        {
            canvas.SetActive(true);
            PauseGame();
        }
        else
        {
            canvas.SetActive(false);
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPause = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPause = false;

    }
}
