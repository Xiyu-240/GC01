
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
    public void GameStart()//����ѡ��
    {
        aS.clip = aButton;
        aS.Play();
        SceneManager.LoadScene("Level1");//����ѡ�س���
    }
    public void GameExit()//�˳���Ϸ
    {
        aS.clip = aButton;
        aS.Play();
        Application.Quit();
        Debug.Log("�˳���Ϸ");
    }
    
}
