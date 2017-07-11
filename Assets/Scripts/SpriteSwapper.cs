using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class SpriteSwapper : MonoBehaviour
{

    private new SpriteRenderer renderer;
    public List<SpriteCollection> skins = new List<SpriteCollection>();
    public int skin = 0;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        //First thing we must do is load all the sprites for the character
        foreach (SpriteCollection coll in skins)
            coll.sprites = Resources.LoadAll<Sprite>(coll.sheet.name);
    }

    void LateUpdate()
    {
        //Select the correct sprite
        SpriteCollection coll = skins[this.skin+1];

        //Get the name
        string spriteName = renderer.sprite.name;

        //Search for the correct name
        if (coll == null || coll.sprites == null) return;

        Sprite newSprite = coll.sprites.Where(item => item.name == spriteName).ToArray()[0];

        //Set the sprite
        if (newSprite)
            renderer.sprite = newSprite;
    }
}

[System.Serializable]
public class SpriteCollection
{
    public string name;
    public Texture sheet;

    [System.NonSerialized]
    public Sprite[] sprites;
}