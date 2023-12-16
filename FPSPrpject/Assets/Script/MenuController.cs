using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    [Header("VolumeSetting")]
    [SerializeField] private TMP_Text volumeValueText = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [Header("Comfirmation")]
    [SerializeField] private GameObject comfirmationPromt = null;


    [Header("Levels")]
    [SerializeField] private string _newGameLevel;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        SetVolume(defaultVolume);
    }

    public void NewGameYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }
    public void GameExit()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeValueText.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string menuType)
    {
        if(menuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeValueText.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }
    }

    public IEnumerator ConfirmationBox()
    {
        comfirmationPromt.SetActive(true);
        yield return new WaitForSeconds(2);
        comfirmationPromt.SetActive(false);
    }
}
