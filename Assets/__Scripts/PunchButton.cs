using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PunchButton : MonoBehaviour
{
    private bool PunchPlayer = false;

    public bool BeginGame()
    {
        PunchPlayer = true;
        SceneManager.LoadScene("Phase 1");
        return PunchPlayer;
    }
}
