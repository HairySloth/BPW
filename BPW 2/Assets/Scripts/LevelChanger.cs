using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{
    [SerializeField] public int level;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<CharacterController>())
        {
            if(level == 5)
            {
                Application.Quit();

            }
            else
            {
                SceneManager.LoadScene(level);
            }

            
        }

    }
}
