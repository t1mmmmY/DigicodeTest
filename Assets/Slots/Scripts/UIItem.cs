using UnityEngine;
using System.Collections;

public class UIItem : MonoBehaviour 
{
    UI2DSprite sprite;

    void Awake()
    {
        sprite = GetComponent<UI2DSprite>();
        if (sprite == null)
        {
            Debug.LogError("Cannot find sprite!");
        }
    }

    public void ChangeSize(int newSize)
    {
        if (sprite == null)
        {
            return;
        }
        sprite.width = newSize;
        sprite.height = newSize;
    }
}
