using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;

   public void displayHints()
    {
        if (hint1 != null)
        {
          hint1.SetActive(true);
        }
       if(hint2 != null)
        {
          hint2.SetActive(true);
        }
        if(hint3 != null)
        {
          hint3.SetActive(true);
        }
       

        Invoke("hideHints", 5f);
    }

    public void hideHints()
    {

        if (hint1 != null)
        {
            hint1.SetActive(false);
        }
        if (hint2 != null)
        {
            hint2.SetActive(false);
        }
        if (hint3 != null)
        {
            hint3.SetActive(false);
        }
    }
}
