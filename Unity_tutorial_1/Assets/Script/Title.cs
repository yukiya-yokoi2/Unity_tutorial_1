using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    [Header("�t�F�[�h")] public FadeImage fade;

    private bool firstPush = false;
    private bool goNextScene = false;

    private void Start()
    {
        Debug.Log("Press Start!");
    }
    //�X�^�[�g�{�^���������ꂽ��Ă΂��
    public void PressStart()
    {
        
        if (!firstPush)
        {
            Debug.Log("Go Next Scene!");
            fade.StartFadeOut();
            firstPush = true;
        }
    }

    private void Update()
    {
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene("stage1");
            goNextScene = true;
        }
    }
}