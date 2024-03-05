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

    public GameObject MainCamera;

    public AudioClip aButton;
    public AudioClip aLose;
    public AudioClip aWin;

    private AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; // 确保游戏的时间流动恢复正常\
        aS= GetComponent<AudioSource>();
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
        aS.clip = aButton;
        aS.Play();
        MainCamera.GetComponent<AudioSource>().Pause();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // 暂停游戏
    }

    public void ResumeGame()
    {
        aS.clip = aButton;
        aS.Play();
        MainCamera.GetComponent<AudioSource>().UnPause();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // 恢复游戏
    }

    public void LoadMainMenu()
    {
        aS.clip = aButton;
        aS.Play();
        Time.timeScale = 1f; // 确保游戏的时间流动恢复正常
        SceneManager.LoadScene("MainMenu"); // 加载主菜单
    }
    public void LoadThis()//重玩
    {
        aS.clip = aButton;
        aS.Play();
        Time.timeScale = 1f; // 确保游戏的时间流动恢复正常
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//重新加载当前场景
    }
    public void WinGame()//胜利UI
    {
        MainCamera.GetComponent<AudioSource>().Pause();
        aS.clip = aWin;
        aS.Play();
        WinUI.SetActive(true);
        Time.timeScale = 0f; // 暂停游戏
    }
    public void LoseGame()//失败UI
    {
        aS.clip = aLose;
        aS.Play();
        MainCamera.GetComponent<AudioSource>().Pause();
        LoseUI.SetActive(true);
        Time.timeScale = 0f; // 暂停游戏

    }
}
