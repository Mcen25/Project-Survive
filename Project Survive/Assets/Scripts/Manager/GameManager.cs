using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class GameManager : NetworkBehaviour
{
    public float timer;
    public bool isTimerRunning;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;
    [SerializeField] private GameObject[] puzzles;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        isTimerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
        }
        if (GetTimer() <= 0.0001) {
            isTimerRunning = false;
            Debug.Log("Game Over");
        }

        if (CheckPuzzles()) {
            GameWin();
        }
    }

    public void GameOver() {
        if (isTimerRunning == false) {
            gameOverPanel.SetActive(true);
        }
    }

    public void GameWin() {
        isTimerRunning = false;
    }

    public float GetTimer()
    {
        return timer;
    }

    private bool CheckPuzzles() {
        foreach (GameObject puzzle in puzzles) {
            if (puzzle.activeSelf == false) {
                return false;
            }
        }
        return true;
    }
}
