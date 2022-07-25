using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverUI;

    public void GameOver()
    {
        PauseGame();
        PopUPGameOverUI();
    }

    public void ContinueGame()
    {
        ReleasePauseGame();
        HideGameOverUI();
        Player.Instance.RecoverHP();
    }
    private void Awake()
    {
        instance = this;
    }
    private void PopUPGameOverUI()
    {
        _gameOverUI.SetActive(true);
    }

    private void HideGameOverUI()
    {
        _gameOverUI.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void ReleasePauseGame()
    {
        Time.timeScale = 1f;
    }
}
