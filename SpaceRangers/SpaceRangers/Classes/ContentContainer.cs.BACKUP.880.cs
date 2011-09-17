﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using XmlLibrary;
namespace SpaceRangers.Classes
{
    class ContentContainer
    {
<<<<<<< HEAD
        private static Dictionary<String, LazyContentItem<Texture2D>> _texturesInfo;
        private static Dictionary<String, LazyContentItem<SpriteFont>> _fontInfo;
=======
        private static Dictionary<string, Texture> _texturesInfo;
        private static Dictionary<string, Font> _fontInfo;
>>>>>>> da170a0684724eaafa59bb1fdfd9bcc0015d0ca1
        private const string TexturesXmlPath = "Xml/Textures";
        private const string FontXmlPath = "Xml/Fonts";
        internal static void LoadContentInfo()
        {
            LoadTextures();
            LoadFonts();
        }
        public static void Unload()
        {
            Reset(_texturesInfo.Select(kvp => kvp.Value));
        }
        private static void Reset(IEnumerable<IResetable> dict)
        {
            foreach (var content in dict)
            {
                content.Reset();
            }
        }
        private static void LoadTextures()
        {
            _texturesInfo=new Dictionary<string, LazyContentItem<Texture2D>>();
            var textureList = Content.Load<XmlContentInfo>(TexturesXmlPath);
            foreach (var content in textureList.Content)
            {
                _texturesInfo.Add(content.Name,new LazyContentItem<Texture2D>(content.Path));
            }
        }
        public static Texture2D GetTexture(string name)
        {
            try
            {
                return _texturesInfo[name].GetItem();
            }
            catch(Exception e)
            {
              throw  new Exception(string.Format("Cant find a texture path with name '{0}'.Original exception: {1}",name,e.Message));
            }
        }
        
        private static void LoadFonts()
        {
            _fontInfo = new Dictionary<string, LazyContentItem<SpriteFont>>();
            var fontList = Content.Load<XmlContentInfo>(FontXmlPath);
            foreach (var content in fontList.Content)
            {
                _fontInfo.Add(content.Name, new LazyContentItem<SpriteFont>(content.Path));
            }
        }
        public static SpriteFont GetFont(string name)
        {
            try
            {
                return _fontInfo[name].GetItem();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Cant find a font path with name '{0}'.Original exception: {1}", name, e.Message));
            }
        }
        
    }
}
