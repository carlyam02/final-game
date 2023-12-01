using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;

    private SpriteRenderer playerSpriteRenderer;

    void Start() {
        playerSpriteRenderer = Player.GetComponent<SpriteRenderer>();
        ApplySelectedSkin();
    }

    private void ApplySelectedSkin() {
        int selectedSkinIndex = PlayerPrefs.GetInt("SelectedSkin", 0);
        if (SkinManager.Instance.skins.Count > selectedSkinIndex) {
            playerSpriteRenderer.sprite = SkinManager.Instance.skins[selectedSkinIndex];
        }
    }
}
