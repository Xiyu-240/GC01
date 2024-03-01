using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;

    public int enemyHP=100;
    public int playerHP=100;
   

    public bool attack = false;//��������
    public int amod = 1;//����ģʽ
    public float atime = 0.5f;//�������

    [Header("���˹���ͼ��")]
    public Sprite enemy1;
    public Sprite enemy2;
    public Sprite enemy3;

    public float counter0;//��ʱ��(��������)
    public float counter1;//��ʱ������Ұ�����

    private bool rebounded = false;//�����Ƿ���������˺�
    private bool blocked = false;//����Ƿ�񵲣��ǵ�����
    private bool canblock=true;//�Ƿ�ɸ�
    public float ctime=0.5f;//��CDʱ��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&canblock)//��Ұ��¿ո�ʱ
        {
            counter1 = Time.time;//��⵱ǰʱ��
            canblock = false;
            Invoke("CanBlock",atime);
            if (Mathf.Abs(counter1-counter0-3*atime)<=0.2f)
            {
                rebounded = true;
                Debug.Log("������");
                Player.GetComponent<SpriteRenderer>().color = Color.yellow;//���ŵ�������
                Invoke("CanBlock", atime);
            }
            else if (counter1 - counter0 >= 3 * atime - 0.5f || counter0 - counter1 < 3 * atime - 0.2f)
            {
                blocked = true;
                Debug.Log("�ɹ���");
                Player.GetComponent<SpriteRenderer>().color = Color.black;//���Ÿ񵲶���
                Invoke("CanBlock", atime);
            }
            else
            {
                Player.GetComponent<SpriteRenderer>().color = Color.black;//���Ÿ񵲶���
                Invoke("CanBlock", ctime);
            }


        }
        if(Input.GetKeyDown(KeyCode.A))attack = true;
        if (attack)//���й���ģʽ1
        {
            int amod = Random.Range(1, 4);//�����1��2��3��һ������
            counter0 = Time.time;
            Debug.Log(amod);
            if (amod == 1)//��ͨ
            {
                atime = 0.5f;
                Invoke("EnemySprite1", atime);
                attack= false;
            }
            if (amod == 2)//��
            {
                atime = 0.75f;
                Invoke("EnemySprite1", atime);
                attack = false;
            }
            if (amod == 3)//��
            {
                atime = 0.25f;
                Invoke("EnemySprite1", atime);
                attack = false;
            }

        }
    }
    public void StartAttack()//��������
    {
        attack = true;
    }
    public void PlayerSprite0()//������/��������
    {
        Player.GetComponent<SpriteRenderer>().color = Color.white;//��ҽ�ɫ���ԭ��
    }
    public void CanBlock()//������/�������ƣ����¿��Ը�
    {
        Player.GetComponent<SpriteRenderer>().color = Color.white;//��ҽ�ɫ���ԭ��
        canblock = true;
    }
    public void EnemySprite0()
    {
        Enemy.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void EnemySprite1()
    {
        Enemy.GetComponent<SpriteRenderer>().color = Color.green;//Ԥ������1
        Invoke("EnemySprite2", atime);//�е���һ����
    }
    public void EnemySprite2()
    {
        Enemy.GetComponent<SpriteRenderer>().color = Color.yellow;//Ԥ������2
        Invoke("EnemySprite3", atime);//��һ����
    }
    public void EnemySprite3()
    {
        
        Enemy.GetComponent<SpriteRenderer>().color = Color.red;//�������ж���
        Invoke("Damage", atime);//�˺��ж�
    }
    public void Damage()//�˺��ж��͵����ܻ�
    {
        if (rebounded == false&&blocked==false)//��û��Ҳû����ʱ
        {
            Enemy.GetComponent<SpriteRenderer>().color = Color.white;//��ؾ�ֹ
            Player.GetComponent<SpriteRenderer>().color = Color.yellow;
            Invoke("PlayerSprite0", atime);

            if (amod == 1)
            {
                playerHP -= Random.Range(30, 41);
            }
            if (amod == 2)
            {
                playerHP -= Random.Range(15, 26);
            }
            if (amod == 3)
            {
                playerHP -= Random.Range(50, 61);
            }
        }
        else
        {
            Enemy.GetComponent<SpriteRenderer>().color = Color.black;//���˱�����
            Invoke("EnemySprite0", atime);//��Ϊ��ֹ
            enemyHP -= Random.Range(5, 16);//�����Ѫ
        }
    }
}
