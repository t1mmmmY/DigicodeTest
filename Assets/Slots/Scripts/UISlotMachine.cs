using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UISlotMachine : MonoBehaviour 
{
    [SerializeField] List<UIReel> reels;
    [SerializeField] List<UIItem> itemsPrefab;

    void Start()
    {
        foreach (UIReel reel in reels)
        {
            reel.Init(itemsPrefab);
        }
    }

    public void Spin()
    {
        for (int i = 0; i < reels.Count; i++)
        {
            reels[i].Spin(10, Random.Range(25 * (i+1), 50 * (i+1)));
        }
        //foreach (UIReel reel in reels)
        //{
        //    reel.Spin((int)Random.Range(20, 50));
        //}
    }
}
