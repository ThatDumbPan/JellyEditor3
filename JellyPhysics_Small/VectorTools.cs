/*
Copyright (c) 2007 Walaber

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Content;

namespace JellyPhysics
{
    /// <summary>
    /// Some helpful vector tools not included in the XNA libraries.
    /// </summary>
    public static class VectorTools
    {
        /// <summary>
        ///  rotate a vector by a given angle (in radians).
        /// </summary>
        /// <param name="vec">vector</param>
        /// <param name="angleRadians">angle in radians</param>
        /// <returns>rotated vector</returns>
        public static Vector2 rotateVector(Vector2 vec, float angleRadians)
        {
            Vector2 ret = new Vector2();
            float c = (float)Math.Cos(angleRadians);
            float s = (float)Math.Sin(angleRadians);
            ret.X = (c * vec.X) - (s * vec.Y);
            ret.Y = (c * vec.Y) + (s * vec.X);

            return ret;
        }

        /// <summary>
        /// rotate a vector by a given angle (reference type version)
        /// </summary>
        /// <param name="vecIn">vector to rotate</param>
        /// <param name="angleRadians">angle in radians</param>
        /// <param name="vecOut">rotated vector</param>
        public static void rotateVector(ref Vector2 vecIn, float angleRadians, ref Vector2 vecOut)
        {
            float c = (float)Math.Cos(angleRadians);
            float s = (float)Math.Sin(angleRadians);
            vecOut.X = (c * vecIn.X) - (s * vecIn.Y);
            vecOut.Y = (c * vecIn.Y) + (s * vecIn.X);
        }

        /// <summary>
        /// rotate a given vector by a given angle (reference type version)
        /// </summary>
        /// <param name="vecIn">vector to rotate</param>
        /// <param name="angleRadians">angle in radians</param>
        /// <param name="vecOut">rotated vector</param>
        public static void rotateVector(ref Vector2 vecInOut, float angleRadians)
        {
            float originalX = vecInOut.X;
            float originalY = vecInOut.Y;
            float c = (float)Math.Cos(angleRadians);
            float s = (float)Math.Sin(angleRadians);
            vecInOut.X = (c * originalX) - (s * originalY);
            vecInOut.Y = (c * originalY) + (s * originalX);
        }


        /// <summary>
        ///  reflect a vector about a normal.  Normal must be a unit vector.
        /// </summary>
        /// <param name="V">vector</param>
        /// <param name="N">normal</param>
        /// <returns>reflected vector</returns>
        public static Vector2 reflectVector(ref Vector2 V, ref Vector2 N)
        {
            Vector2 ret = V - (N * (2f * Vector2.Dot(V, N)));
            return ret;
        }

        /// <summary>
        /// reflect a vector about a normal.  Normal must be a unit vector.  (reference type version)
        /// </summary>
        /// <param name="V">vector in</param>
        /// <param name="N">normal</param>
        /// <param name="?">reflected vector out</param>
        public static void reflectVector(ref Vector2 V, ref Vector2 N, ref Vector2 vOut)
        {
            float dot;
            Vector2.Dot(ref V, ref N, out dot);
            vOut = V - (N * (2f * dot));
        }

        /// <summary>
        /// get a vector perpendicular to this vector.
        /// </summary>
        /// <param name="vec">vector</param>
        /// <returns>perpendicular vector</returns>
        public static Vector2 getPerpendicular(Vector2 vec)
        {
            return new Vector2(-vec.Y, vec.X);
        }


        /// <summary>
        /// get a vector perpendicular to this vector (reference type version)
        /// </summary>
        /// <param name="vIn">vector int</param>
        /// <param name="vOut">perpendicular vector out</param>
        public static void getPerpendicular(ref Vector2 vIn, ref Vector2 vOut)
        {
            vOut.X = -vIn.Y;
            vOut.Y = vIn.X;
        }

        /// <summary>
        /// make this vector perpendicular to itself
        /// </summary>
        /// <param name="vIn">vector in / out</param>
        public static void makePerpendicular(ref Vector2 v)
        {
            float tempX = v.X;
            v.X = -v.Y;
            v.Y = tempX;
        }

        /// <summary>
        /// is rotating from A to B Counter-clockwise?
        /// </summary>
        /// <param name="A">vector A</param>
        /// <param name="B">vector B</param>
        /// <returns>true = CCW or opposite (180 degrees), false = CW</returns>
        public static bool isCCW(Vector2 A, Vector2 B)
        {
            Vector2 perp = JellyPhysics.VectorTools.getPerpendicular(A);
            float dot;
            Vector2.Dot(ref B, ref perp, out dot);
            return (dot >= 0.0f);
        }

        /// <summary>
        /// is rotating from A to B Counter-Clockwise?
        /// </summary>
        /// <param name="A">vector A</param>
        /// <param name="B">vector B</param>
        /// <returns>true = CCW or opposite (180 degrees), false = CW</returns>
        public static bool isCCW(ref Vector2 A, ref Vector2 B)
        {
            Vector2 perp = new Vector2();
            JellyPhysics.VectorTools.getPerpendicular(ref A, ref perp);
            float dot;
            
            Vector2.Dot(ref B, ref perp, out dot);
            return (dot >= 0.0f);
        }

        /// <summary>
        /// turn a Vector2 into a Vector3 (sets Z component to zero)
        /// </summary>
        /// <param name="vec">input Vector2</param>
        /// <returns>result Vector3</returns>
        public static Vector3 vec3FromVec2(Vector2 vec)
        {
            return new Vector3(vec.X, vec.Y, 0);
        }

        /// <summary>
        /// turn a Vector2 into a Vector3 (sets Z component to zero) (reference type version)
        /// </summary>
        /// <param name="vec">input Vector2</param>
        /// <returns>result Vector3</returns>
        public static Vector3 vec3FromVec2(ref Vector2 vec)
        {
            return new Vector3(vec.X, vec.Y, 0);
        }

        /// <summary>
        /// turn a Vector2 into a Vector3, specifying the Z component to use.
        /// </summary>
        /// <param name="vec">input Vector2</param>
        /// <param name="Z">Z component</param>
        /// <returns>result Vector3</returns>
        public static Vector3 vec3FromVec2(Vector2 vec, float Z)
        {
            return new Vector3(vec.X, vec.Y, Z);
        }

        /// <summary>
        /// turn a Vector2 into a Vector3, specifying the Z component to use.
        /// </summary>
        /// <param name="vec">input Vector2</param>
        /// <param name="Z">Z component</param>
        /// <returns>result Vector3</returns>
        public static Vector3 vec3FromVec2(ref Vector2 vec, float Z)
        {
            return new Vector3(vec.X, vec.Y, Z);
        }


        /// <summary>
        /// see if 2 line segments intersect. (line AB collides with line CD)
        /// </summary>
        /// <param name="ptA">first point on line AB</param>
        /// <param name="ptB">second point on line AB</param>
        /// <param name="ptC">first point on line CD</param>
        /// <param name="ptD">second point on line CD</param>
        /// <param name="hitPt">resulting point of intersection</param>
        /// <param name="Ua">distance along AB to intersection [0,1]</param>
        /// <param name="Ub">distance long CD to intersection [0,1]</param>
        /// <returns>true / false</returns>
        public static bool lineIntersect(Vector2 ptA, Vector2 ptB, Vector2 ptC, Vector2 ptD, out Vector2 hitPt, out float Ua, out float Ub)
        {
            hitPt = Vector2.Zero;
            Ua = 0f;
            Ub = 0f;

            float denom = ((ptD.Y - ptC.Y) * (ptB.X - ptA.X)) - ((ptD.X - ptC.X) * (ptB.Y - ptA.Y));

            // if denom == 0, lines are parallel - being a bit generous on this one..
            if (Math.Abs(denom) < 0.000001f)
                return false;

            float UaTop = ((ptD.X - ptC.X) * (ptA.Y - ptC.Y)) - ((ptD.Y - ptC.Y) * (ptA.X - ptC.X));
            float UbTop = ((ptB.X - ptA.X) * (ptA.Y - ptC.Y)) - ((ptB.Y - ptA.Y) * (ptA.X - ptC.X));

            Ua = UaTop / denom;
            Ub = UbTop / denom;

            if ((Ua >= 0f) && (Ua <= 1f) && (Ub >= 0f) && (Ub <= 1f))
            {
                // these lines intersect!
                hitPt = ptA + ((ptB - ptA) * Ua);
                return true;
            }

            return false;
        }

        /// <summary>
        /// see if 2 line segments intersect. (line AB collides with line CD) (reference type version)
        /// </summary>
        /// <param name="ptA">first point on line AB</param>
        /// <param name="ptB">second point on line AB</param>
        /// <param name="ptC">first point on line CD</param>
        /// <param name="ptD">second point on line CD</param>
        /// <param name="hitPt">resulting point of intersection</param>
        /// <param name="Ua">distance along AB to intersection [0,1]</param>
        /// <param name="Ub">distance long CD to intersection [0,1]</param>
        /// <returns>true / false</returns>
        public static bool lineIntersect(ref Vector2 ptA, ref Vector2 ptB, ref Vector2 ptC, ref Vector2 ptD, out Vector2 hitPt, out float Ua, out float Ub)
        {
            hitPt = Vector2.Zero;
            Ua = 0f;
            Ub = 0f;

            float denom = ((ptD.Y - ptC.Y) * (ptB.X - ptA.X)) - ((ptD.X - ptC.X) * (ptB.Y - ptA.Y));

            // if denom == 0, lines are parallel - being a bit generous on this one..
            if (Math.Abs(denom) < 0.000001f)
                return false;

            float UaTop = ((ptD.X - ptC.X) * (ptA.Y - ptC.Y)) - ((ptD.Y - ptC.Y) * (ptA.X - ptC.X));
            float UbTop = ((ptB.X - ptA.X) * (ptA.Y - ptC.Y)) - ((ptB.Y - ptA.Y) * (ptA.X - ptC.X));

            Ua = UaTop / denom;
            Ub = UbTop / denom;

            if ((Ua >= 0f) && (Ua <= 1f) && (Ub >= 0f) && (Ub <= 1f))
            {
                // these lines intersect!
                hitPt = ptA + ((ptB - ptA) * Ua);
                return true;
            }

            return false;
        }

        /// <summary>
        /// see if 2 line segments intersect. (line AB collides with line CD) - simplified version
        /// </summary>
        /// <param name="ptA">first point on line AB</param>
        /// <param name="ptB">second point on line AB</param>
        /// <param name="ptC">first point on line CD</param>
        /// <param name="ptD">second point on line CD</param>
        /// <param name="hitPt">resulting point of intersection</param>
        /// <returns>true / false</returns>
        public static bool lineIntersect(Vector2 ptA, Vector2 ptB, Vector2 ptC, Vector2 ptD, out Vector2 hitPt)
        {
            float Ua;
            float Ub;
            return lineIntersect(ptA, ptB, ptC, ptD, out hitPt, out Ua, out Ub);
        }

        /// <summary>
        /// see if 2 line segments intersect. (line AB collides with line CD) - simplified version (reference type version)
        /// </summary>
        /// <param name="ptA">first point on line AB</param>
        /// <param name="ptB">second point on line AB</param>
        /// <param name="ptC">first point on line CD</param>
        /// <param name="ptD">second point on line CD</param>
        /// <param name="hitPt">resulting point of intersection</param>
        /// <returns>true / false</returns>
        public static bool lineIntersect(ref Vector2 ptA, ref Vector2 ptB, ref Vector2 ptC, ref Vector2 ptD, out Vector2 hitPt)
        {
            float Ua;
            float Ub;
            return lineIntersect(ref ptA, ref ptB, ref ptC, ref ptD, out hitPt, out Ua, out Ub);
        }


        /// <summary>
        /// calculate a spring force, given position, velocity, spring constant, and damping factor.
        /// </summary>
        /// <param name="posA">position of point A on spring</param>
        /// <param name="velA">velocity of point A on spring</param>
        /// <param name="posB">position of point B on spring</param>
        /// <param name="velB">velocity of point B on spring</param>
        /// <param name="springD">rest distance of the springs</param>
        /// <param name="springK">spring constant</param>
        /// <param name="damping">coefficient for damping</param>
        /// <returns>spring force Vector</returns>
        public static Vector2 calculateSpringForce(Vector2 posA, Vector2 velA, Vector2 posB, Vector2 velB, float springD, float springK, float damping)
        {
            Vector2 BtoA = (posA - posB);
            float dist = BtoA.Length();
            if (dist > 0.0001f)
                BtoA /= dist;
            else
                BtoA = Vector2.Zero;
            
            dist = springD - dist;

            Vector2 relVel = velA - velB;
            float totalRelVel = Vector2.Dot(relVel, BtoA);

            return BtoA * ((dist * springK) - (totalRelVel * damping));  
        }

        /// <summary>
        /// calculate a spring force, given position, velocity, spring constant, and damping factor. (reference type version)
        /// </summary>
        /// <param name="posA">position of point A on spring</param>
        /// <param name="velA">velocity of point A on spring</param>
        /// <param name="posB">position of point B on spring</param>
        /// <param name="velB">velocity of point B on spring</param>
        /// <param name="springD">rest distance of the springs</param>
        /// <param name="springK">spring constant</param>
        /// <param name="damping">coefficient for damping</param>
        /// <param name="forceOut">rsulting force Vector2</param>
        public static void calculateSpringForce(ref Vector2 posA, ref Vector2 velA, ref Vector2 posB, ref Vector2 velB, float springD, float springK, float damping, ref Vector2 forceOut)
        {
            float BtoAX = (posA.X - posB.X);
            float BtoAY = (posA.Y - posB.Y);

            float dist = (float)Math.Sqrt((BtoAX * BtoAX) + (BtoAY * BtoAY));
            if (dist > 0.0001f)
            {
                BtoAX /= dist;
                BtoAY /= dist;
            }
            else
            {
                forceOut.X = 0;
                forceOut.Y = 0;
                return;
            }

            dist = springD - dist;

            float relVelX = velA.X - velB.X;
            float relVelY = velA.Y - velB.Y;

            float totalRelVel = (relVelX * BtoAX) + (relVelY * BtoAY);

            forceOut.X = BtoAX * ((dist * springK) - (totalRelVel * damping));
            forceOut.Y = BtoAY * ((dist * springK) - (totalRelVel * damping));
        }


        /// <summary>
        /// calculate a spring force, given position, velocity, spring constant, and damping factor. Allows slack in the spring. (reference type version)
        /// </summary>
        /// <param name="posA">position of point A on spring</param>
        /// <param name="velA">velocity of point A on spring</param>
        /// <param name="posB">position of point B on spring</param>
        /// <param name="velB">velocity of point B on spring</param>
        /// <param name="springD">rest distance of the springs</param>
        /// <param name="springK">spring constant</param>
        /// <param name="damping">coefficient for damping</param>
        /// <param name="forceOut">rsulting force Vector2</param>
        public static void calculateSpringForceAllowSlack(ref Vector2 posA, ref Vector2 velA, ref Vector2 posB, ref Vector2 velB, float springD, float springK, float damping, ref Vector2 forceOut)
        {
            float BtoAX = (posA.X - posB.X);
            float BtoAY = (posA.Y - posB.Y);

            float dist = (float)Math.Sqrt((BtoAX * BtoAX) + (BtoAY * BtoAY));
            if (dist > 0.0001f)
            {
                BtoAX /= dist;
                BtoAY /= dist;
            }
            else
            {
                forceOut.X = 0;
                forceOut.Y = 0;
                return;
            }

            dist = springD - dist;

            if (dist > 0.0f)
            {
                forceOut.X = forceOut.Y = 0.0f;
                return;
            }

            float relVelX = velA.X - velB.X;
            float relVelY = velA.Y - velB.Y;

            float totalRelVel = (relVelX * BtoAX) + (relVelY * BtoAY);

            forceOut.X = BtoAX * ((dist * springK) - (totalRelVel * damping));
            forceOut.Y = BtoAY * ((dist * springK) - (totalRelVel * damping));
        }
    }
}
