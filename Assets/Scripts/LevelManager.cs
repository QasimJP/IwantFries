using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI currentLevelText;
    public int currentLevel;
    public List<Level> levels = new List<Level>();
    public List<GameObject> levelDesigns = new List<GameObject>();
    [Header("Level Variables")] 
    public Material groundMaterial;
    public Material liquidMaterial;


    // Start is called before the first frame update
    void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("CURRENTLEVEL") % 5;
        //groundMaterial.mainTexture = levels[currentLevel].groundTexture;
        //liquidMaterial.color = levels[currentLevel].liquidColor;
        //levels[currentLevel].particles.ForEach(x=>x.startColor= levels[currentLevel].particleColor);
        
        levelDesigns[currentLevel].SetActive(true);
        
    }

    private void Start()
    {
        currentLevelText.text = "Lv. " + (PlayerPrefs.GetInt("CURRENTLEVEL")+1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class Level
{
    public Texture groundTexture;
    public Color liquidColor;
    public List<ParticleSystem> particles = new List<ParticleSystem>();
    public Color particleColor;

}