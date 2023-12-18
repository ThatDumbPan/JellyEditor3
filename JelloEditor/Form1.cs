using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Design;
using System.Xml;
using System.Globalization;
using System.IO;

namespace JelloEditor
{
    public partial class Form1 : Form
    {
        #region private variables
        private GridSettings mGridSettings;
        private CreateCircle mCreateCircle;
        private SceneSettings mSceneSettings;
        private MotionSettings mMotionSettings;
        private PointSpecialMass mSpecialMass;
        private About mAbout;
        private Image mImage;
        private Graphics mGraphics = null;
        private bool mShowGrid = true;
        public bool lightMode = true;
        private string hasRope;
        // private bool prefValueBool;
        private bool goalInLevel = false;
        private bool secretInLevel = false;
        private bool stickyInLevel = false;
        private bool balloonInLevel = false;
        private bool itemstickInLevel = false;
        private bool itemballoonInLevel = false;

        // Grid settings
        int mGridSizeX = 1000;
        int mGridSizeY = 1000;
        float mGridMajorSub = 4.0f;
        int mGridMinorSub = 1;
        float mGridCenterX;
        float mGridCenterY;
        float mGridZoom = 20.0f;

        int mGridDragX;
        int mGridDragY;

        // this is a list that contains 1 entry for each distinct body contained in the scene (or in memory).
        List<GameBody> mSceneBodies;
        
        ////////////////////////////////
        // Scene Objects
        class MotorMotionCommand
        {
            public enum CommandType
            {
                Rotate,
                Wait,
                Move
            }

            private CommandType _cmdType;
            private float _dur;
            private float _angle;
            private float _amount;

            public string commandType
            {
                get
                {
                    switch (_cmdType)
                    {
                        case CommandType.Move:
                            return "Move";

                        case CommandType.Rotate:
                            return "Rotate";

                        case CommandType.Wait:
                        default:
                            return "Wait";
                    }
                }

                set
                {
                    if (value == "Wait")
                        _cmdType = CommandType.Wait;
                    else if (value == "Move")
                        _cmdType = CommandType.Move;
                    else
                        _cmdType = CommandType.Rotate;
                }
            }

            public float duration
            {
                get { return _dur; }
                set { _dur = value; }
            }

            public float angle
            {
                get { return _angle; }
                set { _angle = value; }
            }

            public float amount
            {
                get { return _amount; }
                set { _amount = value; }
            }
        }

        class SceneObject
        {
            public enum PlatformTriggerBehavior
            {
                Stop,
                ReturnToStart
            }

            public enum MotorTriggerBehavior
            {
                Stop,
                OneShot
            }

            public SceneObject() 
            { 
                body = null; 
                pos = Vector2.Zero; 
                angle = 0f; 
                scale = Vector2.One; 
                material = 0;

                motionPlatformON = false;
                motionMotorON = false;
                objNoRope = false;
                
                hasCustomColor = false;
                customColor = Microsoft.Xna.Framework.Graphics.Color.White;

                isTrigger = false;
            }

            public GameBody body;
            public Vector2 pos;
            public float angle;
            public Vector2 scale;
            public int material;

            public bool hasCustomColor;
            public Microsoft.Xna.Framework.Graphics.Color customColor;

            public bool isTrigger;
            public List<SceneObject> triggerTargets = new List<SceneObject>();
            public bool triggerNoCam = false;

            public bool motionPlatformON;
            public Vector2 motionPlatformOffset;
            public float motionPlatformLoop;
            public float motionPlatformStartOffset;
            public float motionPlatformPauseAtEnds;
            public PlatformTriggerBehavior motionPlatformTriggerBehavior;
            public SceneObject motionPlatformFollowPath = null;

            public bool motionMotorON;
            public bool objNoRope;
            public BindingList<MotorMotionCommand> motionMotorCommands = new BindingList<MotorMotionCommand>();
            public MotorTriggerBehavior motionMotorTriggerBehavior;

            public bool isPath;
            public bool pathClosed;
        };

        List<SceneObject> mSceneObjects;
        static int mBodyCount = 0;
        int mSelectedObject = -1;
        bool mIgnoreSceneValueChange = false;
        int mSelectedPoint = -1;
        int mSelectedSpring = -1;
        bool mIgnoreObjectValueChange = false;

        bool mDraggingSpring = false;
        int mDragSpringStartPoint = -1;

        bool mAddingPoly = false;
        int[] mPolyInProgress = new int[3];
        Vector2 mMouseScreen;

        public enum EditMode { Scene, Object };
        public enum ObjectEditMode { Points, Springs, Polygons };

        EditMode mEditMode = EditMode.Scene;
        ObjectEditMode mObjectEditMode = ObjectEditMode.Points;
        bool mChoosingTarget = false;

        bool mChoosingPathPlatform = false;

        string[] mMaterialNames = { "0 Basic Ground", "1 Dynamic Object", "2 Car Chassis", "3 Car Tire", "4 Ice", "5 Ghost", "06 EXTRA", "07 EXTRA" };

        string sceneFile;
        string[] sceneFiles;
        #endregion

        #region constructor
        public Form1()
        {
            InitializeComponent();

            // create a GridSettings form.
            mGridSettings = new GridSettings(this);
            mGridSettings.Hide();

            mCreateCircle = new CreateCircle();
            mCreateCircle.Hide();

            mSceneSettings = new SceneSettings();
            mSceneSettings.Hide();

            mMotionSettings = new MotionSettings();
            mMotionSettings.Hide();

            mSpecialMass = new PointSpecialMass();
            mSpecialMass.Hide();

            mAbout = new About();
            mAbout.Hide();

            pictureBox1.Image = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            mImage = pictureBox1.Image;
            mGraphics = Graphics.FromImage(mImage);

            mGridCenterX = pictureBox1.Width / 2;
            mGridCenterY = pictureBox1.Height / 2;

            mSceneBodies = new List<GameBody>();
            mSceneObjects = new List<SceneObject>();

            updateSceneTree();
            redrawImage();

            // check for command-line argument to load a file.
            if (Environment.GetCommandLineArgs().Length > 1)
                openScene(Environment.GetCommandLineArgs()[1]);
        }
        #endregion

        #region menu callbacks
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult newSceneDialogResult = MessageBox.Show("Are you sure you want to start a new scene? (All unsaved work will be lost)", "Confirmation", MessageBoxButtons.YesNo);
            if (newSceneDialogResult == DialogResult.Yes)
            {
                newScene();
                redrawImage();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Scene Files|*.scene|Xml Files|*.xml";
            openFileDialog1.Title = "Open Scene...";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sceneFile = "";
                openScene(openFileDialog1.FileName);
            }
        }

        private void openScene(string p)
        {
            goalInLevel = false;
            secretInLevel = false;
            stickyInLevel = false;
            balloonInLevel = false;
            itemstickInLevel = false;
            itemballoonInLevel = false;

            if (!System.IO.File.Exists(p))
            {
                MessageBox.Show("File does not exist: " + p, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (System.IO.Path.GetExtension(p) != ".scene")
                return;

            // load a new scene!
            newScene();

            XmlDocument doc = new XmlDocument();
            doc.Load(p);

            XmlNodeList scene = doc.GetElementsByTagName("Scene");
            if (scene.Count > 0)
            {
                XmlElement sc = (XmlElement)scene[0];
                mSceneSettings.SceneName = sc.GetAttribute("name");

                XmlNodeList obj_root = doc.GetElementsByTagName("Objects");
                if (obj_root.Count == 0)
                    return;

                List< KeyValuePair<SceneObject, int> > triggerPairs = new List<KeyValuePair<SceneObject,int>>();
                List<KeyValuePair<SceneObject, int>> pathPairs = new List<KeyValuePair<SceneObject, int>>();

                XmlNodeList objects = obj_root[0].ChildNodes;
                for (int i = 0; i < objects.Count; i++)
                {
                    if (objects[i].NodeType != XmlNodeType.Element)
                        continue;

                    XmlElement obj = (XmlElement)objects[i];

                    if ((obj.Name != "Object") && (obj.Name != "Path"))
                        continue;

                    string name = obj.GetAttribute("name");

                    GameBody b = null;
                    for (int j = 0; j < mSceneBodies.Count; j++)
                        if (name == mSceneBodies[j].Name) { b = mSceneBodies[j]; }

                    if (b == null)
                    {
                        // load this one new.
                        b = new GameBody(name, "default");
                        string bodyFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(p), name + ".softbody");
                        if (System.IO.File.Exists(bodyFile))
                            b.initFromXml(bodyFile);
                        else
                        {
                            openFileDialog1.Title = "Where is the soft body file for '" + name + "'?";
                            openFileDialog1.Filter = "Soft Body files|*.softbody|Xml files|*.xml";
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                b.initFromXml(openFileDialog1.FileName);
                            }
                            else
                            {
                                // error.
                                MessageBox.Show("creating placeholder body for: " + name);
                            }
                        }

                        mSceneBodies.Add(b);
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "goal")
                            continue;
                        else
                        {
                            goalInLevel = true;
                            break;
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "secret")
                            continue;
                        else
                        {
                            secretInLevel = true;
                            break;
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "sticky")
                            continue;
                        else
                        {
                            stickyInLevel = true;
                            break;
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "balloon")
                            continue;
                        else
                        {
                            balloonInLevel = true;
                            break;
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "itemstick")
                            continue;
                        else
                        {
                            itemstickInLevel = true;
                            break;
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "itemballoon")
                            continue;
                        else
                        {
                            itemballoonInLevel = true;
                            break;
                        }
                    }

                    // game object.
                    SceneObject o = new SceneObject();
                    if (obj.Name == "Path")
                    {
                        o.isPath = true;
                        o.pathClosed = bool.Parse(obj.GetAttribute("closed"));
                    }

                    o.body = b;
                    o.pos.X = float.Parse(obj.GetAttribute("posX"), CultureInfo.InvariantCulture);
                    o.pos.Y = float.Parse(obj.GetAttribute("posY"), CultureInfo.InvariantCulture);
                    o.angle = float.Parse(obj.GetAttribute("angle"), CultureInfo.InvariantCulture);
                    o.scale.X = float.Parse(obj.GetAttribute("scaleX"), CultureInfo.InvariantCulture);
                    o.scale.Y = float.Parse(obj.GetAttribute("scaleY"), CultureInfo.InvariantCulture);

                    if (obj.HasAttribute("material"))
                        o.material = int.Parse(obj.GetAttribute("material"), CultureInfo.InvariantCulture);
                    else
                        o.material = 0;

                    if (obj.HasAttribute("color"))
                    {
                        o.hasCustomColor = true;
                        string[] bits = obj.GetAttribute("color").Split(' ');

                        // BYTE based
                        try
                        {
                            byte cr, cg, cb;
                            byte ca = 255;
                            cr = byte.Parse(bits[0], CultureInfo.InvariantCulture);
                            cg = byte.Parse(bits[1], CultureInfo.InvariantCulture);
                            cb = byte.Parse(bits[2], CultureInfo.InvariantCulture);
                            if (bits.Length > 3)
                                ca = byte.Parse(bits[3], CultureInfo.InvariantCulture);

                            o.customColor = new Microsoft.Xna.Framework.Graphics.Color(cr, cg, cb, ca);
                        }
                        catch (Exception e)
                        {
                        }


                        /* FLOAT based
                        try
                        {
                            float cr, cg, cb;
                            float ca = 1.0f;
                            cr = float.Parse(bits[0], NumberStyles.Any, CultureInfo.InvariantCulture);
                            cg = float.Parse(bits[1], NumberStyles.Any, CultureInfo.InvariantCulture);
                            cb = float.Parse(bits[2], NumberStyles.Any, CultureInfo.InvariantCulture);
                            if (bits.Length > 3)
                                ca = float.Parse(bits[3], NumberStyles.Any, CultureInfo.InvariantCulture);

                            o.customColor = new Microsoft.Xna.Framework.Graphics.Color(cr, cg, cb, ca);
                        }
                        catch (Exception e)
                        {
                        }
                        */
                        
                    }

                    if (obj.HasAttribute("triggerTargets"))
                    {
                        string[] ids = obj.GetAttribute("triggerTargets").Split(' ');
                        foreach (string id in ids)
                        {
                            int target = int.Parse(id, CultureInfo.InvariantCulture);
                            triggerPairs.Add(new KeyValuePair<SceneObject, int>(o, target));
                        }

                        if (obj.HasAttribute("triggerIgnoreCam"))
                            o.triggerNoCam = true;
                    }

                    // motion!
                    if (obj.HasChildNodes)
                    {
                        XmlNodeList motions = obj.ChildNodes;
                        XmlElement motion = (XmlElement)motions[0];
                        if (motion.Name == "KinematicControls")
                        {
                            XmlElement motion_type = (XmlElement)motion.FirstChild;
                            while (motion_type != null)
                            {

                                if (motion_type.Name == "PlatformMotion")
                                {
                                    o.motionPlatformON = true;

                                    if (motion_type.HasAttribute("offsetX"))
                                        o.motionPlatformOffset.X = float.Parse(motion_type.GetAttribute("offsetX"), CultureInfo.InvariantCulture);

                                    if (motion_type.HasAttribute("offsetY"))
                                        o.motionPlatformOffset.Y = float.Parse(motion_type.GetAttribute("offsetY"), CultureInfo.InvariantCulture);
                                    
                                    if (motion_type.HasAttribute("path"))
                                        pathPairs.Add( new KeyValuePair<SceneObject,int>( o, int.Parse(motion_type.GetAttribute("path"), CultureInfo.InvariantCulture) ) );
                                    
                                    o.motionPlatformLoop = float.Parse(motion_type.GetAttribute("secondsPerLoop"), CultureInfo.InvariantCulture);
                                    
                                    if (motion_type.HasAttribute("pauseAtEnds"))
                                        o.motionPlatformPauseAtEnds = float.Parse(motion_type.GetAttribute("pauseAtEnds"), CultureInfo.InvariantCulture);
                                    
                                    if (motion_type.HasAttribute("triggerBehavior"))
                                        o.motionPlatformTriggerBehavior = (SceneObject.PlatformTriggerBehavior)int.Parse(motion_type.GetAttribute("triggerBehavior"), CultureInfo.InvariantCulture);

                                    if (motion_type.HasAttribute("startOffset"))
                                        o.motionPlatformStartOffset = float.Parse(motion_type.GetAttribute("startOffset"), CultureInfo.InvariantCulture);
                                }

                                if (motion_type.Name == "Motor")
                                {
                                    o.motionMotorON = true;
                                    if (motion_type.HasAttribute("radiansPerSecond"))
                                    {
                                        // legacy scene, only had 1 setting for speed.
                                        MotorMotionCommand cmd = new MotorMotionCommand();
                                        cmd.commandType = "Rotate";
                                        cmd.duration = 1.0f;
                                        cmd.angle = MathHelper.ToDegrees(float.Parse(motion_type.GetAttribute("radiansPerSecond"), CultureInfo.InvariantCulture));

                                        o.motionMotorTriggerBehavior = SceneObject.MotorTriggerBehavior.Stop;
                                        o.motionMotorCommands.Add(cmd);
                                    }
                                    else if (motion_type.HasChildNodes)
                                    {
                                        if (motion_type.HasAttribute("triggerBehavior"))
                                            o.motionMotorTriggerBehavior = (SceneObject.MotorTriggerBehavior)int.Parse(motion_type.GetAttribute("triggerBehavior"), CultureInfo.InvariantCulture);

                                        XmlNodeList motor_kids = motion_type.ChildNodes;
                                        foreach( XmlNode mcmd in motor_kids )
                                        {
                                            if (mcmd.Name == "MotorCommand")
                                            {
                                                XmlElement mcme = (XmlElement)mcmd;

                                                MotorMotionCommand cmd = new MotorMotionCommand();
                                                cmd.commandType = mcme.GetAttribute("type");
                                                cmd.duration = float.Parse(mcme.GetAttribute("duration"), CultureInfo.InvariantCulture);
                                                
                                                if (mcme.HasAttribute("angle"))
                                                    cmd.angle = MathHelper.ToDegrees(float.Parse(mcme.GetAttribute("angle"), CultureInfo.InvariantCulture));

                                                if (mcme.HasAttribute("amount"))
                                                    cmd.amount = float.Parse(mcme.GetAttribute("amount"), CultureInfo.InvariantCulture);

                                                o.motionMotorCommands.Add(cmd);
                                            }
                                        }
                                    }
                                }
                                motion_type = (XmlElement)motion_type.NextSibling;
                            }
                        }
                    }

                    if (obj.HasAttribute("noRope"))
                    {
                        hasRope = obj.GetAttribute("noRope");
                        if (hasRope == "True")
                            o.objNoRope = true;
                        else
                            o.objNoRope = false;
                    }
                    else
                    {
                        o.objNoRope = false;
                    }

                    mSceneObjects.Add(o);

                }

                // hook-up target pairs.
                foreach (KeyValuePair<SceneObject, int> kvp in triggerPairs)
                {
                    kvp.Key.isTrigger = true;
                    kvp.Key.triggerTargets.Add(mSceneObjects[kvp.Value]);
                }

                foreach (KeyValuePair<SceneObject, int> kvp in pathPairs)
                {
                    kvp.Key.motionPlatformFollowPath = mSceneObjects[kvp.Value];
                }


                XmlNodeList cars = doc.GetElementsByTagName("Car");
                if (cars.Count > 0)
                {
                    XmlElement car = (XmlElement)cars[0];

                    mSceneSettings.CarName = car.GetAttribute("name");
                    mSceneSettings.CarX = float.Parse(car.GetAttribute("posX"), CultureInfo.InvariantCulture);
                    mSceneSettings.CarY = float.Parse(car.GetAttribute("posY"), CultureInfo.InvariantCulture);
                }

                XmlNodeList settings = doc.GetElementsByTagName("Settings");
                if (settings.Count > 0)
                {
                    XmlElement set = (XmlElement)settings[0];

                    mSceneSettings.FinishX = float.Parse(set.GetAttribute("finishX"), CultureInfo.InvariantCulture);
                    mSceneSettings.FinishY = float.Parse(set.GetAttribute("finishY"), CultureInfo.InvariantCulture);
                    mSceneSettings.FallLine = float.Parse(set.GetAttribute("fallLine"), CultureInfo.InvariantCulture);

                    if (set.HasAttribute("secretX"))
                    {
                        mSceneSettings.SecretX = float.Parse(set.GetAttribute("secretX"), CultureInfo.InvariantCulture);
                        mSceneSettings.SecretY = float.Parse(set.GetAttribute("secretY"), CultureInfo.InvariantCulture);
                    }
                }

            }
            updateSceneTree();
            redrawImage();
        }

        public string Between(string STR, string FirstString, string LastString)
        {
            int startPoint = STR.IndexOf(FirstString) + FirstString.Length;
            Console.WriteLine(startPoint);
            int endPoint = STR.IndexOf(LastString);
            Console.WriteLine(endPoint);
            String result = STR.Substring(startPoint, endPoint - startPoint);
            return(result);
        }

        private void decompAndOpenScene(string p)
        {
            goalInLevel = false;
            secretInLevel = false;
            stickyInLevel = false;
            balloonInLevel = false;
            itemstickInLevel = false;
            itemballoonInLevel = false;

            if (!System.IO.File.Exists(p))
            {
                MessageBox.Show("File does not exist: " + p, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (System.IO.Path.GetExtension(p) != ".scene")
                return;

            // load a new scene!
            newScene();

            XmlDocument doc = new XmlDocument();
            doc.Load(p);

            string fileContents = doc.OuterXml;
            Console.WriteLine(fileContents);

            XmlNodeList scene = doc.GetElementsByTagName("Scene");
            if (scene.Count > 0)
            {
                XmlElement sc = (XmlElement)scene[0];
                mSceneSettings.SceneName = sc.GetAttribute("name");

                XmlNodeList obj_root = doc.GetElementsByTagName("Objects");
                XmlNodeList bodies = doc.GetElementsByTagName("SoftBody");

                if (obj_root.Count == 0)
                    return;

                List<KeyValuePair<SceneObject, int>> triggerPairs = new List<KeyValuePair<SceneObject, int>>();
                List<KeyValuePair<SceneObject, int>> pathPairs = new List<KeyValuePair<SceneObject, int>>();


                /*if (b == null)
                {
                    // load this one new.
                    b = new GameBody(name, "default");
                    string bodyFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(p), name + ".softbody");
                    if (System.IO.File.Exists(bodyFile))
                        b.initFromXml(bodyFile);
                    else
                    {
                        openFileDialog1.Title = "Where is the soft body file for '" + name + "'?";
                        openFileDialog1.Filter = "Soft Body files|*.softbody|Xml files|*.xml";
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            b.initFromXml(openFileDialog1.FileName);
                        }
                        else
                        {
                            // error.
                            MessageBox.Show("creating placeholder body for: " + name);
                        }
                    }

                    mSceneBodies.Add(b);
                }*/

                XmlNodeList objects = obj_root[0].ChildNodes;
                for (int i = 0; i < objects.Count; i++)
                {
                    if (objects[i].NodeType != XmlNodeType.Element)
                        continue;

                    XmlElement obj = (XmlElement)objects[i];

                    if ((obj.Name != "Object") && (obj.Name != "Path"))
                        continue;

                    string name = obj.GetAttribute("name");

                    GameBody b = null;
                    for (int j = 0; j < mSceneBodies.Count; j++)
                        if (name == mSceneBodies[j].Name) { b = mSceneBodies[j]; }

                    if (b == null)
                    {
                        b = new GameBody(name, "default");
                        for (int j = 0; j < bodies.Count; j++)
                        {
                            if (bodies[j].Attributes["name"].Value == name)
                            {
                                b.initFromXmlText(bodies[j].OuterXml);
                                mSceneBodies.Add(b);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "goal")
                            continue;
                        else
                        {
                            goalInLevel = true;
                            break;
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "secret")
                            continue;
                        else
                        {
                            secretInLevel = true;
                            break;
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "sticky")
                            continue;
                        else
                        {
                            stickyInLevel = true;
                            break;
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "balloon")
                            continue;
                        else
                        {
                            balloonInLevel = true;
                            break;
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "itemstick")
                            continue;
                        else
                        {
                            itemstickInLevel = true;
                            break;
                        }
                    }

                    for (int j = 0; j < mSceneBodies.Count; j++)
                    {
                        if (mSceneBodies[j].Name != "itemballoon")
                            continue;
                        else
                        {
                            itemballoonInLevel = true;
                            break;
                        }
                    }

                    // game object.
                    SceneObject o = new SceneObject();
                    if (obj.Name == "Path")
                    {
                        o.isPath = true;
                        o.pathClosed = bool.Parse(obj.GetAttribute("closed"));
                    }

                    o.body = b;
                    o.pos.X = float.Parse(obj.GetAttribute("posX"), CultureInfo.InvariantCulture);
                    o.pos.Y = float.Parse(obj.GetAttribute("posY"), CultureInfo.InvariantCulture);
                    o.angle = float.Parse(obj.GetAttribute("angle"), CultureInfo.InvariantCulture);
                    o.scale.X = float.Parse(obj.GetAttribute("scaleX"), CultureInfo.InvariantCulture);
                    o.scale.Y = float.Parse(obj.GetAttribute("scaleY"), CultureInfo.InvariantCulture);

                    if (obj.HasAttribute("material"))
                        o.material = int.Parse(obj.GetAttribute("material"), CultureInfo.InvariantCulture);
                    else
                        o.material = 0;

                    if (obj.HasAttribute("color"))
                    {
                        o.hasCustomColor = true;
                        string[] bits = obj.GetAttribute("color").Split(' ');

                        // BYTE based
                        try
                        {
                            byte cr, cg, cb;
                            byte ca = 255;
                            cr = byte.Parse(bits[0], CultureInfo.InvariantCulture);
                            cg = byte.Parse(bits[1], CultureInfo.InvariantCulture);
                            cb = byte.Parse(bits[2], CultureInfo.InvariantCulture);
                            if (bits.Length > 3)
                                ca = byte.Parse(bits[3], CultureInfo.InvariantCulture);

                            o.customColor = new Microsoft.Xna.Framework.Graphics.Color(cr, cg, cb, ca);
                        }
                        catch (Exception e)
                        {
                        }


                        /* FLOAT based
                        try
                        {
                            float cr, cg, cb;
                            float ca = 1.0f;
                            cr = float.Parse(bits[0], NumberStyles.Any, CultureInfo.InvariantCulture);
                            cg = float.Parse(bits[1], NumberStyles.Any, CultureInfo.InvariantCulture);
                            cb = float.Parse(bits[2], NumberStyles.Any, CultureInfo.InvariantCulture);
                            if (bits.Length > 3)
                                ca = float.Parse(bits[3], NumberStyles.Any, CultureInfo.InvariantCulture);

                            o.customColor = new Microsoft.Xna.Framework.Graphics.Color(cr, cg, cb, ca);
                        }
                        catch (Exception e)
                        {
                        }
                        */

                    }

                    if (obj.HasAttribute("triggerTargets"))
                    {
                        string[] ids = obj.GetAttribute("triggerTargets").Split(' ');
                        foreach (string id in ids)
                        {
                            int target = int.Parse(id, CultureInfo.InvariantCulture);
                            triggerPairs.Add(new KeyValuePair<SceneObject, int>(o, target));
                        }

                        if (obj.HasAttribute("triggerIgnoreCam"))
                            o.triggerNoCam = true;
                    }

                    // motion!
                    if (obj.HasChildNodes)
                    {
                        XmlNodeList motions = obj.ChildNodes;
                        XmlElement motion = (XmlElement)motions[0];
                        if (motion.Name == "KinematicControls")
                        {
                            XmlElement motion_type = (XmlElement)motion.FirstChild;
                            while (motion_type != null)
                            {

                                if (motion_type.Name == "PlatformMotion")
                                {
                                    o.motionPlatformON = true;

                                    if (motion_type.HasAttribute("offsetX"))
                                        o.motionPlatformOffset.X = float.Parse(motion_type.GetAttribute("offsetX"), CultureInfo.InvariantCulture);

                                    if (motion_type.HasAttribute("offsetY"))
                                        o.motionPlatformOffset.Y = float.Parse(motion_type.GetAttribute("offsetY"), CultureInfo.InvariantCulture);

                                    if (motion_type.HasAttribute("path"))
                                        pathPairs.Add(new KeyValuePair<SceneObject, int>(o, int.Parse(motion_type.GetAttribute("path"), CultureInfo.InvariantCulture)));

                                    o.motionPlatformLoop = float.Parse(motion_type.GetAttribute("secondsPerLoop"), CultureInfo.InvariantCulture);

                                    if (motion_type.HasAttribute("pauseAtEnds"))
                                        o.motionPlatformPauseAtEnds = float.Parse(motion_type.GetAttribute("pauseAtEnds"), CultureInfo.InvariantCulture);

                                    if (motion_type.HasAttribute("triggerBehavior"))
                                        o.motionPlatformTriggerBehavior = (SceneObject.PlatformTriggerBehavior)int.Parse(motion_type.GetAttribute("triggerBehavior"), CultureInfo.InvariantCulture);

                                    if (motion_type.HasAttribute("startOffset"))
                                        o.motionPlatformStartOffset = float.Parse(motion_type.GetAttribute("startOffset"), CultureInfo.InvariantCulture);
                                }

                                if (motion_type.Name == "Motor")
                                {
                                    o.motionMotorON = true;
                                    if (motion_type.HasAttribute("radiansPerSecond"))
                                    {
                                        // legacy scene, only had 1 setting for speed.
                                        MotorMotionCommand cmd = new MotorMotionCommand();
                                        cmd.commandType = "Rotate";
                                        cmd.duration = 1.0f;
                                        cmd.angle = MathHelper.ToDegrees(float.Parse(motion_type.GetAttribute("radiansPerSecond"), CultureInfo.InvariantCulture));

                                        o.motionMotorTriggerBehavior = SceneObject.MotorTriggerBehavior.Stop;
                                        o.motionMotorCommands.Add(cmd);
                                    }
                                    else if (motion_type.HasChildNodes)
                                    {
                                        if (motion_type.HasAttribute("triggerBehavior"))
                                            o.motionMotorTriggerBehavior = (SceneObject.MotorTriggerBehavior)int.Parse(motion_type.GetAttribute("triggerBehavior"), CultureInfo.InvariantCulture);

                                        XmlNodeList motor_kids = motion_type.ChildNodes;
                                        foreach (XmlNode mcmd in motor_kids)
                                        {
                                            if (mcmd.Name == "MotorCommand")
                                            {
                                                XmlElement mcme = (XmlElement)mcmd;

                                                MotorMotionCommand cmd = new MotorMotionCommand();
                                                cmd.commandType = mcme.GetAttribute("type");
                                                cmd.duration = float.Parse(mcme.GetAttribute("duration"), CultureInfo.InvariantCulture);

                                                if (mcme.HasAttribute("angle"))
                                                    cmd.angle = MathHelper.ToDegrees(float.Parse(mcme.GetAttribute("angle"), CultureInfo.InvariantCulture));

                                                if (mcme.HasAttribute("amount"))
                                                    cmd.amount = float.Parse(mcme.GetAttribute("amount"), CultureInfo.InvariantCulture);

                                                o.motionMotorCommands.Add(cmd);
                                            }
                                        }
                                    }
                                }
                                motion_type = (XmlElement)motion_type.NextSibling;
                            }
                        }
                    }

                    if (obj.HasAttribute("noRope"))
                    {
                        hasRope = obj.GetAttribute("noRope");
                        if (hasRope == "True")
                            o.objNoRope = true;
                        else
                            o.objNoRope = false;
                    }
                    else
                    {
                        o.objNoRope = false;
                    }

                    mSceneObjects.Add(o);
                }

                // hook-up target pairs.
                foreach (KeyValuePair<SceneObject, int> kvp in triggerPairs)
                {
                    kvp.Key.isTrigger = true;
                    kvp.Key.triggerTargets.Add(mSceneObjects[kvp.Value]);
                }

                foreach (KeyValuePair<SceneObject, int> kvp in pathPairs)
                {
                    kvp.Key.motionPlatformFollowPath = mSceneObjects[kvp.Value];
                }


                XmlNodeList cars = doc.GetElementsByTagName("Car");
                if (cars.Count > 0)
                {
                    XmlElement car = (XmlElement)cars[0];

                    mSceneSettings.CarName = car.GetAttribute("name");
                    mSceneSettings.CarX = float.Parse(car.GetAttribute("posX"), CultureInfo.InvariantCulture);
                    mSceneSettings.CarY = float.Parse(car.GetAttribute("posY"), CultureInfo.InvariantCulture);
                }

                XmlNodeList settings = doc.GetElementsByTagName("Settings");
                if (settings.Count > 0)
                {
                    XmlElement set = (XmlElement)settings[0];

                    mSceneSettings.FinishX = float.Parse(set.GetAttribute("finishX"), CultureInfo.InvariantCulture);
                    mSceneSettings.FinishY = float.Parse(set.GetAttribute("finishY"), CultureInfo.InvariantCulture);
                    mSceneSettings.FallLine = float.Parse(set.GetAttribute("fallLine"), CultureInfo.InvariantCulture);

                    if (set.HasAttribute("secretX"))
                    {
                        mSceneSettings.SecretX = float.Parse(set.GetAttribute("secretX"), CultureInfo.InvariantCulture);
                        mSceneSettings.SecretY = float.Parse(set.GetAttribute("secretY"), CultureInfo.InvariantCulture);
                    }
                }

            }
            updateSceneTree();
            redrawImage();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mEditMode == EditMode.Scene)
            {
                if (sceneFile == null) { sceneFile = ""; }
                saveFileDialog1.FileName = sceneFile;
                saveFileDialog1.Filter = "Scene Files|*.scene|Xml Files|*.xml";
                saveFileDialog1.Title = "Save Scene...";
                
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // save the scene!
                    saveScene(saveFileDialog1.FileName);

                    toolStripMainStatus.Text = "Scene saved to: " + saveFileDialog1.FileName;
                    sceneFile = saveFileDialog1.FileName;
                }
            }
            else if (mEditMode == EditMode.Object)
            {
                saveFileDialog1.FileName = mSceneObjects[mSelectedObject].body.Name + ".softbody";
                saveFileDialog1.Filter = "Soft Body Files|*.softbody|Xml Files|*.xml";
                saveFileDialog1.Title = "Save Soft Body...";
                
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    GameBody body = mSceneObjects[mSelectedObject].body;
                    body.saveToXml(saveFileDialog1.FileName);

                    toolStripMainStatus.Text = "Soft Body saved to: " + saveFileDialog1.FileName;
                }
            }
        }

        private void saveAllstripMenuItem_Click(object sender, EventArgs e)
        {
            saveAll();                       
        }

        private void saveAndCompileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compileAndSave();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult newSceneDialogResult = MessageBox.Show("Do you want to save before exiting?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (newSceneDialogResult == DialogResult.Yes)
                {
                    saveFileDialog1.Title = "Save Scene...";
                    saveFileDialog1.Filter = "Scene files|*.scene|Xml files|*.xml";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        saveScene(saveFileDialog1.FileName);

                        for (int i = 0; i < mSceneBodies.Count; i++)
                        {
                            GameBody b = mSceneBodies[i];
                            string file = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(saveFileDialog1.FileName), b.Name + ".softbody");
                            b.saveToXml(file);

                            toolStripProgressBar1.Value = (int)((i + 1) / (mSceneBodies.Count + 1) * 100);
                            toolStripProgressBar1.Invalidate();
                        }

                        toolStripMainStatus.Text = "Scene and all soft bodies saved to directory: " + System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                if (newSceneDialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private bool saveAll()
        {
            saveFileDialog1.Title = "Save Scene...";
            saveFileDialog1.Filter = "Scene files|*.scene|Xml files|*.xml";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveScene(saveFileDialog1.FileName);

                for (int i = 0; i < mSceneBodies.Count; i++)
                {
                    GameBody b = mSceneBodies[i];
                    string file = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(saveFileDialog1.FileName), b.Name + ".softbody");
                    b.saveToXml(file);

                    toolStripProgressBar1.Value = (int)((i + 1) / (mSceneBodies.Count + 1) * 100);
                    toolStripProgressBar1.Invalidate();
                }

                toolStripMainStatus.Text = "Scene and all soft bodies saved to directory: " + System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                return true;
            }
            return false;
        }

        private bool compileAndSave()
        {
            saveFileDialog1.Title = "Compile and save scene...";
            saveFileDialog1.Filter = "Scene files|*.scene|Xml files|*.xml";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //saveScene(saveFileDialog1.FileName);
                compileAndSaveScene(saveFileDialog1.FileName);

                // Console.WriteLine(saveFileDialog1.FileName);
                // Console.WriteLine(System.IO.Path.GetDirectoryName(saveFileDialog1.FileName));
                // Console.WriteLine(System.IO.Path.GetDirectoryName(saveFileDialog1.FileName) + @"\");
                // Console.WriteLine(System.IO.Path.GetFileNameWithoutExtension(saveFileDialog1.FileName));

                for (int i = 0; i < mSceneBodies.Count; i++)
                {
                    /*
                    GameBody b = mSceneBodies[i];
                    // Console.WriteLine(System.IO.Path.GetDirectoryName(saveFileDialog1.FileName) + @"\" + System.IO.Path.GetFileNameWithoutExtension(saveFileDialog1.FileName) + "_softbodies" + @"\" + b.Name + ".softbody");
                    string file = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(saveFileDialog1.FileName), b.Name + ".softbody");
                    b.saveToXml(file);
                    */

                    toolStripProgressBar1.Value = (int)((i + 1) / (mSceneBodies.Count + 1) * 100);
                    toolStripProgressBar1.Invalidate();
                }

                toolStripMainStatus.Text = "Done!";
                return true;
            }
            return false;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult newSceneDialogResult = MessageBox.Show("Do you want to save before exiting?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (newSceneDialogResult == DialogResult.Yes)
            {
                saveFileDialog1.Title = "Save Scene...";
                saveFileDialog1.Filter = "Scene files|*.scene|Xml files|*.xml";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    saveScene(saveFileDialog1.FileName);

                    for (int i = 0; i < mSceneBodies.Count; i++)
                    {
                        GameBody b = mSceneBodies[i];
                        string file = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(saveFileDialog1.FileName), b.Name + ".softbody");
                        b.saveToXml(file);

                        toolStripProgressBar1.Value = (int)((i + 1) / (mSceneBodies.Count + 1) * 100);
                        toolStripProgressBar1.Invalidate();
                    }

                    toolStripMainStatus.Text = "Scene and all soft bodies saved to directory: " + System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);

                    Application.Exit();
                }
            }
            if (newSceneDialogResult == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void gridSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mGridSettings.ShowDialog();
        }

        private void toolStripShowGrid_Click(object sender, EventArgs e)
        {
            mShowGrid = toolStripShowGrid.Checked;
            redrawImage();
        }

        private void addNewCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mCreateCircle.ShowDialog() == DialogResult.OK)
            {
                // create new.
                GameBody body = new GameBody("Body" + mBodyCount.ToString(), "default");

                body.Points.Clear();

                for (float i = 0f; i < 360f; i += (360f / (float)mCreateCircle.VertCount))
                {
                    body.Points.Add(new GameBody.PointMass(new Vector2(
                        (float)Math.Sin(MathHelper.ToRadians(i)), (float)Math.Cos(MathHelper.ToRadians(i)))));
                }

                SceneObject obj = new SceneObject();
                obj.body = body;

                mSceneBodies.Add(body);
                mSceneObjects.Add(obj);

                selectObject(mSceneObjects.Count - 1);

                mBodyCount++;

                updateObjectTransformation();
                updateSceneTree();
                redrawImage();

            }
        }

        private void sceneSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mSceneSettings.ShowDialog() == DialogResult.OK)
                redrawImage();
        }

        private void objectMotionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mSelectedObject != -1)
            {
                // init values here.
                mMotionSettings.PlatformON = mSceneObjects[mSelectedObject].motionPlatformON;
                if (mMotionSettings.PlatformON)
                {
                    mMotionSettings.PlatformOffsetX = mSceneObjects[mSelectedObject].motionPlatformOffset.X;
                    mMotionSettings.PlatformOffsetY = mSceneObjects[mSelectedObject].motionPlatformOffset.Y;
                    mMotionSettings.PlatformLoopLength = mSceneObjects[mSelectedObject].motionPlatformLoop;
                    mMotionSettings.PlatformStartOffset = mSceneObjects[mSelectedObject].motionPlatformStartOffset;
                    mMotionSettings.PlatformPauseAtEnds = mSceneObjects[mSelectedObject].motionPlatformPauseAtEnds;
                    mMotionSettings.PlatformTriggerBehavior = (int)mSceneObjects[mSelectedObject].motionPlatformTriggerBehavior;
                }

                mMotionSettings.MotorON = mSceneObjects[mSelectedObject].motionMotorON;
                mMotionSettings.dataGridViewMotorCommands.DataSource = mSceneObjects[mSelectedObject].motionMotorCommands;
                if (mMotionSettings.MotorON)
                {
                    mMotionSettings.MotorTriggerBehavior = (int)mSceneObjects[mSelectedObject].motionMotorTriggerBehavior;
                }

                mMotionSettings.noRope = mSceneObjects[mSelectedObject].objNoRope;

                if (mMotionSettings.ShowDialog() == DialogResult.OK)
                {
                    // apply new settings here.
                    mSceneObjects[mSelectedObject].motionPlatformON = mMotionSettings.PlatformON;
                    if (mMotionSettings.PlatformON)
                    {
                        mSceneObjects[mSelectedObject].motionPlatformOffset = new Vector2(mMotionSettings.PlatformOffsetX, mMotionSettings.PlatformOffsetY);
                        mSceneObjects[mSelectedObject].motionPlatformLoop = mMotionSettings.PlatformLoopLength;
                        mSceneObjects[mSelectedObject].motionPlatformStartOffset = mMotionSettings.PlatformStartOffset;
                        mSceneObjects[mSelectedObject].motionPlatformPauseAtEnds = mMotionSettings.PlatformPauseAtEnds;
                        mSceneObjects[mSelectedObject].motionPlatformTriggerBehavior = (SceneObject.PlatformTriggerBehavior)mMotionSettings.PlatformTriggerBehavior;
                    }

                    mSceneObjects[mSelectedObject].motionMotorON = mMotionSettings.MotorON;
                    if (mMotionSettings.MotorON)
                    {
                        mSceneObjects[mSelectedObject].motionMotorTriggerBehavior = (SceneObject.MotorTriggerBehavior)mMotionSettings.MotorTriggerBehavior;
                    }

                    mSceneObjects[mSelectedObject].objNoRope = mMotionSettings.noRope;

                    redrawImage();
                }
            }
            else
            {
                MessageBox.Show(this, "No object selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void publishToJelloCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Publish to JellyCar?  Any objects in this scene that have the same name as objects already in the directory will be overwritten.  OK?",
                "Publish To JellyCar", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                if (saveAll())
                {
                    // now update the scene list XML file, if it exists.
                    string sceneFile = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                    string file = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(saveFileDialog1.FileName), "scene_list.xml");
                    if (System.IO.File.Exists(file))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(file);

                        XmlElement root = doc.DocumentElement;
                        bool found = false;
                        if (root.Name == "Scenes")
                        {
                            XmlNode scene = root.FirstChild;
                            while (scene != null)
                            {
                                if (scene.GetType().Name == "XmlElement")
                                {
                                    XmlElement sceneElem = (XmlElement)scene;

                                    if (sceneElem.GetAttribute("file") == sceneFile)
                                    {
                                        found = true;
                                        sceneElem.SetAttribute("name", mSceneSettings.SceneName);
                                        break;
                                    }
                                }
                                scene = scene.NextSibling;
                            }

                            if (!found)
                            {
                                XmlElement ne = doc.CreateElement("Scene");
                                ne.SetAttribute("name", mSceneSettings.SceneName);
                                ne.SetAttribute("file", sceneFile);
                                ne.SetAttribute("thumb", "wip");
                                root.AppendChild(ne);
                            }
                        }

                        // save the file back out!
                        doc.Save(file);
                    }
                }
            }
        }

        private void autocenterObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult autocenter_conf = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (autocenter_conf == DialogResult.Yes)
            {
                if (mSelectedObject != -1)
                {
                    Vector2 offset = Vector2.Zero;
                    for (int i = 0; i < mSceneObjects[mSelectedObject].body.Points.Count; i++)
                    {
                        offset += mSceneObjects[mSelectedObject].body.Points[i].pos;
                    }

                    offset /= mSceneObjects[mSelectedObject].body.Points.Count;

                    // now move all!
                    for (int i = 0; i < mSceneObjects[mSelectedObject].body.Points.Count; i++)
                    {
                        mSceneObjects[mSelectedObject].body.Points[i].pos -= offset;
                    }

                    redrawImage();

                }
                else
                {
                    MessageBox.Show("No Object selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region mouse functions
        private void mouseClicked(object sender, MouseEventArgs m)
        {
            if (m.Button == MouseButtons.Left)
            {
                if (mEditMode == EditMode.Object)
                {
                    if (mObjectEditMode == ObjectEditMode.Points)
                    {
                        if (ModifierKeys == Keys.Shift)
                        {
                            Vector2 mouseGlobal = new Vector2(m.X - mGridCenterX, mGridCenterY - m.Y);
                            mouseGlobal /= mGridZoom;

                            // snap?!?
                            if (snapToolStripMenuItem.Checked)
                            {
                                int snapX = (int)((mouseGlobal.X / (mGridMajorSub / mGridMinorSub) + ((mouseGlobal.X > 0f) ? 0.5f : -0.5f)));
                                int snapY = (int)((mouseGlobal.Y / (mGridMajorSub / mGridMinorSub) + ((mouseGlobal.Y > 0f) ? 0.5f : -0.5f)));

                                mouseGlobal.X = (mGridMajorSub / mGridMinorSub) * snapX;
                                mouseGlobal.Y = (mGridMajorSub / mGridMinorSub) * snapY;
                            }

                            Vector2 local = globalToLocal(mSceneObjects[mSelectedObject], mouseGlobal, false);

                            if (mSelectedPoint != -1)
                            {
                                mSceneObjects[mSelectedObject].body.Points.Insert(mSelectedPoint + 1, new GameBody.PointMass(local));
                                updateSpringsPointAdded(mSelectedPoint + 1);
                                updatePolygonsPointAdded(mSelectedPoint + 1);
                                mSelectedPoint = mSelectedPoint + 1;
                            }
                            else
                            {
                                mSceneObjects[mSelectedObject].body.Points.Add(new GameBody.PointMass(local));
                                mSelectedPoint = mSceneObjects[mSelectedObject].body.Points.Count - 1;
                            }
                            redrawImage();
                        }
                        else if (ModifierKeys == Keys.Alt)
                        {
                            float dist = 0f;
                            int point = getClosestPointToMouse(m.X, m.Y, ref dist);
                            if (dist < 15.0f)
                            {
                                mSceneObjects[mSelectedObject].body.Points.RemoveAt(point);
                                if (mSelectedPoint == point) { mSelectedPoint = -1; }

                                updateSpringsPointRemoved(point);
                                updatePolygonsPointRemoved(point);
                                redrawImage();

                                toolStripMainStatus.Text = "Removed point " + point.ToString() + ".";
                            }
                        }
                        else if (((ModifierKeys & Keys.Alt) == 0) && ((ModifierKeys & Keys.Shift) == 0))
                        {
                            // just select a point
                            float dist = 0f;
                            mSelectedPoint = getClosestPointToMouse(m.X, m.Y, ref dist);
                            if (dist > 15f)
                            {
                                mSelectedPoint = -1;
                            }

                            if (mSelectedPoint != -1)
                            {
                                toolStripMainStatus.Text = "Point " + mSelectedPoint.ToString() + " selected.  CTRL+DRAG to move.  ALT+CLICK any point to remove.";
                                //enable the point special mass button
                                pointToolStripMenuItem.Visible = true;
                            } else
                            {
                                toolStripMainStatus.Text = "";
                                pointToolStripMenuItem.Visible = false;
                            }

                            redrawImage();
                        }
                    }
                    else if (mObjectEditMode == ObjectEditMode.Springs)
                    {
                        if (((ModifierKeys & Keys.Alt) == 0) && ((ModifierKeys & Keys.Shift) == 0))
                        {
                            float dist = 0f;
                            int spring = getClosestSpringToMouse(m.X, m.Y, ref dist);
                            if (dist < 15f)
                            {
                                mSelectedSpring = spring;
                                updateSpringDetails();
                                toolStripMainStatus.Text = "Spring " + spring.ToString() + " selected.  Adjust settings on right, ALT+CLICK any spring to remove.";
                            }
                            else
                            {
                                mSelectedSpring = -1;
                            }
                            redrawImage();
                        }
                        else if (ModifierKeys == Keys.Alt)
                        {
                            float dist = 0f;
                            int spring = getClosestSpringToMouse(m.X, m.Y, ref dist);
                            if (dist < 15f)
                            {
                                mSceneObjects[mSelectedObject].body.Springs.RemoveAt(spring);
                                if (mSelectedSpring == spring) { mSelectedSpring = -1; }
                                toolStripMainStatus.Text = "Spring " + spring.ToString() + " removed.";
                                redrawImage();
                            }
                        }
                    }
                    else if (mObjectEditMode == ObjectEditMode.Polygons)
                    {
                        if (ModifierKeys == Keys.Shift)
                        {
                            // start a new polygon.
                            for (int i = 0; i < 3; i++)
                                mPolyInProgress[i] = -1;

                            float dist = 0f;
                            int point = getClosestPointToMouse(m.X, m.Y, ref dist);
                            if (dist < 15f)
                            {
                                // start creating a polygon.
                                mAddingPoly = true;

                                mPolyInProgress[0] = point;

                                toolStripMainStatus.Text = "Starting Polygon with point " + point.ToString();
                            }
                        }
                        else if (ModifierKeys == Keys.Alt)
                        {
                            // polygon removal.
                            Vector2 mouseScreen = new Vector2(m.X, m.Y);

                            GameBody body = mSceneObjects[mSelectedObject].body;

                            GameBody.Polygon polyToKill = null;

                            for (int i = 0; i < body.Polygons.Count; i++)
                            {   
                                GameBody.Polygon poly = body.Polygons[i];

                                bool found = true;
                                for (int j = 0; j < 3; j++)
                                {
                                    int a = 0;
                                    int b = 1;
                                    int c = 2;

                                    if (j == 1)
                                    {
                                        a = 1;
                                        b = 2;
                                        c = 0;
                                    }
                                    else if (j == 2)
                                    {
                                        a = 2;
                                        b = 0;
                                        c = 1;
                                    }

                                    Vector2 pt1 = BodyPointToScreen(mSceneObjects[mSelectedObject], poly.PointMasses[a]);
                                    Vector2 pt2 = BodyPointToScreen(mSceneObjects[mSelectedObject], poly.PointMasses[b]);
                                    Vector2 op = BodyPointToScreen(mSceneObjects[mSelectedObject], poly.PointMasses[c]);

                                    bool ccw1 = JellyPhysics.VectorTools.isCCW(mouseScreen - pt1, pt2 - mouseScreen);
                                    bool ccw2 = JellyPhysics.VectorTools.isCCW(op - pt1, pt2 - op);

                                    if (ccw1 != ccw2)
                                    {
                                        // now inside!
                                        found = false;
                                        break;
                                    }
                                }

                                if (found)
                                {
                                    polyToKill = poly;
                                    break;
                                }
                            }

                            if (polyToKill != null)
                            {
                                body.Polygons.Remove(polyToKill);
                                redrawImage();
                            }
                        }
                        else if (((ModifierKeys & Keys.Alt) == 0) && ((ModifierKeys & Keys.Shift) == 0))
                        {
                            if (mAddingPoly)
                            {
                                float dist = 0f;
                                int point = getClosestPointToMouse(m.X, m.Y, ref dist);
                                if (dist < 15f)
                                {
                                    if (mPolyInProgress[1] == -1)
                                    {
                                        if (mPolyInProgress[0] != point)
                                        {
                                            mPolyInProgress[1] = point;

                                            toolStripMainStatus.Text = "Added point " + point.ToString() + " to Polygon.  Click on final point now...";
                                        }
                                    }
                                    else
                                    {
                                        // final point.
                                        if ((mPolyInProgress[0] != point) && (mPolyInProgress[1] != point))
                                        {
                                            mPolyInProgress[2] = point;

                                            GameBody.Polygon p = new GameBody.Polygon();
                                            mPolyInProgress.CopyTo(p.PointMasses, 0);

                                            mSceneObjects[mSelectedObject].body.Polygons.Add(p);

                                            mAddingPoly = false;

                                            redrawImage();

                                            toolStripMainStatus.Text = "Polygon added!";
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                else if (mEditMode == EditMode.Scene)
                {
                    float closestD = 10000.0f;
                    int closestB = -1;

                    for (int i = 0; i < mSceneObjects.Count; i++)
                    {
                        float dist = 0f;
                        for (int j = 0; j < mSceneObjects[i].body.Points.Count; j++)
                        {
                            int p1 = j;
                            int p2 = (j < (mSceneObjects[i].body.Points.Count - 1)) ? j + 1 : 0;

                            Vector2 screen1 = BodyPointToScreen(mSceneObjects[i], p1);
                            Vector2 screen2 = BodyPointToScreen(mSceneObjects[i], p2);

                            Vector2 mouseScreen = new Vector2(m.X, m.Y);

                            dist = distToLine(mouseScreen, screen1, screen2);
                            if (dist < closestD)
                            {
                                closestD = dist;
                                closestB = i;
                            }
                        }
                    }

                    if (closestD < 20.0f)
                    {
                        if (mChoosingTarget)
                        {
                            SceneObject target = mSceneObjects[closestB];
                            if (mSceneObjects[mSelectedObject].triggerTargets.Contains(target))
                            {
                                mSceneObjects[mSelectedObject].triggerTargets.Remove(target);
                                toolStripMainStatus.Text = "Removed target " + mSceneObjects[closestB].body.Name;
                            }
                            else
                            {
                                mSceneObjects[mSelectedObject].triggerTargets.Add(target);
                                toolStripMainStatus.Text = "Set target to " + mSceneObjects[closestB].body.Name;
                            }
                            mChoosingTarget = false;
                            redrawImage();
                        }
                        else if (mChoosingPathPlatform)
                        {
                            SceneObject target = mSceneObjects[closestB];
                            target.motionPlatformFollowPath = mSceneObjects[mSelectedObject];
                            mChoosingPathPlatform = false;
                            
                            toolStripMainStatus.Text = "Set platform to follow path.";

                            target.pos = BodyPointToGlobal(mSceneObjects[mSelectedObject], 0);
                            redrawImage();
                        }
                        else
                        {
                            selectObject(closestB);
                        }
                    }
                    else
                    {
                        if (mChoosingTarget)
                        {
                            mChoosingTarget = false;
                            toolStripMainStatus.Text = "No target set.";
                            redrawImage();
                        }
                        else
                        {
                            selectObject(-1);
                        }
                    }
                }
            }
        }

        void mouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
        } 

        private void mouseDown(object sender, MouseEventArgs m)
        {
            mGridDragX = m.X;
            mGridDragY = m.Y;

            if (mEditMode == EditMode.Object)
            {
                if (mObjectEditMode == ObjectEditMode.Springs)
                {
                    if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                    {
                        float dist = 0f;
                        int point = getClosestPointToMouse(m.X, m.Y, ref dist);
                        if (dist < 15f)
                        {
                            mDraggingSpring = true;
                            mDragSpringStartPoint = point;

                            toolStripMainStatus.Text = "Adding Spring... DRAG to second point.";
                        }
                    }
                }
            }
        }

        private void mouseUp(object sender, MouseEventArgs m)
        {
            if (mEditMode == EditMode.Object)
            {
                if (mObjectEditMode == ObjectEditMode.Springs)
                {
                    if (mDraggingSpring)
                    {
                        float dist = 0f;
                        int point = getClosestPointToMouse(m.X, m.Y, ref dist);
                        if ((dist < 15f) && (mDragSpringStartPoint != point))
                        {
                            // add a spring!
                            GameBody.InternalSpring s = new GameBody.InternalSpring();
                            s.PointMassA = mDragSpringStartPoint;
                            s.PointMassB = point;
                            s.SpringK = float.Parse(textObjectSpringK.Text, CultureInfo.InvariantCulture);
                            s.SpringDamping = float.Parse(textObjectSpringDamping.Text, CultureInfo.InvariantCulture);
                            mSceneObjects[mSelectedObject].body.Springs.Add(s);

                            mDraggingSpring = false;
                            mDragSpringStartPoint = -1;

                            toolStripMainStatus.Text = "Spring Added from point "+s.PointMassA.ToString()+" to "+s.PointMassB.ToString()+".";
                            redrawImage();
                        }
                    }
                }
                else if (mObjectEditMode == ObjectEditMode.Points)
                {
                    if (ModifierKeys == Keys.Control)
                    {
                        if ((mSelectedPoint != -1) && (snapToolStripMenuItem.Checked))
                        {
                            SceneObject obj = mSceneObjects[mSelectedObject];

                            Vector2 global = obj.pos + JellyPhysics.VectorTools.rotateVector(obj.body.Points[mSelectedPoint].pos * obj.scale, obj.angle);

                            int snapX = (int)((global.X / (mGridMajorSub / mGridMinorSub) + ((global.X > 0f) ? 0.5f : -0.5f)));
                            int snapY = (int)((global.Y / (mGridMajorSub / mGridMinorSub) + ((global.Y > 0f) ? 0.5f : -0.5f)));

                            global.X = (mGridMajorSub / mGridMinorSub) * snapX;
                            global.Y = (mGridMajorSub / mGridMinorSub) * snapY;

                            obj.body.Points[mSelectedPoint].pos = globalToLocal(obj, global, false);

                            redrawImage();

                        }
                    }
                }
            }
        }

        private void mouseMoved(object sender, MouseEventArgs m)
        {
            mMouseScreen = new Vector2(m.X,m.Y);

            if (ModifierKeys == 0)
            {
                if ((m.Button == MouseButtons.Middle)  || (m.Button == MouseButtons.Left))
                {
                    mGridCenterX += m.X - mGridDragX;
                    mGridCenterY += m.Y - mGridDragY;

                    redrawImage();
                }
                else if (m.Button == MouseButtons.Right)
                {
                    Vector2 centerGlobal = new Vector2((pictureBox1.Width/2) - mGridCenterX, mGridCenterY - (pictureBox1.Height/2));
                    centerGlobal /= mGridZoom;

                    mGridZoom += m.X - mGridDragX;

                    if (mGridZoom < 1.0f) { mGridZoom = 1.0f; }
                    if (mGridZoom > 5000.0f) { mGridZoom = 5000.0f; }

                    // now re-center.
                    centerGlobal.Y = -centerGlobal.Y;
                    Vector2 gridCenter = new Vector2(mGridCenterX, mGridCenterY);
                    Vector2 screen = gridCenter + (centerGlobal * mGridZoom);

                    mGridCenterX += ((float)(pictureBox1.Width / 2f) - screen.X);
                    mGridCenterY += ((float)(pictureBox1.Height / 2f) - screen.Y);


                    redrawImage();
                }
            }
            else if (ModifierKeys == Keys.Shift)
            {
                if ((m.Button == MouseButtons.Left) && (mEditMode == EditMode.Scene))
                {
                    // shift is pressed.  if these is a selected object, move it.
                    if (mSelectedObject != -1)
                    {
                        SceneObject obj = mSceneObjects[mSelectedObject];
                        obj.pos.X += (m.X - mGridDragX) / mGridZoom;
                        obj.pos.Y -= (m.Y - mGridDragY) / mGridZoom;

                        redrawImage();
                        updateObjectTransformation();
                    }
                }
            }
            else if (ModifierKeys == Keys.Control)
            {
                if ((m.Button == MouseButtons.Left) && (mEditMode == EditMode.Scene))
                {
                    if (mSelectedObject != -1)
                    {
                        SceneObject obj = mSceneObjects[mSelectedObject];
                        obj.angle += (m.X - mGridDragX);

                        if (obj.angle > 360f) { obj.angle -= 360.0f; }
                        if (obj.angle < 0) { obj.angle += 360.0f; }
                        redrawImage();
                        updateObjectTransformation();
                    }
                }
                else if ((m.Button == MouseButtons.Left) && (mEditMode == EditMode.Object))
                {
                    if ((mObjectEditMode == ObjectEditMode.Points) && (mSelectedPoint != -1))
                    {
                        SceneObject obj = mSceneObjects[mSelectedObject];
                        Vector2 globalMove = new Vector2();
                        globalMove.X = (m.X - mGridDragX) / mGridZoom;
                        globalMove.Y = -((m.Y - mGridDragY) / mGridZoom);

                        Vector2 localMove = globalToLocal(obj, globalMove, true);

                        obj.body.Points[mSelectedPoint].pos += localMove;

                        redrawImage();
                    }
                }
            }
            else if ((ModifierKeys == Keys.Alt))
            {
                if ((m.Button == MouseButtons.Left) && (mEditMode == EditMode.Scene))
                {
                    if (mSelectedObject != -1)
                    {
                        SceneObject obj = mSceneObjects[mSelectedObject];
                        obj.scale.X += (m.X - mGridDragX) / mGridZoom;
                        obj.scale.Y -= (m.Y - mGridDragY) / mGridZoom;

                        if (obj.scale.X < 0.1f) { obj.scale.X = 0.1f; }
                        if (obj.scale.Y < 0.1f) { obj.scale.Y = 0.1f; }

                        redrawImage();
                        updateObjectTransformation();
                    }
                }
            }
            else if (ModifierKeys == (Keys.Shift | Keys.Alt))
            {
                if ((m.Button == MouseButtons.Left) && (mEditMode == EditMode.Object))
                {
                    // move all points!
                    SceneObject obj = mSceneObjects[mSelectedObject];
                    Vector2 globalMove = new Vector2();
                    globalMove.X = (m.X - mGridDragX) / mGridZoom;
                    globalMove.Y = -((m.Y - mGridDragY) / mGridZoom);

                    Vector2 localMove = globalToLocal(obj, globalMove, true);

                    foreach(GameBody.PointMass pm in obj.body.Points)
                        pm.pos += localMove;

                    redrawImage();
                }
            }

            mGridDragX = m.X;
            mGridDragY = m.Y;

            if (mDraggingSpring) { redrawImage(); }
        }

        int getClosestPointToMouse(int mx, int my, ref float dist)
        {
            Vector2 mouseScreen = new Vector2(mx,my);

            int closest = -1;
            float closestSQD = 100000.0f;
            for (int i = 0; i < mSceneObjects[mSelectedObject].body.Points.Count; i++)
            {
                Vector2 screen = BodyPointToScreen(mSceneObjects[mSelectedObject], i);

                float d = (screen - mouseScreen).LengthSquared();
                if (d < closestSQD)
                {
                    closestSQD = d;
                    closest = i;
                }
            }

            dist = (float)Math.Sqrt(closestSQD);
            return closest;
        }

        int getClosestSpringToMouse(int mx, int my, ref float dist)
        {
            Vector2 mouseScreen = new Vector2(mx, my);

            int closest = -1;
            float closestD = 100000.0f;
            for (int i = 0; i < mSceneObjects[mSelectedObject].body.Springs.Count; i++)
            {
                GameBody body = mSceneObjects[mSelectedObject].body;

                Vector2 line1 = BodyPointToScreen(mSceneObjects[mSelectedObject], body.Springs[i].PointMassA);
                Vector2 line2 = BodyPointToScreen(mSceneObjects[mSelectedObject], body.Springs[i].PointMassB);

                float d = distToLine(mouseScreen, line1, line2);
                if (d < closestD)
                {
                    closestD = d;
                    closest = i;
                }
            }

            dist = closestD;
            return closest;
        }
        #endregion

        #region Vector Helpers
        Vector2 globalToLocal(SceneObject obj, Vector2 v, bool rotateOnly)
        {
           return JellyPhysics.VectorTools.rotateVector((v-((rotateOnly) ? Vector2.Zero : obj.pos))/obj.scale, -(float)(MathHelper.ToRadians(obj.angle)));
        }

        float distToLine(Vector2 pt, Vector2 linePtA, Vector2 linePtB)
        {
            Vector2 lineSeg = (linePtB - linePtA);
            float lineDist = lineSeg.Length();

            lineSeg /= lineDist;

            Vector2 toPt = (pt - linePtA);

            float dot = Vector2.Dot(toPt, lineSeg);

            if (dot <= 0f)
            {
                // closest point is ptA on the line.
                return (pt - linePtA).Length();
            }
            else if (dot >= lineDist)
            {
                // closest point is ptB on the line.
                return (pt - linePtB).Length();
            }
            else
            {
                // somewhere on the line.
                Vector2 onLine = linePtA + (lineSeg * dot);
                return (pt - onLine).Length();
            }
        }
        //#endregion

        #region mode switching
        public void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    // switched to SCENE EDIT mode.
                    toolStripMainStatus.Text = "Scene edit mode.";
                    mEditMode = EditMode.Scene;
                    snapToolStripMenuItem.Visible = false;
                    pointToolStripMenuItem.Visible = false;
                    updateSceneTree();
                    redrawImage();
                    mSelectedPoint = -1;
                    mSelectedSpring = -1;
                    break;

                case 1:
                    // switched to OBJECT EDIT mode.
                    if (mSelectedObject != -1)
                    {
                        toolStripMainStatus.Text = "Object edit mode.";
                        mEditMode = EditMode.Object;
                        snapToolStripMenuItem.Visible = true;
                        updateObjectDetails();
                        redrawImage();
                    }
                    else
                    {
                        MessageBox.Show("No Object selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedIndex = 0;
                    }
                    break;
            }
        }
        #endregion

        #region public properties
        public int GridSizeX { get { return mGridSizeX; } }
        public int GridSizeY { get { return mGridSizeY; } }
        public float GridMajorSubdivision { get { return mGridMajorSub; } }
        public int GridMinorSubdivision { get { return mGridMinorSub; } }
        #endregion

        #region adding / removing / cloning bodies - SCENE MODE
        private void butSceneNewObject_Click(object sender, EventArgs e)
        {
            GameBody body = new GameBody("Body"+mBodyCount.ToString(), "default");

            SceneObject obj = new SceneObject();
            obj.body = body;

            mSceneBodies.Add(body);
            mSceneObjects.Add(obj);

            selectObject( mSceneObjects.Count-1 );
            mBodyCount++;

            updateObjectTransformation();
            updateSceneTree();
            redrawImage();
        }

        private void butSceneAddObject_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Soft Body File...";
            openFileDialog1.Filter = "Soft Body files|*.softbody|Xml files|*.xml";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(openFileDialog1.FileName);
                XmlNodeList bod = doc.GetElementsByTagName("SoftBody");
                if (bod.Count > 0)
                {
                    string name = ((XmlElement)bod[0]).GetAttribute("name");
                    GameBody b = null;

                    for (int i = 0; i < mSceneBodies.Count; i++)
                        if (mSceneBodies[i].Name == name) { b = mSceneBodies[i]; }


                    if (b != null)
                    {
                        if (MessageBox.Show("A Body with this name already exists in the scene!  Overwrite?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                            return;
                    }
                    else
                    {
                        b = new GameBody(name, "default");
                    }

                    b.initFromXml(openFileDialog1.FileName);
                    mSceneBodies.Add(b);

                    SceneObject obj = new SceneObject();
                    obj.body = b;

                    mSceneObjects.Add(obj);

                    updateObjectTransformation();
                    updateSceneTree();
                    redrawImage();
                }
            }
        }

        private void butSceneCloneObject_Click(object sender, EventArgs e)
        {
            if (mSelectedObject == -1)
            {
                MessageBox.Show("No Object selected to clone!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GameBody b = mSceneObjects[mSelectedObject].body;

            SceneObject obj = new SceneObject();
            obj.body = b;

            mSceneObjects.Add(obj);

            obj.pos = mSceneObjects[mSelectedObject].pos;
            obj.scale = mSceneObjects[mSelectedObject].scale;
            obj.angle = mSceneObjects[mSelectedObject].angle;
            obj.material = mSceneObjects[mSelectedObject].material;
            obj.motionMotorON = mSceneObjects[mSelectedObject].motionMotorON;
            obj.motionMotorTriggerBehavior = mSceneObjects[mSelectedObject].motionMotorTriggerBehavior;
            obj.motionMotorCommands.Clear();
            
            for (int mc = 0; mc < mSceneObjects[mSelectedObject].motionMotorCommands.Count; mc++)
            {
                MotorMotionCommand cmd = new MotorMotionCommand();
                cmd.commandType = mSceneObjects[mSelectedObject].motionMotorCommands[mc].commandType;
                cmd.duration = mSceneObjects[mSelectedObject].motionMotorCommands[mc].duration;
                cmd.angle = mSceneObjects[mSelectedObject].motionMotorCommands[mc].angle;
                cmd.amount = mSceneObjects[mSelectedObject].motionMotorCommands[mc].amount;

                obj.motionMotorCommands.Add(cmd);
            }

            obj.motionPlatformLoop = mSceneObjects[mSelectedObject].motionPlatformLoop;
            obj.motionPlatformOffset = mSceneObjects[mSelectedObject].motionPlatformOffset;
            obj.motionPlatformON = mSceneObjects[mSelectedObject].motionPlatformON;
            obj.motionPlatformStartOffset = mSceneObjects[mSelectedObject].motionPlatformStartOffset;
            obj.motionPlatformPauseAtEnds = mSceneObjects[mSelectedObject].motionPlatformPauseAtEnds;
            obj.motionPlatformTriggerBehavior = mSceneObjects[mSelectedObject].motionPlatformTriggerBehavior;
            obj.isTrigger = mSceneObjects[mSelectedObject].isTrigger;
            if (mSceneObjects[mSelectedObject].triggerTargets.Count > 0)
            {
                foreach (SceneObject s in mSceneObjects[mSelectedObject].triggerTargets)
                {
                    // only add when an object is a self target, ignore others.
                    if (s == mSceneObjects[mSelectedObject])
                        obj.triggerTargets.Add(s);
                }
            }
            obj.hasCustomColor = mSceneObjects[mSelectedObject].hasCustomColor;
            obj.customColor = mSceneObjects[mSelectedObject].customColor;
            obj.objNoRope = mSceneObjects[mSelectedObject].objNoRope;

            // now select new object.
           selectObject( mSceneObjects.Count - 1 );

            updateObjectTransformation();
            updateSceneTree();
            redrawImage();
        }

        private void butSceneRemoveObject_Click(object sender, EventArgs e)
        {
            if (mSelectedObject != -1)
            {
                SceneObject me = mSceneObjects[mSelectedObject];

                // make sure no other objects reference this one...
                foreach (SceneObject so in mSceneObjects)
                {
                    if (so.triggerTargets.Contains(me))
                        so.triggerTargets.Remove(me);

                    if (so.motionPlatformFollowPath == me)
                        so.motionPlatformFollowPath = null;
                }

                GameBody b = me.body;

                mSceneObjects.Remove(me);

                int count = 0;
                for (int i = 0; i < mSceneObjects.Count; i++)
                    if (mSceneObjects[i].body == b) { count++; }

                if (count == 0)
                {
                    // no more references to this game body, it can be removed from the list.
                    mSceneBodies.Remove(b);
                    if (b.Name == "goal")
                    {
                        goalInLevel = false;
                    }

                    if (b.Name == "secret")
                    {
                        secretInLevel = false;
                    }

                    if (b.Name == "sticky")
                    {
                        stickyInLevel = false;
                    }

                    if (b.Name == "balloon")
                    {
                        balloonInLevel = false;
                    }

                    if (b.Name == "itemstick")
                    {
                        itemstickInLevel = false;
                    }

                    if (b.Name == "itemballoon")
                    {
                        itemballoonInLevel = false;
                    }
                }

                toolStripMainStatus.Text = "Object removed.";

                selectObject(-1);
            }
        }

        private void removeObject(SceneObject me)
        {
            //if (mSelectedObject != -1)
            //{

                // make sure no other objects reference this one...
                foreach (SceneObject so in mSceneObjects)
                {
                    if (so.triggerTargets.Contains(me))
                        so.triggerTargets.Remove(me);

                    if (so.motionPlatformFollowPath == me)
                        so.motionPlatformFollowPath = null;
                }

                GameBody b = me.body;

                mSceneObjects.Remove(me);

                int count = 0;
                for (int i = 0; i < mSceneObjects.Count; i++)
                    if (mSceneObjects[i].body == b) { count++; }

                if (count == 0)
                {
                    // no more references to this game body, it can be removed from ths list.
                    mSceneBodies.Remove(b);
                    if (b.Name == "goal")
                    {
                        goalInLevel = false;
                    }

                    if (b.Name == "secret")
                    {
                        secretInLevel = false;
                    }

                    if (b.Name == "sticky")
                    {
                        stickyInLevel = false;
                    }

                    if (b.Name == "balloon")
                    {
                        balloonInLevel = false;
                    }

                    if (b.Name == "itemstick")
                    {
                        itemstickInLevel = false;
                    }

                    if (b.Name == "itemballoon")
                    {
                        itemballoonInLevel = false;
                    }
                }

                toolStripMainStatus.Text = "Object removed.";

                selectObject(-1);
            //}
        }

        void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            selectObject( (int)e.Node.Tag, false );

            if (mSelectedObject != -1)
                toolStripMainStatus.Text = "Object Selected: " + mSceneObjects[mSelectedObject].body.Name + " [" + mSelectedObject.ToString() + "]"+
                    "  SHIFT+DRAG to move, CTRL+DRAG to rotate, ALT+DRAG to scale";
            else
                toolStripMainStatus.Text = "No Object Selected.";

            redrawImage();
            updateObjectTransformation();
        }

        private void textScene_TextChanged(object sender, EventArgs e)
        {
            if (!mIgnoreSceneValueChange)
                applyObjectTransformation();
        }

        void trackSceneAngle_ValueChanged(object sender, System.EventArgs e)
        {
            if (!mIgnoreSceneValueChange)
            {
                textSceneAngle.Text = trackSceneAngle.Value.ToString();
                applyObjectTransformation();
            }
        }

        private void numericMaterial_ValueChanged(object sender, EventArgs e)
        {
            if (mSelectedObject != -1)
            {
                mSceneObjects[mSelectedObject].material = (int)numericMaterial.Value;
                labelMaterial.Text = mMaterialNames[mSceneObjects[mSelectedObject].material];
            }
        }

        private void updateSceneTree()
        {
            treeView1.Nodes.Clear();
            TreeNode root = treeView1.Nodes.Add("Scene");
            root.Tag = -1;

            for (int i =  0; i <  mSceneObjects.Count; i++)
            {
                TreeNode n = treeView1.Nodes[0].Nodes.Add(mSceneObjects[i].body.Name);
                n.Tag = i;

                if (i == mSelectedObject)
                    treeView1.SelectedNode = n;
            }

            treeView1.ExpandAll();
        }

        private void updateObjectTransformation()
        {
            mIgnoreSceneValueChange = true;
            if (mSelectedObject != -1)
            {
                textScenePosX.Text = mSceneObjects[mSelectedObject].pos.X.ToString();
                textScenePosY.Text = mSceneObjects[mSelectedObject].pos.Y.ToString();

                textSceneAngle.Text = mSceneObjects[mSelectedObject].angle.ToString();
                trackSceneAngle.Value = (int)mSceneObjects[mSelectedObject].angle;

                textSceneScaleX.Text = mSceneObjects[mSelectedObject].scale.X.ToString();
                textSceneScaleY.Text = mSceneObjects[mSelectedObject].scale.Y.ToString();

                numericMaterial.Value = mSceneObjects[mSelectedObject].material;
                labelMaterial.Text = mMaterialNames[mSceneObjects[mSelectedObject].material];
            }
            else
            {
                textScenePosX.Text = textScenePosY.Text = textSceneAngle.Text = textSceneScaleX.Text = textSceneScaleY.Text = "";
                numericMaterial.Value = 0;
                labelMaterial.Text = mMaterialNames[0];
            }
            mIgnoreSceneValueChange = false;
        }

        private void applyObjectTransformation()
        {
            float newVal = 0.0f;
            
            if (float.TryParse(textScenePosX.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out newVal))
                mSceneObjects[mSelectedObject].pos.X = newVal;

            if (float.TryParse(textScenePosY.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out newVal))
                mSceneObjects[mSelectedObject].pos.Y = newVal;

            if (float.TryParse(textSceneAngle.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out newVal))
                mSceneObjects[mSelectedObject].angle = newVal;

            if (float.TryParse(textSceneScaleX.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out newVal))
                mSceneObjects[mSelectedObject].scale.X = newVal;

            if (float.TryParse(textSceneScaleY.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out newVal))
                mSceneObjects[mSelectedObject].scale.Y = newVal;

            redrawImage();
        }

        private void newScene()
        {
            goalInLevel = false;
            secretInLevel = false;
            stickyInLevel = false;
            balloonInLevel = false;
            itemstickInLevel = false;
            itemballoonInLevel = false;
            mSceneBodies.Clear();
            mSceneObjects.Clear();
            mGridCenterX = pictureBox1.Width / 2;
            mGridCenterY = pictureBox1.Height / 2;
            mSceneSettings.CarX = 0.0f;
            mSceneSettings.CarY = 0.0f;
            mSceneSettings.FinishX = 0.0f;
            mSceneSettings.FinishY = 0.0f;
            mSceneSettings.SecretX = 0.0f;
            mSceneSettings.SecretY = 0.0f;
            mSceneSettings.FallLine = 0.0f;
            redrawImage();
            updateSceneTree();
            toolStripMainStatus.Text = "Created new scene.";
        }

        private void saveScene(string p)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Scene");

            root.SetAttribute("name", mSceneSettings.SceneName);

            // soft body objects.
            XmlElement bodies = doc.CreateElement("Objects");

            for (int i = 0; i < mSceneObjects.Count; i++)
            {
                SceneObject o = mSceneObjects[i];
                bool path = o.isPath;

                XmlElement obj = doc.CreateElement(((path) ? "Path" : "Object"));
                obj.SetAttribute("name", o.body.Name);
                obj.SetAttribute("posX", o.pos.X.ToString(CultureInfo.InvariantCulture));
                obj.SetAttribute("posY", o.pos.Y.ToString(CultureInfo.InvariantCulture));
                obj.SetAttribute("angle", o.angle.ToString(CultureInfo.InvariantCulture));
                obj.SetAttribute("scaleX", o.scale.X.ToString(CultureInfo.InvariantCulture));
                obj.SetAttribute("scaleY", o.scale.Y.ToString(CultureInfo.InvariantCulture));

                // following are only valid for regular objects, not paths.
                if (!path)
                {
                    obj.SetAttribute("material", o.material.ToString(CultureInfo.InvariantCulture));

                    if (o.hasCustomColor)
                    {
                        obj.SetAttribute("color", o.customColor.R.ToString() + " " +
                                                    o.customColor.G.ToString() + " " +
                                                    o.customColor.B.ToString() + " " +
                                                    o.customColor.A.ToString());
                    }

                    if ((o.isTrigger) && (o.triggerTargets.Count > 0))
                    {
                        string targets = "";

                        for (int t = 0; t < o.triggerTargets.Count; t++)
                        {
                            int index = -1;
                            for (int j = 0; j < mSceneObjects.Count; j++)
                                if (mSceneObjects[j] == o.triggerTargets[t]) { index = j; break; }

                            targets += ((t > 0) ? " " : "") + index.ToString();
                        }

                        obj.SetAttribute("triggerTargets", targets);

                        if (o.triggerNoCam)
                            obj.SetAttribute("triggerIgnoreCam", true.ToString());
                    }

                    // motion settings.
                    if (o.motionPlatformON || o.motionMotorON)
                    {
                        XmlElement motion = doc.CreateElement("KinematicControls");

                        if (o.motionPlatformON)
                        {
                            XmlElement platform = doc.CreateElement("PlatformMotion");

                            if (o.motionPlatformFollowPath != null)
                            {
                                // path-based values
                                int pathID = -1;
                                for (int pa = 0; pa < mSceneObjects.Count; pa++)
                                    if (o.motionPlatformFollowPath == mSceneObjects[pa]) { pathID = pa; break; }

                                platform.SetAttribute("path", pathID.ToString());
                            }
                            else
                            {
                                // standard linear movement.
                                platform.SetAttribute("offsetX", o.motionPlatformOffset.X.ToString(CultureInfo.InvariantCulture));
                                platform.SetAttribute("offsetY", o.motionPlatformOffset.Y.ToString(CultureInfo.InvariantCulture));
                            }

                            platform.SetAttribute("secondsPerLoop", o.motionPlatformLoop.ToString(CultureInfo.InvariantCulture));
                            platform.SetAttribute("startOffset", o.motionPlatformStartOffset.ToString(CultureInfo.InvariantCulture));
                            platform.SetAttribute("pauseAtEnds", o.motionPlatformPauseAtEnds.ToString(CultureInfo.InvariantCulture));
                            platform.SetAttribute("triggerBehavior", ((int)o.motionPlatformTriggerBehavior).ToString(CultureInfo.InvariantCulture));
                            motion.AppendChild(platform);
                        }

                        if (o.motionMotorON)
                        {
                            XmlElement motor = doc.CreateElement("Motor");
                            
                            foreach( MotorMotionCommand mcmd in o.motionMotorCommands )
                            {
                                XmlElement cmd = doc.CreateElement("MotorCommand");
                                cmd.SetAttribute("type", mcmd.commandType);
                                cmd.SetAttribute("duration", mcmd.duration.ToString(CultureInfo.InvariantCulture));
                                
                                if ((mcmd.commandType == "Rotate") || (mcmd.commandType == "Move"))
                                    cmd.SetAttribute("angle", MathHelper.ToRadians(mcmd.angle).ToString(CultureInfo.InvariantCulture));
                                
                                if (mcmd.commandType == "Move")
                                    cmd.SetAttribute("amount", mcmd.amount.ToString(CultureInfo.InvariantCulture));

                                motor.AppendChild(cmd);
                            }

                            motor.SetAttribute("triggerBehavior", ((int)o.motionMotorTriggerBehavior).ToString(CultureInfo.InvariantCulture));
                            motion.AppendChild(motor);
                        }

                        obj.AppendChild(motion);
                    }
                }
                else
                {
                    // path settings.
                    obj.SetAttribute("closed", o.pathClosed.ToString(CultureInfo.InvariantCulture));
                }

                if (o.objNoRope)
                    obj.SetAttribute("noRope", o.objNoRope.ToString(CultureInfo.InvariantCulture));

                bodies.AppendChild(obj);
            }
            root.AppendChild(bodies);

            // car!
            XmlElement car = doc.CreateElement("Car");
            car.SetAttribute("name", mSceneSettings.CarName);
            car.SetAttribute("posX", mSceneSettings.CarX.ToString(CultureInfo.InvariantCulture));
            car.SetAttribute("posY", mSceneSettings.CarY.ToString(CultureInfo.InvariantCulture));
            root.AppendChild(car);

            // scene settings.
            XmlElement set = doc.CreateElement("Settings");
            set.SetAttribute("finishX", mSceneSettings.FinishX.ToString(CultureInfo.InvariantCulture));
            set.SetAttribute("finishY", mSceneSettings.FinishY.ToString(CultureInfo.InvariantCulture));
            set.SetAttribute("secretX", mSceneSettings.SecretX.ToString(CultureInfo.InvariantCulture));
            set.SetAttribute("secretY", mSceneSettings.SecretY.ToString(CultureInfo.InvariantCulture));
            set.SetAttribute("fallLine", mSceneSettings.FallLine.ToString(CultureInfo.InvariantCulture));
            root.AppendChild(set);

            doc.AppendChild(root);
            doc.Save(p);
        }
        private string formatXml(string xmlString)
        {
            var prettyXmlString = new StringBuilder();

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            var xmlSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };

            using (XmlWriter writer = XmlWriter.Create(prettyXmlString, xmlSettings))
            {
                xmlDoc.Save(writer);
            }

            return prettyXmlString.ToString();
        }

        private void compileAndSaveScene(string p)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Scene");

            root.SetAttribute("name", "");

            // soft body objects.
            XmlElement bodies = doc.CreateElement("Objects");

            for (int i = 0; i < mSceneObjects.Count; i++)
            {
                SceneObject o = mSceneObjects[i];
                bool path = o.isPath;

                XmlElement obj = doc.CreateElement(((path) ? "Path" : "Object"));
                obj.SetAttribute("name", o.body.Name);
                obj.SetAttribute("posX", o.pos.X.ToString(CultureInfo.InvariantCulture));
                obj.SetAttribute("posY", o.pos.Y.ToString(CultureInfo.InvariantCulture));
                obj.SetAttribute("angle", o.angle.ToString(CultureInfo.InvariantCulture));
                obj.SetAttribute("scaleX", o.scale.X.ToString(CultureInfo.InvariantCulture));
                obj.SetAttribute("scaleY", o.scale.Y.ToString(CultureInfo.InvariantCulture));

                // following are only valid for regular objects, not paths.
                if (!path)
                {
                    obj.SetAttribute("material", o.material.ToString(CultureInfo.InvariantCulture));

                    if (o.hasCustomColor)
                    {
                        obj.SetAttribute("color", o.customColor.R.ToString() + " " +
                                                    o.customColor.G.ToString() + " " +
                                                    o.customColor.B.ToString() + " " +
                                                    o.customColor.A.ToString());
                    }

                    if ((o.isTrigger) && (o.triggerTargets.Count > 0))
                    {
                        string targets = "";

                        for (int t = 0; t < o.triggerTargets.Count; t++)
                        {
                            int index = -1;
                            for (int j = 0; j < mSceneObjects.Count; j++)
                                if (mSceneObjects[j] == o.triggerTargets[t]) { index = j; break; }

                            targets += ((t > 0) ? " " : "") + index.ToString();
                        }

                        obj.SetAttribute("triggerTargets", targets);

                        if (o.triggerNoCam)
                            obj.SetAttribute("triggerIgnoreCam", true.ToString());
                    }

                    // motion settings.
                    if (o.motionPlatformON || o.motionMotorON)
                    {
                        XmlElement motion = doc.CreateElement("KinematicControls");

                        if (o.motionPlatformON)
                        {
                            XmlElement platform = doc.CreateElement("PlatformMotion");

                            if (o.motionPlatformFollowPath != null)
                            {
                                // path-based values
                                int pathID = -1;
                                for (int pa = 0; pa < mSceneObjects.Count; pa++)
                                    if (o.motionPlatformFollowPath == mSceneObjects[pa]) { pathID = pa; break; }

                                platform.SetAttribute("path", pathID.ToString());
                            }
                            else
                            {
                                // standard linear movement.
                                platform.SetAttribute("offsetX", o.motionPlatformOffset.X.ToString(CultureInfo.InvariantCulture));
                                platform.SetAttribute("offsetY", o.motionPlatformOffset.Y.ToString(CultureInfo.InvariantCulture));
                            }

                            platform.SetAttribute("secondsPerLoop", o.motionPlatformLoop.ToString(CultureInfo.InvariantCulture));
                            platform.SetAttribute("startOffset", o.motionPlatformStartOffset.ToString(CultureInfo.InvariantCulture));
                            platform.SetAttribute("pauseAtEnds", o.motionPlatformPauseAtEnds.ToString(CultureInfo.InvariantCulture));
                            platform.SetAttribute("triggerBehavior", ((int)o.motionPlatformTriggerBehavior).ToString(CultureInfo.InvariantCulture));
                            motion.AppendChild(platform);
                        }

                        if (o.motionMotorON)
                        {
                            XmlElement motor = doc.CreateElement("Motor");

                            foreach (MotorMotionCommand mcmd in o.motionMotorCommands)
                            {
                                XmlElement cmd = doc.CreateElement("MotorCommand");
                                cmd.SetAttribute("type", mcmd.commandType);
                                cmd.SetAttribute("duration", mcmd.duration.ToString(CultureInfo.InvariantCulture));

                                if ((mcmd.commandType == "Rotate") || (mcmd.commandType == "Move"))
                                    cmd.SetAttribute("angle", MathHelper.ToRadians(mcmd.angle).ToString(CultureInfo.InvariantCulture));

                                if (mcmd.commandType == "Move")
                                    cmd.SetAttribute("amount", mcmd.amount.ToString(CultureInfo.InvariantCulture));

                                motor.AppendChild(cmd);
                            }

                            motor.SetAttribute("triggerBehavior", ((int)o.motionMotorTriggerBehavior).ToString(CultureInfo.InvariantCulture));
                            motion.AppendChild(motor);
                        }

                        obj.AppendChild(motion);
                    }
                }
                else
                {
                    // path settings.
                    obj.SetAttribute("closed", o.pathClosed.ToString(CultureInfo.InvariantCulture));
                }

                if (o.objNoRope)
                    obj.SetAttribute("noRope", o.objNoRope.ToString(CultureInfo.InvariantCulture));

                bodies.AppendChild(obj);
            }
            root.AppendChild(bodies);

            // car!
            XmlElement car = doc.CreateElement("Car");
            car.SetAttribute("name", "");
            car.SetAttribute("posX", mSceneSettings.CarX.ToString(CultureInfo.InvariantCulture));
            car.SetAttribute("posY", mSceneSettings.CarY.ToString(CultureInfo.InvariantCulture));
            root.AppendChild(car);

            // scene settings.
            XmlElement set = doc.CreateElement("Settings");
            set.SetAttribute("finishX", "0");
            set.SetAttribute("finishY", "0");
            set.SetAttribute("secretX", "0");
            set.SetAttribute("secretY", "0");
            set.SetAttribute("fallLine", mSceneSettings.FallLine.ToString(CultureInfo.InvariantCulture));

            root.AppendChild(set);

            doc.AppendChild(root);

            // doc.Save(System.IO.Path.ChangeExtension(p, null) + "_comp.scene");
            Console.WriteLine(doc.OuterXml);
            string compscene = doc.OuterXml;
            string things = "<Car" + Between(compscene, "<Car", "</Scene>") + "</Scene>";
            compscene = compscene.Replace(things, "");
            for (int i = 0; i < mSceneBodies.Count; i++)
            {
                GameBody body = mSceneBodies[i];
                compscene = compscene + body.returnXml("a");
            }
            compscene = compscene + things;
            compscene = formatXml(compscene);
            compscene = compscene.Replace(" /", "/");
            compscene = compscene.Replace(" encoding=\"utf-16\"", "");
            System.IO.File.WriteAllText(System.IO.Path.ChangeExtension(p, null) + "_comp.scene", compscene);
        }
        #endregion

        #region object editing
        private void selectObject(int i)
        {
            selectObject(i, true);
        }

        private void selectObject(int i, bool updateTree)
        {
            mSelectedObject = i;
            if (mSelectedObject != -1)
            {
                groupBoxTransformation.Enabled = true;
                tabControlSceneObjectSettings.Enabled = true;
                groupBox1.Enabled = true;
                butSceneCloneObject.Enabled = true;
                butSceneRemoveObject.Enabled = true;
                objectToolStripMenuItem.Visible = true;
                moveUpButton.Enabled = true;
                moveDownButton.Enabled = true;

                if (mSelectedObject == 0)
                {
                    moveUpButton.Enabled = false;
                }
                else if (mSelectedObject + 1 == mSceneObjects.Count)
                {
                    moveDownButton.Enabled = false;
                }

                checkBoxIsTrigger.Checked = mSceneObjects[mSelectedObject].isTrigger;
                checkBoxTriggerNoCam.Checked = mSceneObjects[mSelectedObject].triggerNoCam;

                checkBoxOverrideColor.Checked = mSceneObjects[mSelectedObject].hasCustomColor;
                Microsoft.Xna.Framework.Graphics.Color xnaColor = (mSceneObjects[mSelectedObject].hasCustomColor) ? 
                    mSceneObjects[mSelectedObject].customColor : mSceneObjects[mSelectedObject].body.Color;
                System.Drawing.Color gdlColor = System.Drawing.Color.FromArgb(255, xnaColor.R, xnaColor.G, xnaColor.B);
                pictureBoxSceneColor.BackColor = gdlColor;
                pictureBoxSceneColor.Invalidate();

                updateObjectTransformation();

                if (!mSceneObjects[mSelectedObject].isPath)
                {
                    radioButton1.Checked = true;
                    tabControlSceneObjectSettings.SelectedIndex = 0;
                }
                else
                {
                    radioButton2.Checked = true;
                    tabControlSceneObjectSettings.SelectedIndex = 1;
                    checkBoxClosedPath.Checked = mSceneObjects[mSelectedObject].pathClosed;
                }

                toolStripMainStatus.Text = "Object selected: " + mSceneObjects[mSelectedObject].body.Name + 
                    "SHIFT + Drag to move | CTRL + Drag to rotate | ALT + Drag to scale";
            }
            else
            {
                groupBoxTransformation.Enabled = false;
                tabControlSceneObjectSettings.Enabled = false;
                groupBox1.Enabled = false;
                butSceneCloneObject.Enabled = false;
                butSceneRemoveObject.Enabled = false;
                objectToolStripMenuItem.Visible = false;
                labelMaterial.Text = "No object selected";
            }

            if (updateTree) 
                updateSceneTree();

            redrawImage();
        }

        private void updateObjectDetails()
        {
            textObjectName.Text = mSceneObjects[mSelectedObject].body.Name;
            textObjectPointMass.Text = mSceneObjects[mSelectedObject].body.MassPerPoint.ToString();
            textEdgeK.Text = mSceneObjects[mSelectedObject].body.EdgeK.ToString();
            textEdgeDamping.Text = mSceneObjects[mSelectedObject].body.EdgeDamping.ToString();

            Microsoft.Xna.Framework.Graphics.Color xnaColor = mSceneObjects[mSelectedObject].body.Color;
            System.Drawing.Color gdlColor = System.Drawing.Color.FromArgb(255, xnaColor.R, xnaColor.G, xnaColor.B);
            pictureBoxObjectColor.BackColor = gdlColor;
            pictureBoxObjectColor.Invalidate();

            checkBoxObjectKinematic.Checked = mSceneObjects[mSelectedObject].body.Kinematic;

            checkBoxObjectShapeMatching.Checked = mSceneObjects[mSelectedObject].body.ShapeMatchingOn;
            textObjectShapeK.Text = mSceneObjects[mSelectedObject].body.ShapeK.ToString();
            textObjectShapeDamping.Text = mSceneObjects[mSelectedObject].body.ShapeDamping.ToString();

            checkBoxPressureBody.Checked = mSceneObjects[mSelectedObject].body.Pressurized;
            textObjectPressure.Text = mSceneObjects[mSelectedObject].body.GasPressure.ToString();
        }

        void textObjectName_Leave(object sender, System.EventArgs e)
        {
            bool bodyNameTaken = false;

            for (int i = 0; i < mSceneBodies.Count; i++)
            {
                if (mSceneBodies[i].Name != textObjectName.Text)
                    continue;
                else
                {
                    if (mSceneObjects[mSelectedObject].body.Name == mSceneBodies[i].Name)
                    {
                        bodyNameTaken = false;
                    }
                    else
                    {
                        bodyNameTaken = true;
                    }
                    break;
                }
            }

            if (!bodyNameTaken)
                mSceneObjects[mSelectedObject].body.Name = textObjectName.Text;
            else
                MessageBox.Show("A softbody with the name " + '"' + textObjectName.Text + '"' + " already exists. Please choose another name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void radioObject_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioObjectEditPoints.Checked)
            {
                mObjectEditMode = ObjectEditMode.Points;
                mSelectedPoint = -1;
                mSelectedSpring = -1;
            }
            else if (radioObjectSprings.Checked)
            {
                mObjectEditMode = ObjectEditMode.Springs;
                mSelectedPoint = -1;
                mSelectedSpring = -1;
            }
            else if (radioObjectPolygons.Checked)
            {
                mObjectEditMode = ObjectEditMode.Polygons;
                mSelectedPoint = -1;
                mSelectedSpring = -1;
            }
        }

        private void updateSpringDetails()
        {
            mIgnoreObjectValueChange = true;
            textObjectSpringK.Text = mSceneObjects[mSelectedObject].body.Springs[mSelectedSpring].SpringK.ToString();
            textObjectSpringDamping.Text = mSceneObjects[mSelectedObject].body.Springs[mSelectedSpring].SpringDamping.ToString();
            mIgnoreObjectValueChange = false;
        }


        void textObjectPointMass_TextChanged(object sender, System.EventArgs e)
        {
            if (textObjectPointMass.Text.Length > 0)
                mSceneObjects[mSelectedObject].body.MassPerPoint = float.Parse(textObjectPointMass.Text, CultureInfo.InvariantCulture);
        }

        private void textObjectSpring_TextChanged(object sender, EventArgs e)
        {
            if ((mSelectedSpring != -1) && (!mIgnoreObjectValueChange))
            {
                if (textObjectSpringK.Text.Length > 0)
                    mSceneObjects[mSelectedObject].body.Springs[mSelectedSpring].SpringK = float.Parse(textObjectSpringK.Text, CultureInfo.InvariantCulture);

                if (textObjectSpringDamping.Text.Length > 0)
                    mSceneObjects[mSelectedObject].body.Springs[mSelectedSpring].SpringDamping = float.Parse(textObjectSpringDamping.Text, CultureInfo.InvariantCulture);
            }
        }

        private void butObjectSpringSetAll_Click(object sender, EventArgs e)
        {
            if ((textObjectSpringK.Text.Length > 0) && (textObjectSpringDamping.Text.Length > 0))
            {
                float k = float.Parse(textObjectSpringK.Text, CultureInfo.InvariantCulture);
                float d = float.Parse(textObjectSpringDamping.Text, CultureInfo.InvariantCulture);

                for (int i = 0; i < mSceneObjects[mSelectedObject].body.Springs.Count; i++)
                {
                    GameBody b = mSceneObjects[mSelectedObject].body;
                    b.Springs[i].SpringK = k;
                    b.Springs[i].SpringDamping = d;
                }

                toolStripMainStatus.Text = "All Springs set to K=" + k.ToString() + " and Damping=" + d.ToString() + ".";
            }
        }

        void textEdgeDamping_TextChanged(object sender, System.EventArgs e)
        {
            if (textEdgeDamping.Text.Length > 0)
                mSceneObjects[mSelectedObject].body.EdgeDamping = float.Parse(textEdgeDamping.Text, CultureInfo.InvariantCulture);
        }

        void textEdgeK_TextChanged(object sender, System.EventArgs e)
        {
            if (textEdgeK.Text.Length > 0)
                mSceneObjects[mSelectedObject].body.EdgeK = float.Parse(textEdgeK.Text, CultureInfo.InvariantCulture);
        }

        void textObjectShapeK_TextChanged(object sender, System.EventArgs e)
        {
            if (textObjectShapeK.Text.Length > 0)
                mSceneObjects[mSelectedObject].body.ShapeK = float.Parse(textObjectShapeK.Text, CultureInfo.InvariantCulture);
        }

        void textObjectShapeDamping_TextChanged(object sender, System.EventArgs e)
        {
            if (textObjectShapeDamping.Text.Length > 0)
                mSceneObjects[mSelectedObject].body.ShapeDamping = float.Parse(textObjectShapeDamping.Text, CultureInfo.InvariantCulture);
        }


        private void updateSpringsPointRemoved(int p)
        {
            List<GameBody.InternalSpring> toDelete = new List<GameBody.InternalSpring>();

            GameBody b = mSceneObjects[mSelectedObject].body;

            for (int i = 0; i < b.Springs.Count; i++)
            {
                // if the spring contains p, remove it.  if it has a point with id > p, decrement by 1.
                if ((b.Springs[i].PointMassA == p) || (b.Springs[i].PointMassB == p))
                    toDelete.Add(b.Springs[i]);

                if (b.Springs[i].PointMassA > p) { b.Springs[i].PointMassA--; }
                if (b.Springs[i].PointMassB > p) { b.Springs[i].PointMassB--; }
            }

            // kill all springs to delete
            while (toDelete.Count > 0)
            {
                b.Springs.Remove(toDelete[toDelete.Count - 1]);
                toDelete.RemoveAt(toDelete.Count - 1);
            }
        }

        private void updatePolygonsPointRemoved(int p)
        {
            List<GameBody.Polygon> toDelete = new List<GameBody.Polygon>();

            GameBody b = mSceneObjects[mSelectedObject].body;

            for (int i = 0; i < b.Polygons.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (b.Polygons[i].PointMasses[j] == p)
                    {
                        toDelete.Add(b.Polygons[i]);
                        break;
                    }

                    if (b.Polygons[i].PointMasses[j] > p) { b.Polygons[i].PointMasses[j]--; }
                }
            }

            while (toDelete.Count > 0)
            {
                b.Polygons.Remove(toDelete[toDelete.Count - 1]);
                toDelete.RemoveAt(toDelete.Count - 1);
            }
        }

        private void updateSpringsPointAdded(int p)
        {
            GameBody b = mSceneObjects[mSelectedObject].body;

            for (int i = 0; i < b.Springs.Count; i++)
            {
                // if a point mass >= p, increment it by one to point to the right point.
                if (b.Springs[i].PointMassA >= p) { b.Springs[i].PointMassA++; }
                if (b.Springs[i].PointMassB >= p) { b.Springs[i].PointMassB++; }
            }
        }

        private void updatePolygonsPointAdded(int p)
        {
            GameBody b = mSceneObjects[mSelectedObject].body;

            for (int i = 0; i < b.Polygons.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                    if (b.Polygons[i].PointMasses[j] >= p) { b.Polygons[i].PointMasses[j]++; }
            }
        }

        private void butObjectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color newColor = colorDialog1.Color;

                Microsoft.Xna.Framework.Graphics.Color xnaColor = new Microsoft.Xna.Framework.Graphics.Color(newColor.R, newColor.G, newColor.B, 255);
                mSceneObjects[mSelectedObject].body.Color = xnaColor;

                pictureBoxObjectColor.BackColor = newColor;
                pictureBoxObjectColor.Invalidate();
                redrawImage();
            }
        }

        private void checkBoxObjectKinematic_CheckedChanged(object sender, EventArgs e)
        {
            mSceneObjects[mSelectedObject].body.Kinematic = checkBoxObjectKinematic.Checked;
        }

        private void checkBoxObjectShapeMatching_CheckedChanged(object sender, EventArgs e)
        {
            mSceneObjects[mSelectedObject].body.ShapeMatchingOn = checkBoxObjectShapeMatching.Checked;
        }

        private void checkBoxPressureBody_CheckedChanged(object sender, EventArgs e)
        {
            textObjectPressure.Enabled = checkBoxPressureBody.Checked;

            mSceneObjects[mSelectedObject].body.Pressurized = checkBoxPressureBody.Checked;
        }

        private void textObjectPressure_TextChanged(object sender, EventArgs e)
        {
            if (textObjectPressure.Text.Length > 0)
                mSceneObjects[mSelectedObject].body.GasPressure = float.Parse(textObjectPressure.Text, CultureInfo.InvariantCulture);
        }
        #endregion

        #region drawing
        // redrawImage!!!
        public void redrawImage()
        {
            pictureBox1.Invalidate();
            if (lightMode)
            {
                mGraphics.Clear(System.Drawing.Color.FromArgb(255, 242, 242, 242));
            }
            else
            {
                mGraphics.Clear(System.Drawing.Color.FromArgb(255, 48, 48, 48));
            }

            if (drawPolysInSceneEditModeToolStripMenuItem.Checked)
            {
                drawObjects();
                if (mShowGrid)
                {
                    drawGrid();
                }
            }
            else
            {
                if (mShowGrid)
                {
                    drawGrid();
                }
                drawObjects();
            }
            drawSpawnPoints();
        }

        public void updateGridSettings(int gs_x, int gs_y, float major_sub, int minor_sub)
        {
            mGridSizeX = gs_x;
            mGridSizeY = gs_y;
            mGridMajorSub = major_sub;
            mGridMinorSub = minor_sub;

            redrawImage();
        }

        private void drawGrid()
        {
            // draw the grid - major lines!
            for (int y = -(mGridSizeY / 2); y <= (mGridSizeY / 2); y++)
            {
                if (lightMode)
                {
                    mGraphics.DrawLine(new Pen((y == 0) ? System.Drawing.Color.Black : System.Drawing.Color.Black, 1.0f),
                    new System.Drawing.Point((int)(mGridCenterX - ((mGridSizeX / 2) * mGridMajorSub * mGridZoom)), (int)(mGridCenterY - (y * mGridMajorSub * mGridZoom))),
                    new System.Drawing.Point((int)(mGridCenterX + ((mGridSizeX / 2) * mGridMajorSub * mGridZoom)), (int)(mGridCenterY - (y * mGridMajorSub * mGridZoom))));
                }
                else
                {
                    mGraphics.DrawLine(new Pen((y == 0) ? System.Drawing.Color.Red : System.Drawing.Color.White, 1.0f),
                    new System.Drawing.Point((int)(mGridCenterX - ((mGridSizeX / 2) * mGridMajorSub * mGridZoom)), (int)(mGridCenterY - (y * mGridMajorSub * mGridZoom))),
                    new System.Drawing.Point((int)(mGridCenterX + ((mGridSizeX / 2) * mGridMajorSub * mGridZoom)), (int)(mGridCenterY - (y * mGridMajorSub * mGridZoom))));
                }
                    

                // now draw sub-lines
                if (y < (mGridSizeY / 2))
                {
                    for (int dy = 1; dy < mGridMinorSub; dy++)
                    {
                        mGraphics.DrawLine(new Pen(System.Drawing.Color.DarkGray, 1.0f),
                            new System.Drawing.Point((int)(mGridCenterX - ((mGridSizeX / 2) * mGridMajorSub * mGridZoom)), (int)(mGridCenterY - (((y * mGridMajorSub) + (dy * (mGridMajorSub / mGridMinorSub))) * mGridZoom))),
                            new System.Drawing.Point((int)(mGridCenterX + ((mGridSizeX / 2) * mGridMajorSub * mGridZoom)), (int)(mGridCenterY - (((y * mGridMajorSub) + (dy * (mGridMajorSub / mGridMinorSub))) * mGridZoom))));
                    }
                }
            }

            for (int x = -(mGridSizeX / 2); x <= (mGridSizeX / 2); x++)
            {
                if (lightMode)
                {
                    mGraphics.DrawLine(new Pen((x == 0) ? System.Drawing.Color.Black : System.Drawing.Color.Black, 1.0f),
                    new System.Drawing.Point((int)(mGridCenterX + (x * mGridMajorSub * mGridZoom)), (int)(mGridCenterY - ((mGridSizeY / 2) * mGridMajorSub * mGridZoom))),
                    new System.Drawing.Point((int)(mGridCenterX + (x * mGridMajorSub * mGridZoom)), (int)(mGridCenterY + ((mGridSizeY / 2) * mGridMajorSub * mGridZoom))));
                }
                else
                {
                    mGraphics.DrawLine(new Pen((x == 0) ? System.Drawing.Color.Yellow : System.Drawing.Color.White, 1.0f),
                    new System.Drawing.Point((int)(mGridCenterX + (x * mGridMajorSub * mGridZoom)), (int)(mGridCenterY - ((mGridSizeY / 2) * mGridMajorSub * mGridZoom))),
                    new System.Drawing.Point((int)(mGridCenterX + (x * mGridMajorSub * mGridZoom)), (int)(mGridCenterY + ((mGridSizeY / 2) * mGridMajorSub * mGridZoom))));
                }

                // now draw sub-lines
                if (x < (mGridSizeX / 2))
                {
                    for (int dx = 1; dx < mGridMinorSub; dx++)
                    {
                        mGraphics.DrawLine(new Pen(System.Drawing.Color.DarkGray, 1.0f),
                            new System.Drawing.Point((int)(mGridCenterX + (((x * mGridMajorSub) + (dx * (mGridMajorSub / mGridMinorSub))) * mGridZoom)), (int)(mGridCenterY - ((mGridSizeY / 2) * mGridMajorSub * mGridZoom))),
                            new System.Drawing.Point((int)(mGridCenterX + (((x * mGridMajorSub) + (dx * (mGridMajorSub / mGridMinorSub))) * mGridZoom)), (int)(mGridCenterY + ((mGridSizeY / 2) * mGridMajorSub * mGridZoom))));
                    }
                }
            }
        }

        private void drawObjects()
        {
            if (mEditMode == EditMode.Scene)
            {
                for (int i = 0; i < mSceneObjects.Count; i++)
                {
                    SceneObject obj = mSceneObjects[i];
                    GameBody body = mSceneObjects[i].body;

                    // if user has enabled drawing polys in scene edit mode, draw them.
                    if (drawPolysInSceneEditModeToolStripMenuItem.Checked)
                    {
                        Microsoft.Xna.Framework.Graphics.Color polyColor = (obj.hasCustomColor) ? obj.customColor : body.Color;
                        // System.Drawing.Color c = System.Drawing.Color.FromArgb(128, obj.body.Color.R, obj.body.Color.G, obj.body.Color.B);
                        System.Drawing.Color c = System.Drawing.Color.FromArgb(255, polyColor.R, polyColor.G, polyColor.B);
                        System.Drawing.SolidBrush b = new SolidBrush(c);
                        List<System.Drawing.Point> points = new List<System.Drawing.Point>();
                        for (int j = 0; j < body.Polygons.Count; j++)
                        {
                            for (int d = 0; d < 3; d++)
                            {
                                points.Add(new System.Drawing.Point((int)BodyPointToScreen(obj, body.Polygons[j].PointMasses[d]).X,
                                    (int)BodyPointToScreen(obj, body.Polygons[j].PointMasses[d]).Y));
                            }

                            mGraphics.FillPolygon(b, points.ToArray());
                            points.Clear();
                        }

                        for (int j = 0; j < body.Points.Count; j++)
                        {
                            int p1 = j;
                            int p2 = (j < (body.Points.Count - 1)) ? j + 1 : 0;

                            // now transform into global space.
                            Vector2 screenP1 = BodyPointToScreen(obj, p1);
                            Vector2 screenP2 = BodyPointToScreen(obj, p2);

                            //gjfugyhdruitghfjghdfkgdfgjkfhgkjdfhgkjdfhgkjdfhgkfjdhgkdfjghdfjkghdfjkghdfkjghfjkdghdfjk
                            if (lightMode)
                                mGraphics.DrawLine(new Pen(System.Drawing.Color.Green, 1.0f),
                                new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                                new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                            else
                                mGraphics.DrawLine(new Pen(System.Drawing.Color.GreenYellow, 1.0f),
                                new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                                new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                        }
                    }

                    for (int j = 0; j < body.Points.Count; j++)
                    {
                        int p1 = j;
                        int p2 = (j < (body.Points.Count - 1)) ? j + 1 : 0;


                        if ((obj.isPath) && (!obj.pathClosed) && (j == (body.Points.Count - 1)))
                            break;

                        // now transform into global space.
                        Vector2 screenP1 = BodyPointToScreen(obj, p1);
                        Vector2 screenP2 = BodyPointToScreen(obj, p2);

                        Vector2 lineDir = Vector2.Normalize(screenP1 - screenP2);
                        Vector2 lineNormal = JellyPhysics.VectorTools.getPerpendicular(lineDir);

                        // draw base line...
                        Microsoft.Xna.Framework.Graphics.Color xnaColor = (obj.hasCustomColor) ? obj.customColor : body.Color;
                        Pen pen = new Pen(System.Drawing.Color.FromArgb(255, xnaColor.R, xnaColor.G, xnaColor.B), 2.0f);
                        if (drawPolysInSceneEditModeToolStripMenuItem.Checked)
                        {
                            pen.Color = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                            if (obj.material == 5)
                            {
                                if (xnaColor.R < 100)
                                {
                                    xnaColor.R = 100;
                                }
                                else
                                {
                                    xnaColor.R = (byte)(xnaColor.R - 100);
                                }

                                if (xnaColor.G < 100)
                                {
                                    xnaColor.G = 100;
                                }
                                else
                                {
                                    xnaColor.G = (byte)(xnaColor.G - 100);
                                }

                                if (xnaColor.B < 100)
                                {
                                    xnaColor.B = 100;
                                }
                                else
                                {
                                    xnaColor.B = (byte)(xnaColor.B - 100);
                                }

                                pen.Color = System.Drawing.Color.FromArgb(255, xnaColor.R, xnaColor.G, xnaColor.B);
                            }
                        }

                        if (obj.isPath)
                        {
                            pen.Color = System.Drawing.Color.Gray;
                            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        }

                        mGraphics.DrawLine(pen,
                            new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                            new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));

                        // if this is the selected object, also draw a red outline outside the object.
                        if (i == mSelectedObject)
                        {
                            Vector2 o_screenP1 = screenP1 + lineNormal * 4.0f;
                            Vector2 o_screenP2 = screenP2 + lineNormal * 4.0f;
                             

                            mGraphics.DrawLine(new Pen(System.Drawing.Color.Red, 2.0f),
                                new System.Drawing.Point((int)o_screenP1.X, (int)o_screenP1.Y),
                                new System.Drawing.Point((int)o_screenP2.X, (int)o_screenP2.Y));
                        }

                        // if this object is a trigger, indicate this with another line hilight.
                        if (obj.isTrigger)
                        {
                            Vector2 o_screenP1 = screenP1 - lineNormal * 2.0f;
                            Vector2 o_screenP2 = screenP2 - lineNormal * 2.0f;

                            Pen p;

                            if (!drawPolysInSceneEditModeToolStripMenuItem.Checked)
                            {
                                p = new Pen(System.Drawing.Color.FromArgb(255, xnaColor.R, xnaColor.G, xnaColor.B), 2.0f);
                            }
                            else
                            {
                                p = new Pen(System.Drawing.Color.FromArgb(255, 0, 0, 0), 2.0f);
                            }
                            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            mGraphics.DrawLine(p,
                                new System.Drawing.Point((int)o_screenP1.X, (int)o_screenP1.Y),
                                new System.Drawing.Point((int)o_screenP2.X, (int)o_screenP2.Y));
                        }

                        /* if this object has a motor, indicate this as well.
                        if (obj.motionMotorON)
                        {
                            Vector2 o_screenP1 = screenP1 - lineNormal * -6.0f;
                            Vector2 o_screenP2 = screenP2 - lineNormal * -6.0f;

                            Pen p;

                            if (!drawPolysInSceneEditModeToolStripMenuItem.Checked)
                            {
                                p = new Pen(System.Drawing.Color.FromArgb(255, xnaColor.R, xnaColor.G, xnaColor.B), 2.0f);
                            }
                            else
                            {
                                p = new Pen(System.Drawing.Color.FromArgb(255, 0, 0, 0), 2.0f);
                            }
                            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            mGraphics.DrawLine(p,
                                new System.Drawing.Point((int)o_screenP1.X, (int)o_screenP1.Y),
                                new System.Drawing.Point((int)o_screenP2.X, (int)o_screenP2.Y));
                        }*/

                        // if this object also has platform motion, draw the other end right now as well.
                        if (obj.motionPlatformON)
                        {
                            screenP1 = BodyOffsetPointToScreen(obj, p1, obj.motionPlatformOffset);
                            screenP2 = BodyOffsetPointToScreen(obj, p2, obj.motionPlatformOffset);
                            bool draw = true;

                            if (obj.motionPlatformFollowPath != null)
                            {
                                if (obj.motionPlatformFollowPath.pathClosed)
                                {
                                    draw = false;
                                }
                                else
                                {
                                    Vector2 offset = BodyPointToGlobal(obj.motionPlatformFollowPath, obj.motionPlatformFollowPath.body.Points.Count-1) - 
                                        BodyPointToGlobal(obj.motionPlatformFollowPath, 0);

                                    screenP1 = BodyOffsetPointToScreen(obj, p1, offset);
                                    screenP2 = BodyOffsetPointToScreen(obj, p2, offset);
                                }
                            }

                            if (draw)
                            {
                                if (lightMode)
                                {
                                    mGraphics.DrawLine(new Pen(System.Drawing.Color.FromArgb(255, 169, 169, 169), 2.0f),
                                    new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                                    new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                                }
                                else
                                {
                                    mGraphics.DrawLine(new Pen(System.Drawing.Color.FromArgb(128, 128, 128, 0), 2.0f),
                                    new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                                    new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                                }
                            }
                        }
                    }

                    // draw platform motion line...
                    if ((obj.motionPlatformON) && (obj.motionPlatformFollowPath == null))
                    {
                        Vector2 pt1 = PosToScreen(obj.pos);
                        Vector2 pt2 = PosToScreen(obj.pos + obj.motionPlatformOffset);
                        
                        mGraphics.DrawLine(new Pen(System.Drawing.Color.FromArgb(128, 0, 128, 0), 2.0f),
                            new System.Drawing.Point((int)pt1.X, (int)pt1.Y),
                            new System.Drawing.Point((int)pt2.X, (int)pt2.Y));
                    }

                    if (obj.isTrigger && obj.triggerTargets.Count > 0)
                    {
                        Vector2 pt1 = PosToScreen(obj.pos);

                        for (int t = 0; t < obj.triggerTargets.Count; t++)
                        {
                            if (obj.triggerTargets[t] != obj)
                            {
                                // line to object.
                                Vector2 pt2 = PosToScreen(obj.triggerTargets[t].pos);

                                Pen p = new Pen(System.Drawing.Color.Gray, 3.0f);
                                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                                mGraphics.DrawLine(p,
                                    new System.Drawing.Point((int)pt1.X, (int)pt1.Y),
                                    new System.Drawing.Point((int)pt2.X, (int)pt2.Y));
                            }
                            else
                            {
                                // target is SELF
                                Pen p = new Pen(System.Drawing.Color.Gray, 3.0f);
                                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                                mGraphics.DrawArc(p, pt1.X - 10, pt1.Y - 10, 20, 20, 0f, 360);
                            }
                        }
                    }
                    // end drawing platform motion line

                    // draw motorcommand lines
                    if (obj.motionMotorON)
                    {
                        Vector2 prevMcTargetPos;
                        float objAngleFromMCs = 0;
                        prevMcTargetPos.X = obj.pos.X;
                        prevMcTargetPos.Y = obj.pos.Y;

                        for (int j = 0; j < obj.motionMotorCommands.Count; j++)
                        {
                            //Console.WriteLine("Current command (" + (j + 1) + ") type: " + obj.motionMotorCommands[j].commandType + ",");

                            if (obj.motionMotorCommands[j].commandType == "Move")
                            {
                                //Console.WriteLine("Drawing MotorCommand line number " + (j + 1) + ",");

                                Vector2 pt1;
                                Vector2 mcTargetPos;
                                Vector2 pt2;

                                if (j == 0)
                                {
                                    pt1 =  PosToScreen(obj.pos);
                                    mcTargetPos.X = obj.pos.X + Convert.ToSingle(obj.motionMotorCommands[j].amount * Math.Cos(MathHelper.ToRadians(obj.motionMotorCommands[j].angle)));
                                    mcTargetPos.Y = obj.pos.Y + Convert.ToSingle(obj.motionMotorCommands[j].amount * Math.Sin(MathHelper.ToRadians(obj.motionMotorCommands[j].angle)));
                                    prevMcTargetPos.X = mcTargetPos.X;
                                    prevMcTargetPos.Y = mcTargetPos.Y;
                                    //Console.WriteLine("a: " + prevMcTargetPos.X + ", " + prevMcTargetPos.Y);
                                    pt2 = PosToScreen(mcTargetPos);
                                }
                                else
                                {
                                    //Console.WriteLine("b: " + prevMcTargetPos.X + ", " + prevMcTargetPos.Y);
                                    pt1 = PosToScreen(prevMcTargetPos);
                                    mcTargetPos.X = prevMcTargetPos.X + Convert.ToSingle(obj.motionMotorCommands[j].amount * Math.Cos(MathHelper.ToRadians(obj.motionMotorCommands[j].angle)));
                                    mcTargetPos.Y = prevMcTargetPos.Y + Convert.ToSingle(obj.motionMotorCommands[j].amount * Math.Sin(MathHelper.ToRadians(obj.motionMotorCommands[j].angle)));
                                    prevMcTargetPos.X = mcTargetPos.X;
                                    prevMcTargetPos.Y = mcTargetPos.Y;
                                    pt2 = PosToScreen(mcTargetPos);
                                }

                                // draw motorcommand outlines
                                for (int k = 0; k < body.Points.Count; k++)
                                {
                                    Vector2 mcTargetPos2;
                                    mcTargetPos2 = mcTargetPos;
                                    mcTargetPos2.X = mcTargetPos2.X - obj.pos.X;
                                    mcTargetPos2.Y = mcTargetPos2.Y - obj.pos.Y;

                                    int p1 = k;
                                    int p2 = (k < (body.Points.Count - 1)) ? k + 1 : 0;
                                    Vector2 screenP1 = BodyPointToScreenWithExtraRotation(obj, p1, objAngleFromMCs);
                                    Vector2 screenP2 = BodyPointToScreenWithExtraRotation(obj, p2, objAngleFromMCs);
                                    screenP1 = BodyOffsetPointToScreenWithExtraRotation(obj, p1, mcTargetPos2, objAngleFromMCs);
                                    screenP2 = BodyOffsetPointToScreenWithExtraRotation(obj, p2, mcTargetPos2, objAngleFromMCs);

                                    if (lightMode)
                                    {
                                        mGraphics.DrawLine(new Pen(System.Drawing.Color.FromArgb(255, 169, 169, 169), 2.0f),
                                        new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                                        new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                                    }
                                    else
                                    {
                                        mGraphics.DrawLine(new Pen(System.Drawing.Color.FromArgb(128, 128, 128, 0), 2.0f),
                                        new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                                        new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                                    }
                                }

                                //Console.WriteLine("OBJ's X = " + (int)pt1.X + ", OBJ's Y = " + (int)pt1.X);
                                //Console.WriteLine("X = " + (int)pt2.X + ", Y = " + (int)pt2.Y);

                                Pen p = new Pen(System.Drawing.Color.FromArgb(128, 0, 128, 0), 2.0f);
                                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                                mGraphics.DrawLine(p,
                                    new System.Drawing.Point((int)pt1.X, (int)pt1.Y),
                                    new System.Drawing.Point((int)pt2.X, (int)pt2.Y));
                            }
                            if (obj.motionMotorCommands[j].commandType == "Rotate")
                            {
                                // add the new rotation to the total rotation including previous motor commands
                                objAngleFromMCs += obj.motionMotorCommands[j].angle;

                                // draw motorcommand outlines
                                for (int k = 0; k < body.Points.Count; k++)
                                {
                                    Vector2 mcTargetPos2;
                                    mcTargetPos2 = prevMcTargetPos;
                                    mcTargetPos2.X = mcTargetPos2.X - obj.pos.X;
                                    mcTargetPos2.Y = mcTargetPos2.Y - obj.pos.Y;

                                    int p1 = k;
                                    int p2 = (k < (body.Points.Count - 1)) ? k + 1 : 0;
                                    Vector2 screenP1 = BodyPointToScreenWithExtraRotation(obj, p1, objAngleFromMCs);
                                    Vector2 screenP2 = BodyPointToScreenWithExtraRotation(obj, p2, objAngleFromMCs);
                                    screenP1 = BodyOffsetPointToScreenWithExtraRotation(obj, p1, mcTargetPos2, objAngleFromMCs);
                                    screenP2 = BodyOffsetPointToScreenWithExtraRotation(obj, p2, mcTargetPos2, objAngleFromMCs);

                                    if (lightMode)
                                    {
                                        mGraphics.DrawLine(new Pen(System.Drawing.Color.FromArgb(255, 169, 169, 169), 2.0f),
                                        new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                                        new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                                    }
                                    else
                                    {
                                        mGraphics.DrawLine(new Pen(System.Drawing.Color.FromArgb(128, 128, 128, 0), 2.0f),
                                        new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                                        new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                                    }
                                }
                            }
                        }
                    }

                    // draw center point X and Y axis.
                    Vector2 bpt = PosToScreen(obj.pos);
                    Vector2 xpt = PosToScreen(obj.pos + JellyPhysics.VectorTools.rotateVector(new Vector2(15.0f/mGridZoom, 0f), MathHelper.ToRadians(obj.angle)));
                    Vector2 ypt = PosToScreen(obj.pos + JellyPhysics.VectorTools.rotateVector(new Vector2(0.0f, 15.0f/mGridZoom), MathHelper.ToRadians(obj.angle)));
                    if (lightMode)
                    {
                        mGraphics.DrawLine(new Pen(System.Drawing.Color.Black, 1.5f), new System.Drawing.Point((int)bpt.X, (int)bpt.Y),
                        new System.Drawing.Point((int)xpt.X, (int)xpt.Y));
                    }
                    else
                    {
                        mGraphics.DrawLine(new Pen(System.Drawing.Color.Red, 1.5f), new System.Drawing.Point((int)bpt.X, (int)bpt.Y),
                        new System.Drawing.Point((int)xpt.X, (int)xpt.Y));
                    }
                    
                    if (lightMode)
                    {
                        mGraphics.DrawLine(new Pen(System.Drawing.Color.Black, 1.5f), new System.Drawing.Point((int)bpt.X, (int)bpt.Y),
                        new System.Drawing.Point((int)ypt.X, (int)ypt.Y));
                    }
                    else
                    {
                        mGraphics.DrawLine(new Pen(System.Drawing.Color.Yellow, 1.5f), new System.Drawing.Point((int)bpt.X, (int)bpt.Y),
                        new System.Drawing.Point((int)ypt.X, (int)ypt.Y));
                    }
                    
                }
            }
            else
            {
                // only draw the selected object.
                SceneObject obj = mSceneObjects[mSelectedObject];
                GameBody body = obj.body;

                // draw polygons first.
                // System.Drawing.Color c = System.Drawing.Color.FromArgb(128, obj.body.Color.R, obj.body.Color.G, obj.body.Color.B);
                System.Drawing.Color c = System.Drawing.Color.FromArgb(255, obj.body.Color.R, obj.body.Color.G, obj.body.Color.B);
                System.Drawing.SolidBrush b = new SolidBrush(c);
                List<System.Drawing.Point> points = new List<System.Drawing.Point>();
                for (int j = 0; j < body.Polygons.Count; j++)
                {                   
                    for (int d = 0; d < 3; d++)
                    {
                        points.Add(new System.Drawing.Point((int)BodyPointToScreen(obj, body.Polygons[j].PointMasses[d]).X,
                            (int)BodyPointToScreen(obj, body.Polygons[j].PointMasses[d]).Y ));
                    }

                    mGraphics.FillPolygon(b, points.ToArray());
                    points.Clear();
                }

                for (int j = 0; j < body.Points.Count; j++)
                {
                    int p1 = j;
                    int p2 = (j < (body.Points.Count - 1)) ? j + 1 : 0;

                    // now transform into global space.
                    Vector2 screenP1 = BodyPointToScreen(obj, p1);
                    Vector2 screenP2 = BodyPointToScreen(obj, p2);

                    if (lightMode)
                        mGraphics.DrawLine(new Pen(System.Drawing.Color.Green, 1.0f),
                        new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                        new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                    else
                        mGraphics.DrawLine(new Pen(System.Drawing.Color.GreenYellow, 1.0f),
                        new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                        new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                }

                // now draw points.
                for (int j = 0; j < body.Points.Count; j++)
                {
                    Vector2 screen = BodyPointToScreen(obj, j);

                    if (lightMode)
                        mGraphics.DrawArc(new Pen((j == mSelectedPoint) ? System.Drawing.Color.Red : System.Drawing.Color.Black, 2.0f), (int)screen.X - 3, (int)screen.Y - 3, 6, 6, 0, 360);
                    else
                        mGraphics.DrawArc(new Pen((j == mSelectedPoint) ? System.Drawing.Color.Red : System.Drawing.Color.Green, 2.0f), (int)screen.X - 3, (int)screen.Y - 3, 6, 6, 0, 360);
                }

                // now draw springs.
                for (int j = 0; j < body.Springs.Count; j++)
                {
                    Vector2 screen1 = BodyPointToScreen(obj, body.Springs[j].PointMassA);
                    Vector2 screen2 = BodyPointToScreen(obj, body.Springs[j].PointMassB);

                    mGraphics.DrawLine(new Pen((j == mSelectedSpring) ? System.Drawing.Color.Red : System.Drawing.Color.Orange, (j == mSelectedSpring) ? 2.0f : 1.0f),
                        new System.Drawing.Point((int)screen1.X, (int)screen1.Y),
                        new System.Drawing.Point((int)screen2.X, (int)screen2.Y));
                }

                if (mDraggingSpring)
                {
                    Vector2 screen1 = BodyPointToScreen(obj, mDragSpringStartPoint);

                    mGraphics.DrawLine(new Pen(System.Drawing.Color.Orange, 1.0f),
                        new System.Drawing.Point((int)screen1.X, (int)screen1.Y),
                        new System.Drawing.Point((int)mMouseScreen.X, (int)mMouseScreen.Y));
                }


                if (obj.isPath)
                {
                    for (int i = 0; i < mSceneObjects.Count; i++)
                    {
                        if (i == mSelectedObject)
                            continue;

                        obj = mSceneObjects[i];
                        body = obj.body;
                        // also draw other objects, for reference
                        for (int j = 0; j < body.Points.Count; j++)
                        {
                            int p1 = j;
                            int p2 = (j < (body.Points.Count - 1)) ? j + 1 : 0;

                            if ((obj.isPath) && (!obj.pathClosed) && (j == (body.Points.Count - 1)))
                                break;

                            // now transform into global space.
                            Vector2 screenP1 = BodyPointToScreen(obj, p1);
                            Vector2 screenP2 = BodyPointToScreen(obj, p2);

                            // draw base line...
                            Microsoft.Xna.Framework.Graphics.Color xnaColor = (obj.hasCustomColor) ? obj.customColor : body.Color;
                            Pen pen = new Pen(System.Drawing.Color.FromArgb(255, xnaColor.R, xnaColor.G, xnaColor.B), 2.0f);
                            if (obj.isPath)
                            {
                                pen.Color = System.Drawing.Color.Gray;
                                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                            }

                            mGraphics.DrawLine(pen,
                                new System.Drawing.Point((int)screenP1.X, (int)screenP1.Y),
                                new System.Drawing.Point((int)screenP2.X, (int)screenP2.Y));
                        }
                    }
                }

                // draw center point X and Y axis.
                Vector2 bpt = PosToScreen(obj.pos);
                Vector2 xpt = PosToScreen(obj.pos + JellyPhysics.VectorTools.rotateVector(new Vector2(15.0f / mGridZoom, 0f), MathHelper.ToRadians(obj.angle)));
                Vector2 ypt = PosToScreen(obj.pos + JellyPhysics.VectorTools.rotateVector(new Vector2(0.0f, 15.0f / mGridZoom), MathHelper.ToRadians(obj.angle)));
                if (lightMode)
                {
                    mGraphics.DrawLine(new Pen(System.Drawing.Color.Black, 1.5f), new System.Drawing.Point((int)bpt.X, (int)bpt.Y),
                    new System.Drawing.Point((int)xpt.X, (int)xpt.Y));

                    mGraphics.DrawLine(new Pen(System.Drawing.Color.Black, 1.5f), new System.Drawing.Point((int)bpt.X, (int)bpt.Y),
                        new System.Drawing.Point((int)ypt.X, (int)ypt.Y));
                }
                else
                {
                    mGraphics.DrawLine(new Pen(System.Drawing.Color.Red, 1.5f), new System.Drawing.Point((int)bpt.X, (int)bpt.Y),
                    new System.Drawing.Point((int)xpt.X, (int)xpt.Y));

                    mGraphics.DrawLine(new Pen(System.Drawing.Color.Yellow, 1.5f), new System.Drawing.Point((int)bpt.X, (int)bpt.Y),
                        new System.Drawing.Point((int)ypt.X, (int)ypt.Y));
                }
            }

        }

        private void drawSpawnPoints()
        {
            // car spawn point!
            Vector2 car = PosToScreen(new Vector2(mSceneSettings.CarX, mSceneSettings.CarY));

            mGraphics.DrawArc(new Pen(System.Drawing.Color.Orange, 2.0f), (int)car.X - 10, (int)car.Y - 10, 20, 20, 0, 360);
 

            // Finish point.
            Vector2 finish = PosToScreen(new Vector2(mSceneSettings.FinishX, mSceneSettings.FinishY));

            mGraphics.DrawRectangle(new Pen(System.Drawing.Color.Cyan, 2.0f), (int)finish.X - 10, (int)finish.Y - 10, 20, 20);

            // secret exit point.
            Vector2 secret = PosToScreen(new Vector2(mSceneSettings.SecretX, mSceneSettings.SecretY));

            mGraphics.DrawRectangle(new Pen(System.Drawing.Color.Gold, 2.0f), (int)secret.X - 10, (int)secret.Y - 10, 20, 20);


            // fall line.
            Vector2 start = PosToScreen(new Vector2(-1000, mSceneSettings.FallLine));
            Vector2 end = PosToScreen(new Vector2(1000, mSceneSettings.FallLine));

            mGraphics.DrawLine(new Pen(System.Drawing.Color.FromArgb(128, 255, 0, 255), 1.0f),
                (int)start.X, (int)start.Y, (int)end.X, (int)end.Y);
        }

        Vector2 BodyPointToGlobal(SceneObject obj, int point)
        {
            return obj.pos + JellyPhysics.VectorTools.rotateVector((obj.body.Points[point].pos * obj.scale), MathHelper.ToRadians(obj.angle));
        }

        Vector2 BodyPointToGlobalWithExtraRotation(SceneObject obj, int point, float extrarotation)
        {
            return obj.pos + JellyPhysics.VectorTools.rotateVector((obj.body.Points[point].pos * obj.scale), MathHelper.ToRadians(obj.angle + extrarotation));
        }

        Vector2 BodyPointToScreen(SceneObject obj, int point)
        {
            Vector2 global = BodyPointToGlobal(obj, point);
            global.Y = -global.Y;
            Vector2 gridCenter = new Vector2(mGridCenterX, mGridCenterY);
            return gridCenter + (global * mGridZoom);
        }

        Vector2 BodyPointToScreenWithExtraRotation(SceneObject obj, int point, float extrarotation)
        {
            Vector2 global = BodyPointToGlobalWithExtraRotation(obj, point, extrarotation);
            global.Y = -global.Y;
            Vector2 gridCenter = new Vector2(mGridCenterX, mGridCenterY);
            return gridCenter + (global * mGridZoom);
        }

        Vector2 BodyOffsetPointToScreen(SceneObject obj, int point, Vector2 offset)
        {
            Vector2 global = obj.pos + offset + JellyPhysics.VectorTools.rotateVector((obj.body.Points[point].pos * obj.scale), MathHelper.ToRadians(obj.angle));
            global.Y = -global.Y;
            Vector2 gridCenter = new Vector2(mGridCenterX, mGridCenterY);
            return gridCenter + (global * mGridZoom);
        }
        
        Vector2 BodyOffsetPointToScreenWithExtraRotation(SceneObject obj, int point, Vector2 offset, float extrarotation)
        {
            Vector2 global = obj.pos + offset + JellyPhysics.VectorTools.rotateVector((obj.body.Points[point].pos * obj.scale), MathHelper.ToRadians(obj.angle + extrarotation));
            global.Y = -global.Y;
            Vector2 gridCenter = new Vector2(mGridCenterX, mGridCenterY);
            return gridCenter + (global * mGridZoom);
        }

        Vector2 PosToScreen(Vector2 global)
        {
            global.Y = -global.Y;
            Vector2 gridCenter = new Vector2(mGridCenterX, mGridCenterY);
            return gridCenter + (global * mGridZoom);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            mImage = pictureBox1.Image;
            mGraphics = Graphics.FromImage(mImage);

            redrawImage();
        }
        #endregion

        #region object settings - scene level
        private void checkBoxIsTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (mSelectedObject != -1)
            {
                mSceneObjects[mSelectedObject].isTrigger = checkBoxIsTrigger.Checked;

                buttonTriggerTarget.Enabled = checkBoxIsTrigger.Checked;

                redrawImage();
            }
        }

        private void checkBoxTriggerNoCam_CheckedChanged(object sender, EventArgs e)
        {
            if (mSelectedObject != -1)
            {
                mSceneObjects[mSelectedObject].triggerNoCam = checkBoxTriggerNoCam.Checked;
            }
        }

        private void checkBoxOverrideColor_CheckedChanged(object sender, EventArgs e)
        {
            if (mSelectedObject != -1)
            {
                mSceneObjects[mSelectedObject].hasCustomColor = checkBoxOverrideColor.Checked;
                buttonSceneColor.Enabled = checkBoxOverrideColor.Checked;

                Microsoft.Xna.Framework.Graphics.Color xnaColor = mSceneObjects[mSelectedObject].body.Color;
                if (checkBoxOverrideColor.Checked)
                    xnaColor = mSceneObjects[mSelectedObject].customColor;


                pictureBoxSceneColor.BackColor = System.Drawing.Color.FromArgb(255, xnaColor.R, xnaColor.G, xnaColor.B); ;
                pictureBoxSceneColor.Invalidate();
            }
        }

        private void buttonSceneColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color newColor = colorDialog1.Color;

                Microsoft.Xna.Framework.Graphics.Color xnaColor = new Microsoft.Xna.Framework.Graphics.Color(newColor.R, newColor.G, newColor.B, 255);
                mSceneObjects[mSelectedObject].customColor = xnaColor;

                pictureBoxSceneColor.BackColor = newColor;
                pictureBoxSceneColor.Invalidate();
                redrawImage();
            }
        }

        private void buttonTriggerTarget_Click(object sender, EventArgs e)
        {
            mChoosingTarget = true;
            toolStripMainStatus.Text = "Click on an object to set/unset the target.";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (mSelectedObject != -1)
                mSceneObjects[mSelectedObject].isPath = true;
            tabControlSceneObjectSettings.SelectedIndex = 1;

            redrawImage();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (mSelectedObject != -1)
                mSceneObjects[mSelectedObject].isPath = false;
            tabControlSceneObjectSettings.SelectedIndex = 0;

            redrawImage();
        }

        private void checkBoxClosedPath_CheckedChanged(object sender, EventArgs e)
        {
            if (mSelectedObject != -1)
            {
                mSceneObjects[mSelectedObject].pathClosed = checkBoxClosedPath.Checked;
                redrawImage();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mChoosingPathPlatform = true;
            toolStripMainStatus.Text = "Click on an object to set it to follow this path.";
        }

        private void buttonClearPathObjects_Click(object sender, EventArgs e)
        {
            if (mSelectedObject == -1)
                return;

            SceneObject path = mSceneObjects[mSelectedObject];

            foreach (SceneObject so in mSceneObjects)
            {
                // if this object is currently attached to this path, de-attach it.
                if (so.motionPlatformFollowPath == path)
                    so.motionPlatformFollowPath = null;
            }

            redrawImage();

            toolStripMainStatus.Text = "platforms attached to this path object removed.";
        }
        #endregion      

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // keyboard shortcuts!
            if (e.KeyChar == 'f')
            {
                // focus on selected object.
                if (mSelectedObject != -1)
                {
                    float ominx = 10000, omaxx = -10000, ominy = 10000, omaxy = -10000;
                    getObjectExtents(mSelectedObject, ref ominx, ref omaxx, ref ominy, ref omaxy);

                    Vector2 center = new Vector2(ominx + (omaxx - ominx) * 0.5f, ominy + (omaxy - ominy) * 0.5f);

                    float xsize = omaxx - ominx;
                    float ysize = omaxy - ominy;

                    float xzoom = (pictureBox1.Width) / (xsize * 1.4f);
                    float yzoom = (pictureBox1.Height) / (ysize * 1.4f);
                    mGridZoom = Math.Min(xzoom, yzoom);


                    Vector2 screenPos = PosToScreen(center);

                    // move this to the center of the screen...
                    Vector2 goalPos = new Vector2(pictureBox1.Width / 2, pictureBox1.Height / 2);

                    Vector2 delta = goalPos - screenPos;
                    mGridCenterX += delta.X;
                    mGridCenterY += delta.Y;


                    redrawImage();
                }
                else
                {
                    // center entire scene
                    float minX = 10000;
                    float maxX = -10000;
                    float minY = 10000;
                    float maxY = -10000;

                    for (int i = 0; i < mSceneObjects.Count; i++)
                        getObjectExtents(i, ref minX, ref maxX, ref minY, ref maxY);

                    float xsize = maxX - minX;
                    float ysize = maxY - minY;

                    float xzoom = (pictureBox1.Width) / (xsize * 1.4f);
                    float yzoom = (pictureBox1.Height) / (ysize * 1.4f);
                    mGridZoom = Math.Min(xzoom, yzoom);

                    Vector2 midPt = PosToScreen(new Vector2(minX + (maxX - minX) * 0.5f, minY + (maxY - minY) * 0.5f));

                    // move this to the center of the screen...
                    Vector2 goalPos = new Vector2(pictureBox1.Width / 2, pictureBox1.Height / 2);

                    Vector2 delta = goalPos - midPt;
                    mGridCenterX += delta.X;
                    mGridCenterY += delta.Y;

                    redrawImage();
                }
            }
            
        }

        protected void getObjectExtents(int index, ref float minX, ref float maxX, ref float minY, ref float maxY)
        {
            for (int i = 0; i < mSceneObjects[index].body.Points.Count; i++)
            {
                Vector2 pos = BodyPointToGlobal(mSceneObjects[index], i);
                if (pos.X < minX) { minX = pos.X; }
                if (pos.X > maxX) { maxX = pos.X; }
                if (pos.Y < minY) { minY = pos.Y; }
                if (pos.Y > maxY) { maxY = pos.Y; }
            }
        }

        private void saveTestFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"C:\Users\adam\Downloads\testttt\test.txt", "test");
        }

        private void printSelectedSBToConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameBody body = mSceneObjects[mSelectedObject].body;
            Console.WriteLine(body.returnXml("a"));
        }

        private void printAllSBsToConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mSceneBodies.Count; i++)
            {
                GameBody body = mSceneBodies[i];
                Console.WriteLine(body.returnXml("a"));
            }
        }

        private void checkIfConfigFileExistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\config.xml";
            if(File.Exists(path))
            {
                Console.WriteLine("config.xml does indeed exist.");
            }
            else
            {
                Console.WriteLine("config.xml does NOT exist.");
            }
        }

        /*public void writeConfigXml(string lightTheme, string showSaveBeforeExitDialog)
        {
            // 1800

            string configXmlPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\config.xml";

            XmlDocument doc = new XmlDocument();
            XmlElement r = doc.CreateElement("Root");
            XmlElement root = doc.CreateElement("JE3Config");

            root.SetAttribute("lightTheme", lightTheme);
            root.SetAttribute("showSaveBeforeExitDialog", showSaveBeforeExitDialog);

            doc.AppendChild(root);
            doc.AppendChild(r);
            doc.Save(configXmlPath);
        }*/

        /*public bool ReadConfigXml(string pref)
        {
            // 268

            string prefValue;

            XmlDocument doc = new XmlDocument();
            doc.Load(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\config.xml");

            XmlNodeList root = doc.GetElementsByTagName("JE3Config");
            //Console.WriteLine(root.);

            /*if (root.HasAttribute(pref))
            {
                prefValue = root.GetAttribute(pref);
                if (prefValue == "True")
                {
                    prefValueBool = true;
                }
                else
                {
                    prefValueBool = false;
                }
            }
            else
            {
                prefValueBool = false;
            }
            return prefValueBool;
        }*/
        
        private void Form1_Load(object sender, EventArgs e)
        {
            /*if(!File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\config.xml"))
            {
                writeConfigXml("True", "True");
            }
            else
            {
                //Console.WriteLine(ReadConfigXml("lightTheme"));
                //lightMode = ReadConfigXml("lightTheme");
            }*/
        }

        private void printCurrentThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lightMode)
                Console.WriteLine("light");
            else
                Console.WriteLine("dark");
        }

        private void addPresetObj(string presetName, string name, bool addBody)
        {
            GameBody body = new GameBody(name, presetName);

            SceneObject obj = new SceneObject();
            obj.body = body;
            if (presetName == "goal" && name == "goal")
                obj.angle = 22.5f;

            if (addBody)
            {
                mSceneBodies.Add(body);
                mBodyCount++;
            }

            mSceneObjects.Add(obj);

            selectObject(mSceneObjects.Count - 1);

            updateObjectTransformation();
            updateSceneTree();
            redrawImage();
        }

        private void goalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!goalInLevel)
            {
                addPresetObj("goal", "goal", true);
                goalInLevel = true;
            }
            else
            {
                addPresetObj("goal", "goal", false);
            }
        }

        private void secretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!secretInLevel)
            {
                addPresetObj("goal", "secret", true);
                secretInLevel = true;
            }
            else
            {
                addPresetObj("goal", "secret", false);
            }
        }

        private void stickyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!stickyInLevel)
            {
                addPresetObj("goal", "sticky", true);
                stickyInLevel = true;
            }
            else
            {
                addPresetObj("goal", "sticky", false);
            }
        }

        private void balloonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!balloonInLevel)
            {
                addPresetObj("goal", "balloon", true);
                balloonInLevel = true;
            }
            else
            {
                addPresetObj("goal", "balloon", false);
            }
        }

        private void itemstickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!itemstickInLevel)
            {
                addPresetObj("jc2sticky", "itemstick", true);
                itemstickInLevel = true;
            }
            else
            {
                addPresetObj("jc2sticky", "itemstick", false);
            }
        }

        private void itemballoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!itemballoonInLevel)
            {
                addPresetObj("jc2balloon", "itemballoon", true);
                itemballoonInLevel = true;
            }
            else
            {
                addPresetObj("jc2balloon", "itemballoon", false);
            }
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float aaaa = 192 / 255;
            Console.WriteLine(aaaa);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mAbout.ShowDialog();
        }

        private void drawPolysInSceneEditModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redrawImage();
        }

        private void decompileAndOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Scene Files|*.scene|Xml Files|*.xml";
            openFileDialog1.Title = "Open scene to decompile...";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sceneFile = openFileDialog1.FileName;
                decompAndOpenScene(openFileDialog1.FileName);
            }
        }

        private void printSceneNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Console.WriteLine(mSceneSettings.SceneName);
        }

        private void attractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SceneObject obj = mSceneObjects[mSelectedObject];

            for (int i = 0; i < obj.body.Points.Count; i++)
            {
                obj.body.Points[i].pos.X = obj.body.Points[i].pos.X / 3.1f;
                obj.body.Points[i].pos.Y = obj.body.Points[i].pos.Y / 3.1f;
                redrawImage();
            }
        }

        private void enlargeSoftbodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SceneObject obj = mSceneObjects[mSelectedObject];

            for (int i = 0; i < obj.body.Points.Count; i++)
            {
                obj.body.Points[i].pos.X = obj.body.Points[i].pos.X * 2.65f;
                obj.body.Points[i].pos.Y = obj.body.Points[i].pos.Y * 2.65f;
                redrawImage();
            }
        }

        private void moveSBLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SceneObject obj = mSceneObjects[mSelectedObject];

            for (int i = 0; i < obj.body.Points.Count; i++)
            {
                obj.body.Points[i].pos.X = obj.body.Points[i].pos.X - 0.1f;
                redrawImage();
            }
        }

        private void moveSBDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SceneObject obj = mSceneObjects[mSelectedObject];

            for (int i = 0; i < obj.body.Points.Count; i++)
            {
                obj.body.Points[i].pos.Y = obj.body.Points[i].pos.Y - 0.1f;
                redrawImage();
            }
        }

        private void moveSBLeftlessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SceneObject obj = mSceneObjects[mSelectedObject];

            for (int i = 0; i < obj.body.Points.Count; i++)
            {
                obj.body.Points[i].pos.X = obj.body.Points[i].pos.X - 0.05f;
                redrawImage();
            }
        }

        private void editSpecialMassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // set the mass settings for this bad boy.
            mSpecialMass.Mass = mSceneObjects[mSelectedObject].body.Points[mSelectedPoint].mass;
            if (mSpecialMass.ShowDialog() == DialogResult.OK)
            mSceneObjects[mSelectedObject].body.Points[mSelectedPoint].mass = mSpecialMass.Mass;
        }

        private void toggleEditorThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lightMode)
            {
                lightMode = false;
            }
            else
            {
                lightMode = true;
            }
            redrawImage();
        }

        private void tabControlSceneObjectSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlSceneObjectSettings.SelectedIndex)
            {
                case 0:
                    if (mSceneObjects[mSelectedObject].isPath)
                    {
                        MessageBox.Show("Selected object is a path, must use \"Path\" tab!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControlSceneObjectSettings.SelectedIndex = 1;
                    }
                    break;
                case 1:
                    if (!mSceneObjects[mSelectedObject].isPath)
                    {
                        MessageBox.Show("Selected object is not a path, must use \"Scene Object\" tab!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControlSceneObjectSettings.SelectedIndex = 0;
                    }
                    break;
            }
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            SceneObject obj = mSceneObjects[mSelectedObject];
            int newIndex = mSelectedObject - 1;
            mSceneObjects.RemoveAt(mSelectedObject);
            mSceneObjects.Insert(newIndex, obj);
            selectObject(newIndex);
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            SceneObject obj = mSceneObjects[mSelectedObject];
            int newIndex = mSelectedObject + 1;
            mSceneObjects.RemoveAt(mSelectedObject);
            mSceneObjects.Insert(newIndex, obj);
            selectObject(newIndex);
        }
    }
}
#endregion