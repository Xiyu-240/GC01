using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    [Header("��ͣUI����")]
    public GameObject pauseMenuUI;
    [Header("ʤ��UI����")]
    public GameObject WinUI;
    [Header("ʧ��UI����")]
    public GameObject LoseUI;

    public GameObject MainCamera;

    public AudioClip aButton;
    public AudioClip aLose;
    public AudioClip aWin;

    private AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; // ȷ����Ϸ��ʱ�������ָ�����\
        aS= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//����ESC
        {
            if (Time.timeScale == 1)//��ͣ��Ϸ������Ѿ���ͣ���������Ϸ
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
        Time.timeScale = 0f; // ��ͣ��Ϸ
    }

    public void ResumeGame()
    {
        aS.clip = aButton;
        aS.Play();
        MainCamera.GetComponent<AudioSource>().UnPause();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // �ָ���Ϸ
    }

    public void LoadMainMenu()
    {
        aS.clip = aButton;
        aS.Play();
        Time.timeScale = 1f; // ȷ����Ϸ��ʱ�������ָ�����
        SceneManager.LoadScene("MainMenu"); // �������˵�
    }
    public void LoadThis()//����
    {
        aS.clip = aButton;
        aS.Play();
        Time.timeScale = 1f; // ȷ����Ϸ��ʱ�������ָ�����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//���¼��ص�ǰ����
    }
    public void WinGame()//ʤ��UI
    {
        MainCamera.GetComponent<AudioSource>().Pause();
        aS.clip = aWin;
        aS.Play();
        WinUI.SetActive(true);
        Time.timeScale = 0f; // ��ͣ��Ϸ
    }
    public void LoseGame()//ʧ��UI
    {
        aS.clip = aLose;
        aS.Play();
        MainCamera.GetComponent<AudioSource>().Pause();
        LoseUI.SetActive(true);
        Time.timeScale = 0f; // ��ͣ��Ϸ

    }
}
