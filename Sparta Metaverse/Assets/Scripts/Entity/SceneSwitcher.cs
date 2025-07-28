using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetSceneName = "FlappyBirdScene";
    //전환할 씬 이름을 저장하는 변수

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //스페이스바 누르면 감지 
        {
            SceneManager.LoadScene(targetSceneName); //지정된 씬으로 로드하여 전환
        }
    }
}
