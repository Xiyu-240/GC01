using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;

    public bloodController bloodController;

    public bool attack = false;//��������
    public int amod = 1;//����ģʽ
    public float atime = 0.5f;//�������
    public float ctime = 0.5f;//��CDʱ��

    [Header("���˹���ͼ��")]
    public Sprite enemy1;
    public Sprite enemy2;
    public Sprite enemy3;
    public Sprite enemy4;
    public Sprite enemy5;
    public Sprite enemy6;
    public Sprite enemy7;
    public Sprite enemy8;
    public Sprite enemy9;
    public Sprite enemy10;

    public float counter0;//��ʱ��(��������)
    public float counter1;//��ʱ������Ұ�����

    private bool rebounded = false;//�����Ƿ���������˺�
    private bool canblock = true;//�Ƿ�ɸ�


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canblock)//��Ұ��¿ո�ʱ
        {
            counter1 = Time.time;//��⵱ǰʱ��
            canblock = false;

            if (Mathf.Abs(counter1 - counter0 - 3 * atime) <= 0.3f)
            {
                rebounded = true;
                Debug.Log("������");
                Player.GetComponent<SpriteRenderer>().color = Color.yellow;//���ŵ�������
                Invoke("CanBlock", atime);
            }

            else
            {
                Player.GetComponent<SpriteRenderer>().color = Color.black;//���Ÿ񵲶���
                Invoke("CanBlock", ctime);
            }


        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AttackLoop();
        }

    }

    public void AttackLoop()
    {
        int amod = Random.Range(1, 4);//�����1��2��3��һ������

        Debug.Log(amod);
        if (amod == 1)//��ͨ
        {
            atime = 0.5f;
            StartCoroutine(Idle1());
        }
        if (amod == 2)//��
        {
            atime = 0.75f;
            StartCoroutine(Idle1());
        }
        if (amod == 3)//��
        {
            atime = 0.25f;
            StartCoroutine(Idle1());
        }
    }

    public void PlayerSprite0()//������/��������
    {
        Player.GetComponent<SpriteRenderer>().color = Color.white;//��ҽ�ɫ���ԭ��
    }

    public void EnemySprite0()
    {
        Enemy.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void CanBlock()//������/�������ƣ����¿��Ը�
    {
        Player.GetComponent<SpriteRenderer>().color = Color.white;//��ҽ�ɫ���ԭ��
        canblock = true;

    }

    private IEnumerator Idle1()  //��������1
    {
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy4;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy5;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy6;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy7;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy4;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy5;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy6;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy7;
        yield return new WaitForSeconds(0.15f);

        StartCoroutine(Attack1());
    }

    private IEnumerator Rebounded()  //��������
    {
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy8;
        yield return new WaitForSeconds(0.15f);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy9;
    }
    private IEnumerator Attack1()  //����ģʽ1
    {
        counter0 = Time.time;
        //��������
        yield return new WaitForSeconds(atime);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy1;
        //Enemy.GetComponent<SpriteRenderer>().color = Color.green;//Ԥ������1
        yield return new WaitForSeconds(atime);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy2;
        //Enemy.GetComponent<SpriteRenderer>().color = Color.yellow;//Ԥ������2
        yield return new WaitForSeconds(atime);
        Enemy.GetComponent<SpriteRenderer>().sprite = enemy3;
        //Enemy.GetComponent<SpriteRenderer>().color = Color.red;//�������ж���
        yield return new WaitForSeconds(0.2f);

        //�ж�
        Damage();
    }
    public void Damage()//�˺��ж��͵����ܻ�
    {
        if (rebounded == false)//û����ʱ
        {
            Player.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("PlayerSprite0", atime);

            if (amod == 1)
            {
                bloodController.playerHP -= Random.Range(30, 41);
            }
            if (amod == 2)
            {
                bloodController.playerHP -= Random.Range(15, 26);
            }
            if (amod == 3)
            {
                bloodController.playerHP -= Random.Range(50, 61);
            }

            AttackLoop();
        }
        else
        {
            StartCoroutine(Rebounded());// ��������

            Invoke("EnemySprite0", atime);//��Ϊ��ֹ
            bloodController.enemyHP -= Random.Range(5, 16);//�����Ѫ
            rebounded = false;

            Invoke("AttackLoop", 0.2f);
        }
    }





    // ��ʱ���õ�
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
}
