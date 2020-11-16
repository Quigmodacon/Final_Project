using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenFunctions : MonoBehaviour
{
    
    public void SwitchToGameScene()
    {
        SceneManager.LoadScene("testScene");
    }
}
