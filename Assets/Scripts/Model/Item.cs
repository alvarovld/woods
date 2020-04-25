using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace model
{
    public class Item : ScriptableObject
    {
        private new string name;
        private Sprite sprite;

        public Item(GameObject gameObject)
        {
            setName(gameObject.name);
            setSprite(gameObject.GetComponent<SpriteRenderer>().sprite);
        }

        public void setSprite(Sprite sprite)
        {
            this.sprite = sprite;
        }

        public Sprite getSprite()
        {
            return sprite;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
    }
}
