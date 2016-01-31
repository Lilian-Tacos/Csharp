﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Puissance4
{
    class ObjetPuissance4
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _size;


        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }


        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector2 Site
        {
            get { return _size; }
            set { _size = value; }
        }

        public ObjetPuissance4(Texture2D texture, Vector2 position, Vector2 size)
        {
            this._texture = texture;
            this._position = position;
            this._size = size;
        }
    }
}
