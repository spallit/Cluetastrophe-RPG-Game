using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{
    //starting point of player 
    public Vector3 playerSpawnPosition = new Vector3(1, 0.13f, 0);
    //array of prefab characters to store different fighting styles 
    public GameObject[] characters;
    //menu for users to pick fighting style 
    public GameObject characterSelectPanel;
    public GameObject hintInfo;
    
    CameraControl cc;

    void Start()
    {
        cc = FindObjectOfType<CameraControl>();
    }
    
    public void OnCharacterSelect(int characterChoice)
    {
        //turn off menu panel 
        characterSelectPanel.SetActive(false);
        //when button is pressed, an index number is passed to the array of characters, that element in the array is the one instantiated 
        GameObject selectedCharacter = characters[characterChoice];
        GameObject spawnedPlayer = Instantiate(selectedCharacter, playerSpawnPosition, Quaternion.identity);
        Pause.isPaused = false; //activates enemy spawner if it was disabled
        
        //define that instantiated object for the camera 
        cc.player = spawnedPlayer;
        //camera will follow this instance of the prefab 
        cc.offset = cc.transform.position - cc.player.transform.position;

        if (ClueCounterScript.level == 2)
        {
            hintInfo.SetActive(false);
        }

    }
}
