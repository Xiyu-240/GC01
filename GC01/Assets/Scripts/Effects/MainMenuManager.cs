
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioClip aButton;
    private AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()//进入选关
    {
        aS.clip = aButton;
        aS.Play();
        SceneManager.LoadScene("Level1");//加载选关场景
    }
    public void GameExit()//退出游戏
    {
        aS.clip = aButton;
        aS.Play();
        Application.Quit();
        Debug.Log("退出游戏");
    }
    
}
