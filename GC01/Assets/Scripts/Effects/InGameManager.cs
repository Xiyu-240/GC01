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
    // Start is called before the first frame update
    void Start()
    {
        
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
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // ��ͣ��Ϸ
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // �ָ���Ϸ
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // ȷ����Ϸ��ʱ�������ָ�����
        SceneManager.LoadScene("MainMenu"); // �������˵�
    }
    public void LoadThis()//����
    {
        Time.timeScale = 1f; // ȷ����Ϸ��ʱ�������ָ�����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//���¼��ص�ǰ����
    }
    public void WinGame()//ʤ��UI
    {
        WinUI.SetActive(true);
        Time.timeScale = 0f; // ��ͣ��Ϸ
    }
    public void LoseGame()//ʧ��UI
    {
        WinUI.SetActive(true);
        Time.timeScale = 0f; // ��ͣ��Ϸ
    }
}
