using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("ѡ�س���")]
    public string levels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()//����ѡ��
    {
        SceneManager.LoadScene(levels);//����ѡ�ؽ���
    }
    public void GameExit()//�˳���Ϸ
    {
        Application.Quit();
        Debug.Log("�˳���Ϸ");
    }
}
