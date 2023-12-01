using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance { get; private set; }

    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public SpriteRenderer sr;
    public GameObject playerskin;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void NextOption() {
        selectedSkin = (selectedSkin + 1) % skins.Count;
        sr.sprite = skins[selectedSkin];
    }

    public void BackOption() {
        if (selectedSkin == 0) {
            selectedSkin = skins.Count;
        }
        selectedSkin--;
        sr.sprite = skins[selectedSkin];
    }

    public void PlayGame() {
        PlayerPrefs.SetInt("SelectedSkin", selectedSkin);
        SceneManager.LoadScene("PcRun");
    }
}
