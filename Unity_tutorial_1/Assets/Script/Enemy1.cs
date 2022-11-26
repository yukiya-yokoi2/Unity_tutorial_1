using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("���Z�X�R�A")] public int myScore;
    [Header("��ʊO�ł��s������")] public bool nonVisibleAct;
    [Header("�d��")] public float gravity;
    [Header("�ړ����x")] public float speed;
    [Header("����ė����鑬�x")] public float fallspeed;
    [Header("�ڐG����")] public EnemyCheck checkcollision;
    #endregion

    #region//�v���C�x�[�g�ϐ�
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjectCollision oc = null;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;
    private bool isDead = false;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!oc.playerStepOn)
        {
            if (checkcollision.isOn)
            {
                rightTleftF = !rightTleftF;
            }
            if (sr.isVisible || nonVisibleAct)
            {
                int xVector = -1;
                if (rightTleftF)
                {
                    xVector = 1;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                rb.velocity = new Vector2(xVector * speed, -gravity);
            }
            else
            {
                rb.Sleep();
            }
        }
        else
        {
            if (!isDead)
            {
                if (GManager.instance != null)
                {

                    GManager.instance.score += myScore;
                }

                anim.Play("enemy_down");
                isDead = true;
                col.enabled = false;
                Destroy(gameObject, 3f);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 5));
                rb.velocity = new Vector2(0, -fallspeed);
            }
        }
        
    }
}
