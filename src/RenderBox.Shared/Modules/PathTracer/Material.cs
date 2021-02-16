﻿using RenderBox.Core;

namespace RenderBox.Shared.Modules.PathTracer
{
    public enum ShadingType
    {
        Diffuse = 0,
        DiffuseGlossy = 1,
        Reflection = 2,
        ReflectionAndRefraction = 3,
    }

    public class Material
    {
        public Color
            ambient = Color.White,
            diffuse = Color.White,
            specular = Color.White;

        public ShadingType ShadingType { get; set; }

        public Material()
        {
            ShadingType = ShadingType.Diffuse;
        }
    }
}
