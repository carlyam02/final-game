using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Sprite> skins = new List<Sprite>();
    public GameObject selectedskin;
    public GameObject Player;

    private Sprite playersprite;

    // Start is called before the first frame update
    void Start()
    {
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkin", 0); // 0 is the default value
        playersprite = skins[selectedSkinIndex];
        Player.GetComponent<SpriteRenderer>().sprite = playersprite;
    }
}