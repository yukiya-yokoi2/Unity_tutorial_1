using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    /// <summary>
    /// ������ɕǂ��G������B�������͒n�ʂɐڐG���Ă��Ȃ�
    /// </summary>

    [HideInInspector] public bool isOn = false;

    private string groundTag = "Ground";
    private string enemyTag = "Enemy";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    #region//�O���ڐG����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            isOn = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            isOn = false;
        }

    }
    #endregion

}