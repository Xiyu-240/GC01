
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
    public void GameStart()//����ѡ��
    {
        SceneManager.LoadScene("Level1");//����ѡ�س���
    }
    public void GameExit()//�˳���Ϸ
    {
        Application.Quit();
        Debug.Log("�˳���Ϸ");
    }
    
}
