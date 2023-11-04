using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Xml;
using System.Globalization;

namespace JelloEditor
{
    // represents a soft body in the game world.
    class GameBody
    {
        #region public classes
        public class InternalSpring
        {
            public int PointMassA = -1;
            public int PointMassB = -1;
            public float SpringK = 0f;
            public float SpringDamping = 0f;
        };

        public class Polygon
        {
            public int[] PointMasses = new int[3];
        };

        public class PointMass
        {
            public PointMass(Vector2 p) { pos = p; }
            public Vector2 pos;
            public float mass = -1;
        };
        #endregion

        #region private vars
        private float mMassPerPoint;
        private string mName;
        private float mEdgeK;
        private float mEdgeDamping;
        private Microsoft.Xna.Framework.Graphics.Color mColor;
        private bool mKinematic;
        private bool mShapeMatchingOn;
        private float mShapeK;
        private float mShapeDamping;
        private bool mPressureBody;
        private float mPressure;
        #endregion

        #region public lists
        // LISTS
        public List<PointMass> Points;
        public List<InternalSpring> Springs;
        public List<Polygon> Polygons;
        #endregion

        #region constructors
        // // ///////////////////////////////////////////////////////////////////////////////////
        public GameBody(string name, string bodyType)
        {
            mName = name;
            // default constructor.  creates 3 default points... make that 4.
            if (bodyType == "default")
            {
                mMassPerPoint = 1.0f;

                mColor = Microsoft.Xna.Framework.Graphics.Color.GroundColor;

                mKinematic = false;

                mShapeMatchingOn = true;
                mShapeK = mEdgeK = 100f;
                mShapeDamping = mEdgeDamping = 10f;


                Points = new List<PointMass>();
                Springs = new List<InternalSpring>();
                Polygons = new List<Polygon>();

                Points.Add(new PointMass(new Vector2(-2f, -2f)));
                Points.Add(new PointMass(new Vector2(-2f, 2f)));
                Points.Add(new PointMass(new Vector2(2f, 2f)));
                Points.Add(new PointMass(new Vector2(2f, -2f)));
            }
            if (bodyType == "goal")
            {
                mMassPerPoint = 0.0f;

                mColor = Microsoft.Xna.Framework.Graphics.Color.Red;

                mKinematic = false;

                mShapeMatchingOn = true;
                mShapeK = mEdgeK = 100f;
                mShapeDamping = mEdgeDamping = 10f;


                Points = new List<PointMass>();
                Springs = new List<InternalSpring>();
                Polygons = new List<Polygon>();

                Points.Add(new PointMass(new Vector2(0f, 1f)));
                Points.Add(new PointMass(new Vector2(0.7071068f, 0.7071068f)));
                Points.Add(new PointMass(new Vector2(1f, -4.371139E-08f)));
                Points.Add(new PointMass(new Vector2(0.7071068f, -0.7071068f)));
                Points.Add(new PointMass(new Vector2(-8.742278E-08f, -1f)));
                Points.Add(new PointMass(new Vector2(-0.7071067f, -0.7071068f)));
                Points.Add(new PointMass(new Vector2(-1f, 1.192488E-08f)));
                Points.Add(new PointMass(new Vector2(-0.7071069f, 0.7071066f)));
            }
            if (bodyType == "jc2sticky")
            {
                mMassPerPoint = 0.0f;

                mColor = Microsoft.Xna.Framework.Graphics.Color.Black;

                mKinematic = false;

                mShapeMatchingOn = true;
                mShapeK = mEdgeK = 100f;
                mShapeDamping = mEdgeDamping = 10f;


                Points = new List<PointMass>();
                Springs = new List<InternalSpring>();
                Polygons = new List<Polygon>();

                Points.Add(new PointMass(new Vector2(0f, 1f)));
                Points.Add(new PointMass(new Vector2(0.2079117f, 0.9781476f)));
                Points.Add(new PointMass(new Vector2(0.4067366f, 0.9135454f)));
                Points.Add(new PointMass(new Vector2(0.5877852f, 0.809017f)));
                Points.Add(new PointMass(new Vector2(0.7431448f, 0.6691306f)));
                Points.Add(new PointMass(new Vector2(0.8660254f, 0.5f)));
                Points.Add(new PointMass(new Vector2(0.9510565f, 0.309017f)));
                Points.Add(new PointMass(new Vector2(0.9945219f, 0.1045285f)));
                Points.Add(new PointMass(new Vector2(0.9945219f, -0.1045284f)));
                Points.Add(new PointMass(new Vector2(0.9510565f, -0.309017f)));
                Points.Add(new PointMass(new Vector2(0.8660254f, -0.5f)));
                Points.Add(new PointMass(new Vector2(0.7431448f, -0.6691306f)));
                Points.Add(new PointMass(new Vector2(0.5877852f, -0.809017f)));
                Points.Add(new PointMass(new Vector2(0.4067367f, -0.9135454f)));
                Points.Add(new PointMass(new Vector2(0.2079117f, -0.9781476f)));
                Points.Add(new PointMass(new Vector2(2.433593E-08f, -1f)));
                Points.Add(new PointMass(new Vector2(-0.2079117f, -0.9781476f)));
                Points.Add(new PointMass(new Vector2(-0.4067366f, -0.9135455f)));
                Points.Add(new PointMass(new Vector2(-0.5877852f, -0.809017f)));
                Points.Add(new PointMass(new Vector2(-0.7431448f, -0.6691306f)));
                Points.Add(new PointMass(new Vector2(-0.8660254f, -0.5f)));
                Points.Add(new PointMass(new Vector2(-0.9510565f, -0.309017f)));
                Points.Add(new PointMass(new Vector2(-0.9945219f, -0.1045285f)));
                Points.Add(new PointMass(new Vector2(-0.9945219f, 0.1045284f)));
                Points.Add(new PointMass(new Vector2(-0.9510565f, 0.3090169f)));
                Points.Add(new PointMass(new Vector2(-0.8660254f, 0.5f)));
                Points.Add(new PointMass(new Vector2(-0.7431449f, 0.6691306f)));
                Points.Add(new PointMass(new Vector2(-0.5877853f, 0.8090169f)));
                Points.Add(new PointMass(new Vector2(-0.4067367f, 0.9135454f)));
                Points.Add(new PointMass(new Vector2(-0.2079117f, 0.9781476f)));
            }
            if (bodyType == "jc2balloon")
            {
                mMassPerPoint = 0.0f;

                mColor = Microsoft.Xna.Framework.Graphics.Color.Black;

                mKinematic = false;

                mShapeMatchingOn = true;
                mShapeK = mEdgeK = 100f;
                mShapeDamping = mEdgeDamping = 10f;


                Points = new List<PointMass>();
                Springs = new List<InternalSpring>();
                Polygons = new List<Polygon>();

                Points.Add(new PointMass(new Vector2(0f, 1f)));
                Points.Add(new PointMass(new Vector2(0.309017f, 0.9510565f)));
                Points.Add(new PointMass(new Vector2(0.5877852f, 0.809017f)));
                Points.Add(new PointMass(new Vector2(0.809017f, 0.5877852f)));
                Points.Add(new PointMass(new Vector2(0.9510565f, 0.309017f)));
                Points.Add(new PointMass(new Vector2(1f, 1.216796E-08f)));
                Points.Add(new PointMass(new Vector2(0.9510565f, -0.309017f)));
                Points.Add(new PointMass(new Vector2(0.809017f, -0.5877852f)));
                Points.Add(new PointMass(new Vector2(0.5877852f, -0.809017f)));
                Points.Add(new PointMass(new Vector2(0.309017f, -0.9510565f)));
                Points.Add(new PointMass(new Vector2(2.433593E-08f, -1f)));
                Points.Add(new PointMass(new Vector2(-0.309017f, -0.9510565f)));
                Points.Add(new PointMass(new Vector2(-0.5877852f, -0.809017f)));
                Points.Add(new PointMass(new Vector2(-0.809017f, -0.5877853f)));
                Points.Add(new PointMass(new Vector2(-0.9510565f, -0.309017f)));
                Points.Add(new PointMass(new Vector2(-1f, -3.65039E-08f)));
                Points.Add(new PointMass(new Vector2(-0.9510565f, 0.3090169f)));
                Points.Add(new PointMass(new Vector2(-0.809017f, 0.5877852f)));
                Points.Add(new PointMass(new Vector2(-0.5877853f, 0.8090169f)));
                Points.Add(new PointMass(new Vector2(-0.309017f, 0.9510565f)));
            }
        }
        #endregion

        #region loading from XML
        public void initFromXml(string filename)
        {
            Points.Clear();
            Springs.Clear();
            Polygons.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            // mass per point, and edge settings.
            XmlNodeList root = doc.GetElementsByTagName("SoftBody");
            if (root.Count > 0)
            {
                XmlElement rt = (XmlElement)root[0];
                mMassPerPoint = float.Parse(rt.GetAttribute("massPerPoint"), CultureInfo.InvariantCulture);

                mEdgeK = float.Parse(rt.GetAttribute("edgeK"));
                mEdgeDamping = float.Parse(rt.GetAttribute("edgeDamping"), CultureInfo.InvariantCulture);

                if (rt.HasAttribute("colorR"))
                {
                    mColor = new Microsoft.Xna.Framework.Graphics.Color(new Vector3(
                        float.Parse(rt.GetAttribute("colorR"), CultureInfo.InvariantCulture) * 255,
                        float.Parse(rt.GetAttribute("colorG"), CultureInfo.InvariantCulture) * 255,
                        float.Parse(rt.GetAttribute("colorB"), CultureInfo.InvariantCulture) * 255));
                }
                else
                    mColor = Microsoft.Xna.Framework.Graphics.Color.GroundColor;

                if (rt.HasAttribute("kinematic"))
                    mKinematic = bool.Parse(rt.GetAttribute("kinematic"));
                
                if (rt.HasAttribute("shapeMatching"))
                {
                    mShapeMatchingOn = bool.Parse(rt.GetAttribute("shapeMatching"));

                    if (mShapeMatchingOn)
                    {
                        mShapeK = float.Parse(rt.GetAttribute("shapeK"), CultureInfo.InvariantCulture);
                        mShapeDamping = float.Parse(rt.GetAttribute("shapeDamping"), CultureInfo.InvariantCulture);
                    }
                }
            }

            // points!
            XmlNodeList points = doc.GetElementsByTagName("Point");
            for (int i = 0; i < points.Count; i++)
            {
                XmlElement p = (XmlElement)points[i];

                Vector2 pt = new Vector2();
                pt.X = float.Parse(p.GetAttribute("x"), CultureInfo.InvariantCulture);
                pt.Y = float.Parse(p.GetAttribute("y"), CultureInfo.InvariantCulture);

                Points.Add(new PointMass(pt));

                if (p.HasAttribute("mass"))
                {
                    Points[Points.Count - 1].mass = float.Parse(p.GetAttribute("mass"), CultureInfo.InvariantCulture);
                }
            }

            // springs!
            XmlNodeList springs = doc.GetElementsByTagName("Spring");
            for (int i = 0; i < springs.Count; i++)
            {
                XmlElement sp = (XmlElement)springs[i];

                InternalSpring insp = new InternalSpring();

                insp.PointMassA = int.Parse(sp.GetAttribute("pt1"), CultureInfo.InvariantCulture);
                insp.PointMassB = int.Parse(sp.GetAttribute("pt2"), CultureInfo.InvariantCulture);
                insp.SpringK = float.Parse(sp.GetAttribute("k"), CultureInfo.InvariantCulture);
                insp.SpringDamping = float.Parse(sp.GetAttribute("damp"), CultureInfo.InvariantCulture);

                Springs.Add(insp);
            }

            // polygons!
            XmlNodeList polygons = doc.GetElementsByTagName("Poly");
            for (int i = 0; i < polygons.Count; i++)
            {
                XmlElement poly = (XmlElement)polygons[i];

                Polygon p = new Polygon();

                for (int j = 0; j < 3; j++)
                    p.PointMasses[j] = int.Parse(poly.GetAttribute("pt" + j.ToString()), CultureInfo.InvariantCulture);

                Polygons.Add(p);
            }

            // pressure!
            XmlNodeList pressure = doc.GetElementsByTagName("Pressure");
            if (pressure.Count > 0)
            {
                XmlElement pres = (XmlElement)pressure[0];

                mPressureBody = true;
                mPressure = float.Parse(pres.GetAttribute("amount"), CultureInfo.InvariantCulture);
            }
            else
            {
                mPressureBody = false;
                mPressure = 0f;
            }

        }

        public void initFromXmlText(string fileContents)
        {
            Points.Clear();
            Springs.Clear();
            Polygons.Clear();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(fileContents);

            // mass per point, and edge settings.
            XmlNodeList root = doc.GetElementsByTagName("SoftBody");
            if (root.Count > 0)
            {
                XmlElement rt = (XmlElement)root[0];
                mMassPerPoint = float.Parse(rt.GetAttribute("massPerPoint"), CultureInfo.InvariantCulture);

                mEdgeK = float.Parse(rt.GetAttribute("edgeK"));
                mEdgeDamping = float.Parse(rt.GetAttribute("edgeDamping"), CultureInfo.InvariantCulture);

                if (rt.HasAttribute("colorR"))
                {
                    mColor = new Microsoft.Xna.Framework.Graphics.Color(new Vector3(
                        float.Parse(rt.GetAttribute("colorR"), CultureInfo.InvariantCulture) * 255,
                        float.Parse(rt.GetAttribute("colorG"), CultureInfo.InvariantCulture) * 255,
                        float.Parse(rt.GetAttribute("colorB"), CultureInfo.InvariantCulture) * 255));
                }
                else
                    mColor = Microsoft.Xna.Framework.Graphics.Color.GroundColor;

                if (rt.HasAttribute("kinematic"))
                    mKinematic = bool.Parse(rt.GetAttribute("kinematic"));

                if (rt.HasAttribute("shapeMatching"))
                {
                    mShapeMatchingOn = bool.Parse(rt.GetAttribute("shapeMatching"));

                    if (mShapeMatchingOn)
                    {
                        mShapeK = float.Parse(rt.GetAttribute("shapeK"), CultureInfo.InvariantCulture);
                        mShapeDamping = float.Parse(rt.GetAttribute("shapeDamping"), CultureInfo.InvariantCulture);
                    }
                }
            }

            // points!
            XmlNodeList points = doc.GetElementsByTagName("Point");
            for (int i = 0; i < points.Count; i++)
            {
                XmlElement p = (XmlElement)points[i];

                Vector2 pt = new Vector2();
                pt.X = float.Parse(p.GetAttribute("x"), CultureInfo.InvariantCulture);
                pt.Y = float.Parse(p.GetAttribute("y"), CultureInfo.InvariantCulture);

                Points.Add(new PointMass(pt));

                if (p.HasAttribute("mass"))
                {
                    Points[Points.Count - 1].mass = float.Parse(p.GetAttribute("mass"), CultureInfo.InvariantCulture);
                }
            }

            // springs!
            XmlNodeList springs = doc.GetElementsByTagName("Spring");
            for (int i = 0; i < springs.Count; i++)
            {
                XmlElement sp = (XmlElement)springs[i];

                InternalSpring insp = new InternalSpring();

                insp.PointMassA = int.Parse(sp.GetAttribute("pt1"), CultureInfo.InvariantCulture);
                insp.PointMassB = int.Parse(sp.GetAttribute("pt2"), CultureInfo.InvariantCulture);
                insp.SpringK = float.Parse(sp.GetAttribute("k"), CultureInfo.InvariantCulture);
                insp.SpringDamping = float.Parse(sp.GetAttribute("damp"), CultureInfo.InvariantCulture);

                Springs.Add(insp);
            }

            // polygons!
            XmlNodeList polygons = doc.GetElementsByTagName("Poly");
            for (int i = 0; i < polygons.Count; i++)
            {
                XmlElement poly = (XmlElement)polygons[i];

                Polygon p = new Polygon();

                for (int j = 0; j < 3; j++)
                    p.PointMasses[j] = int.Parse(poly.GetAttribute("pt" + j.ToString()), CultureInfo.InvariantCulture);

                Polygons.Add(p);
            }

            // pressure!
            XmlNodeList pressure = doc.GetElementsByTagName("Pressure");
            if (pressure.Count > 0)
            {
                XmlElement pres = (XmlElement)pressure[0];

                mPressureBody = true;
                mPressure = float.Parse(pres.GetAttribute("amount"), CultureInfo.InvariantCulture);
            }
            else
            {
                mPressureBody = false;
                mPressure = 0f;
            }

        }
        #endregion

        #region saving to XML
        public void saveToXml(string filename)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("SoftBody");
            root.SetAttribute("name", Name);
            root.SetAttribute("massPerPoint", MassPerPoint.ToString(CultureInfo.InvariantCulture));
            root.SetAttribute("edgeK", mEdgeK.ToString(CultureInfo.InvariantCulture));
            root.SetAttribute("edgeDamping", mEdgeDamping.ToString(CultureInfo.InvariantCulture));

            float colorR = mColor.ToVector3().X / 255;
            float colorG = mColor.ToVector3().Y / 255;
            float colorB = mColor.ToVector3().Z / 255;

            root.SetAttribute("colorR", colorR.ToString(CultureInfo.InvariantCulture));
            root.SetAttribute("colorG", colorG.ToString(CultureInfo.InvariantCulture));
            root.SetAttribute("colorB", colorB.ToString(CultureInfo.InvariantCulture));

            root.SetAttribute("kinematic", mKinematic.ToString(CultureInfo.InvariantCulture));

            root.SetAttribute("shapeMatching", mShapeMatchingOn.ToString(CultureInfo.InvariantCulture));
            root.SetAttribute("shapeK", mShapeK.ToString(CultureInfo.InvariantCulture));
            root.SetAttribute("shapeDamping", mShapeDamping.ToString(CultureInfo.InvariantCulture));

            // pressure
            if (mPressureBody)
            {
                XmlElement pressure = doc.CreateElement("Pressure");
                pressure.SetAttribute("amount", mPressure.ToString(CultureInfo.InvariantCulture));
                root.AppendChild(pressure);
            }

            // points
            XmlElement pts = doc.CreateElement("Points");
            for (int i = 0; i < Points.Count; i++)
            {
                XmlElement pt = doc.CreateElement("Point");
                pt.SetAttribute("x", Points[i].pos.X.ToString(CultureInfo.InvariantCulture));
                pt.SetAttribute("y", Points[i].pos.Y.ToString(CultureInfo.InvariantCulture));

                if (Points[i].mass != -1)
                    pt.SetAttribute("mass", Points[i].mass.ToString(CultureInfo.InvariantCulture));
                pts.AppendChild(pt);
            }
            root.AppendChild(pts);

            // springs
            XmlElement spgs = doc.CreateElement("Springs");
            for (int i = 0; i < Springs.Count; i++)
            {
                XmlElement spr = doc.CreateElement("Spring");
                spr.SetAttribute("pt1", Springs[i].PointMassA.ToString(CultureInfo.InvariantCulture));
                spr.SetAttribute("pt2", Springs[i].PointMassB.ToString(CultureInfo.InvariantCulture));
                spr.SetAttribute("k", Springs[i].SpringK.ToString(CultureInfo.InvariantCulture));
                spr.SetAttribute("damp", Springs[i].SpringDamping.ToString(CultureInfo.InvariantCulture));

                spgs.AppendChild(spr);
            }
            root.AppendChild(spgs);

            // polygons.
            XmlElement polys = doc.CreateElement("Polygons");
            for (int i = 0; i < Polygons.Count; i++)
            {
                XmlElement poly = doc.CreateElement("Poly");
                for (int j = 0; j < 3; j++)
                    poly.SetAttribute("pt" + j.ToString(), Polygons[i].PointMasses[j].ToString(CultureInfo.InvariantCulture));

                polys.AppendChild(poly);
            }
            root.AppendChild(polys);

            doc.AppendChild(root);
            doc.Save(filename);
        }

        public string returnXml(string filename)
        {
            XmlDocument sbdoc = new XmlDocument();
            XmlElement sbroot = sbdoc.CreateElement("SoftBody");
            sbroot.SetAttribute("name", Name);
            sbroot.SetAttribute("massPerPoint", MassPerPoint.ToString(CultureInfo.InvariantCulture));
            sbroot.SetAttribute("edgeK", mEdgeK.ToString(CultureInfo.InvariantCulture));
            sbroot.SetAttribute("edgeDamping", mEdgeDamping.ToString(CultureInfo.InvariantCulture));

            float colorR = mColor.ToVector3().X / 255;
            float colorG = mColor.ToVector3().Y / 255;
            float colorB = mColor.ToVector3().Z / 255;

            sbroot.SetAttribute("colorR", colorR.ToString(CultureInfo.InvariantCulture));
            sbroot.SetAttribute("colorG", colorG.ToString(CultureInfo.InvariantCulture));
            sbroot.SetAttribute("colorB", colorB.ToString(CultureInfo.InvariantCulture));

            sbroot.SetAttribute("kinematic", mKinematic.ToString(CultureInfo.InvariantCulture));

            sbroot.SetAttribute("shapeMatching", mShapeMatchingOn.ToString(CultureInfo.InvariantCulture));
            sbroot.SetAttribute("shapeK", mShapeK.ToString(CultureInfo.InvariantCulture));
            sbroot.SetAttribute("shapeDamping", mShapeDamping.ToString(CultureInfo.InvariantCulture));

            // pressure
            if (mPressureBody)
            {
                XmlElement pressure = sbdoc.CreateElement("Pressure");
                pressure.SetAttribute("amount", mPressure.ToString(CultureInfo.InvariantCulture));
                sbroot.AppendChild(pressure);
            }

            // points
            XmlElement pts = sbdoc.CreateElement("Points");
            for (int i = 0; i < Points.Count; i++)
            {
                XmlElement pt = sbdoc.CreateElement("Point");
                pt.SetAttribute("x", Points[i].pos.X.ToString(CultureInfo.InvariantCulture));
                pt.SetAttribute("y", Points[i].pos.Y.ToString(CultureInfo.InvariantCulture));

                if (Points[i].mass != -1)
                    pt.SetAttribute("mass", Points[i].mass.ToString(CultureInfo.InvariantCulture));
                pts.AppendChild(pt);
            }
            sbroot.AppendChild(pts);

            // springs
            XmlElement spgs = sbdoc.CreateElement("Springs");
            for (int i = 0; i < Springs.Count; i++)
            {
                XmlElement spr = sbdoc.CreateElement("Spring");
                spr.SetAttribute("pt1", Springs[i].PointMassA.ToString(CultureInfo.InvariantCulture));
                spr.SetAttribute("pt2", Springs[i].PointMassB.ToString(CultureInfo.InvariantCulture));
                spr.SetAttribute("k", Springs[i].SpringK.ToString(CultureInfo.InvariantCulture));
                spr.SetAttribute("damp", Springs[i].SpringDamping.ToString(CultureInfo.InvariantCulture));

                spgs.AppendChild(spr);
            }
            sbroot.AppendChild(spgs);

            // polygons.
            XmlElement polys = sbdoc.CreateElement("Polygons");
            for (int i = 0; i < Polygons.Count; i++)
            {
                XmlElement poly = sbdoc.CreateElement("Poly");
                for (int j = 0; j < 3; j++)
                    poly.SetAttribute("pt" + j.ToString(), Polygons[i].PointMasses[j].ToString(CultureInfo.InvariantCulture));

                polys.AppendChild(poly);
            }
            sbroot.AppendChild(polys);

            sbdoc.AppendChild(sbroot);
            return (sbdoc.OuterXml);
        }
        #endregion

        #region public properties
        public float MassPerPoint
        {
            get { return mMassPerPoint; }
            set { mMassPerPoint = value; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public float EdgeK
        {
            get { return mEdgeK; }
            set { mEdgeK = value; }
        }

        public float EdgeDamping
        {
            get { return mEdgeDamping; }
            set { mEdgeDamping = value; }
        }

        public Microsoft.Xna.Framework.Graphics.Color Color
        {
            get { return mColor; }
            set { mColor = value; }
        }

        public bool Kinematic
        {
            get { return mKinematic; }
            set { mKinematic = value; }
        }

        public bool ShapeMatchingOn
        {
            get { return mShapeMatchingOn; }
            set { mShapeMatchingOn = value; }
        }

        public float ShapeK
        {
            get { return mShapeK; }
            set { mShapeK = value; }
        }

        public float ShapeDamping
        {
            get { return mShapeDamping; }
            set { mShapeDamping = value; }
        }

        public bool Pressurized
        {
            get { return mPressureBody; }
            set { mPressureBody = value; }
        }

        public float GasPressure
        {
            get { return mPressure; }
            set { mPressure = value; }
        }
        #endregion
    }
}
