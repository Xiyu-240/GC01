
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    
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
        SceneManager.LoadScene("Level1");//加载选关场景
    }
    public void GameExit()//退出游戏
    {
        Application.Quit();
        Debug.Log("退出游戏");
    }
    
}
