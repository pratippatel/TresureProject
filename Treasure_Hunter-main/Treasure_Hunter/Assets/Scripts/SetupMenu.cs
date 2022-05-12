using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupMenu : MonoBehaviour
{
    public void Newgame()
    {
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
