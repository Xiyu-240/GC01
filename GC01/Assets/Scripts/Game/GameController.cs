using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;

    public int enemyHP=100;
    public int playerHP=100;
   

    public bool attack = false;//启动攻击
    public int amod = 1;//攻击模式
    public float atime = 0.5f;//攻击间隔

    [Header("敌人攻击图像")]
    public Sprite enemy1;
    public Sprite enemy2;
    public Sprite enemy3;

    public float counter0;//计时器(攻击发起)
    public float counter1;//计时器（玩家按键）

    private bool rebounded = false;//敌人是否对玩家造成伤害
    private bool blocked = false;//玩家是否格挡（非弹反）
    private bool canblock=true;//是否可格挡
    public float ctime=0.5f;//格挡CD时间

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&canblock)//玩家按下空格时
        {
            counter1 = Time.time;//检测当前时间
            canblock = false;
            Invoke("CanBlock",atime);
            if (Mathf.Abs(counter1-counter0-3*atime)<=0.2f)
            {
                rebounded = true;
                Debug.Log("弹反！");
                Player.GetComponent<SpriteRenderer>().color = Color.yellow;//播放弹反动画
                Invoke("CanBlock", atime);
            }
            else if (counter1 - counter0 >= 3 * atime - 0.5f || counter0 - counter1 < 3 * atime - 0.2f)
            {
                blocked = true;
                Debug.Log("成功格挡");
                Player.GetComponent<SpriteRenderer>().color = Color.black;//播放格挡动画
                Invoke("CanBlock", atime);
            }
            else
            {
                Player.GetComponent<SpriteRenderer>().color = Color.black;//播放格挡动画
                Invoke("CanBlock", ctime);
            }


        }
        if(Input.GetKeyDown(KeyCode.A))attack = true;
        if (attack)//进行攻击模式1
        {
            int amod = Random.Range(1, 4);//随机出1，2，3中一个数字
            counter0 = Time.time;
            Debug.Log(amod);
            if (amod == 1)//普通
            {
                atime = 0.5f;
                Invoke("EnemySprite1", atime);
                attack= false;
            }
            if (amod == 2)//慢
            {
                atime = 0.75f;
                Invoke("EnemySprite1", atime);
                attack = false;
            }
            if (amod == 3)//快
            {
                atime = 0.25f;
                Invoke("EnemySprite1", atime);
                attack = false;
            }

        }
    }
    public void StartAttack()//启动攻击
    {
        attack = true;
    }
    public void PlayerSprite0()//结束格挡/弹反姿势
    {
        Player.GetComponent<SpriteRenderer>().color = Color.white;//玩家角色变回原样
    }
    public void CanBlock()//结束格挡/弹反姿势，重新可以格挡
    {
        Player.GetComponent<SpriteRenderer>().color = Color.white;//玩家角色变回原样
        canblock = true;
    }
    public void EnemySprite0()
    {
        Enemy.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void EnemySprite1()
    {
        Enemy.GetComponent<SpriteRenderer>().color = Color.green;//预备动作1
        Invoke("EnemySprite2", atime);//切到下一动作
    }
    public void EnemySprite2()
    {
        Enemy.GetComponent<SpriteRenderer>().color = Color.yellow;//预备动作2
        Invoke("EnemySprite3", atime);//下一动作
    }
    public void EnemySprite3()
    {
        
        Enemy.GetComponent<SpriteRenderer>().color = Color.red;//攻击命中动作
        Invoke("Damage", atime);//伤害判定
    }
    public void Damage()//伤害判定和敌人受击
    {
        if (rebounded == false&&blocked==false)//既没格挡也没弹反时
        {
            Enemy.GetComponent<SpriteRenderer>().color = Color.white;//变回静止
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
            Enemy.GetComponent<SpriteRenderer>().color = Color.black;//敌人被弹反
            Invoke("EnemySprite0", atime);//变为静止
            enemyHP -= Random.Range(5, 16);//怪物扣血
        }
    }
}
