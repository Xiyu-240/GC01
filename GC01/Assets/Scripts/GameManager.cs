using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("选关场景")]
    public string levels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()//进入选关
    {
        SceneManager.LoadScene(levels);//加载选关界面
    }
    public void GameExit()//退出游戏
    {
        Application.Quit();
        Debug.Log("退出游戏");
    }
}
