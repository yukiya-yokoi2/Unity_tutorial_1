using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [Header("���Z����X�R�A")] public int myScore;
    [Header("�v���C���[�̔���")] public PlayerTriggerCheck playerCheck;

    // Update is called once per frame
    void Update()
    {
        //�v���C���[��������ɓ�������
        if (playerCheck.isOn)
        {
            if (GManager.instance != null)
            {
                GManager.instance.score += myScore;
                Destroy(this.gameObject);
            }
        }
    }
}
