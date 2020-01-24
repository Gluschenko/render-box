﻿using System;
using PathTracerSharp.Rendering;

namespace PathTracerSharp.Shapes
{
    public class Box : Shape
    {
        public Vector pointA, pointB;

        //public Box(Vector position, Color diffuse) : base(position, diffuse) { }

        public Box(Vector position, Vector scale, Color diffuse) : base(position, diffuse) 
        {
            scale /= 2;

            pointA = position + scale;
            pointB = position - scale;
        }

        public override double GetIntersection(Ray ray, out Hit hit)
        {
            hit = new Hit();

            var tmin = (pointA.x - ray.origin.x) / ray.direction.x;
            var tmax = (pointB.x - ray.origin.x) / ray.direction.x;

            if (tmin > tmax) 
            {
                (tmin, tmax) = (tmax, tmin);
            }

            var tymin = (pointA.y - ray.origin.y) / ray.direction.y;
            var tymax = (pointB.y - ray.origin.y) / ray.direction.y;

            if (tymin > tymax)
            {
                (tymin, tymax) = (tymax, tymin);
            }

            if ((tmin > tymax) || (tymin > tmax))
                return -1;

            if (tymin > tmin)
                tmin = tymin;

            if (tymax < tmax)
                tmax = tymax;

            var tzmin = (pointB.z - ray.origin.z) / ray.direction.z;
            var tzmax = (pointB.z - ray.origin.z) / ray.direction.z;

            if (tzmin > tzmax)
            {
                (tzmin, tzmax) = (tzmax, tzmin);
            }

            if ((tmin > tzmax) || (tzmin > tmax))
                return -1;

            /*if (tzmin > tmin)
                tmin = tzmin;

            if (tzmax < tmax)
                tmax = tzmax;*/

            return 1;
        }

        public override Vector CalcNormal(Vector pos)
        {
            return Vector.Normalize(pos - position);
        }
    }
}