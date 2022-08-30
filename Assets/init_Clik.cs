using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabtale.TTPlugins;

public class init_Clik : MonoBehaviour
{
    IDictionary<string, object> MessageToShow = new Dictionary<string, object> { };
    GameManager GM;
    private void Awake()
    {
        TTPCore.Setup();
    }
    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.Instance;
        MessageToShow.Add("GameStart with Manager",GM);

        TTPAppsFlyer.LogEvent("Pression Start", MessageToShow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
