using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{
    //public GameObject player;
    public Vector3 playerSpawnPosition = new Vector3(1, 0.13f, 0);
    public GameObject[] characters;

    public GameObject characterSelectPanel;

    CameraControl cc;

    void Start()
    {
        cc = FindObjectOfType<CameraControl>();
    }
    public void OnCharacterSelect(int characterChoice)
    {
        characterSelectPanel.SetActive(false);

        GameObject selectedCharacter = characters[characterChoice];
        GameObject spawnedPlayer = Instantiate(selectedCharacter, playerSpawnPosition, Quaternion.identity);
        //Character selectedCharacter = characters[characterChoice];

        cc.player = spawnedPlayer;

        cc.offset = cc.transform.position - cc.player.transform.position;



    }
}
