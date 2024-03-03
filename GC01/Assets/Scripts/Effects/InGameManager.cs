using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    [Header("暂停UI界面")]
    public GameObject pauseMenuUI;
    [Header("胜利UI界面")]
    public GameObject WinUI;
    [Header("失败UI界面")]
    public GameObject LoseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//按下ESC
        {
            if (Time.timeScale == 1)//暂停游戏，如果已经暂停，则继续游戏
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // 暂停游戏
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // 恢复游戏
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // 确保游戏的时间流动恢复正常
        SceneManager.LoadScene("MainMenu"); // 加载主菜单
    }
    public void LoadThis()//重玩
    {
        Time.timeScale = 1f; // 确保游戏的时间流动恢复正常
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//重新加载当前场景
    }
    public void WinGame()//胜利UI
    {
        WinUI.SetActive(true);
        Time.timeScale = 0f; // 暂停游戏
    }
    public void LoseGame()//失败UI
    {
        WinUI.SetActive(true);
        Time.timeScale = 0f; // 暂停游戏
    }
}
