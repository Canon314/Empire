using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

using UnityEngine.EventSystems;



public class GoToOne : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PeriodOne()
    {
        SceneManager.LoadScene("Period1");
    }
    public void PeriodTwo()
    {
        SceneManager.LoadScene("Period2");
    }
    public void PeriodThree()
    {
        SceneManager.LoadScene("Period3");
    }
    public void PeriodFour()
    {
        SceneManager.LoadScene("Period4");
    }
    public void PeriodFive()
    {
        SceneManager.LoadScene("Period5");
    }
    public void PeriodSix()
    {
        SceneManager.LoadScene("Period6");
    }
    public void PeriodSeven()
    {
        SceneManager.LoadScene("Period7");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
