using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfflineEditor.Export;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Controls;
using System.Xml;
using System.Diagnostics;

namespace OfflineEditor
{
    public partial class MainDialog : Form
    {

        List<GameObject> listOfObjects;
        Viewport3D sceneView;

        public MainDialog()
        {
            InitializeComponent();
            listOfObjects = new List<GameObject>();

            sceneView = new Viewport3D();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Export.Type selectedType;
            switch (typeSelection.SelectedValue)
            {
                case "Sphere":
                    selectedType = Export.Type.Sphere;
                    break;
                default:
                    selectedType = Export.Type.Sphere;
                    break;
            }

            float x, y, z;
            x = float.Parse(locationX.Text);
            y = float.Parse(locationY.Text);
            z = float.Parse(locationZ.Text);
            Vec3 location = new Vec3(x, y, z);

            int radius = (int) formRadius.Value;
            int reflectivity = (int) formReflectivity.Value;
            double transparancy = (double) formTransparancy.Value;

            Vec3 surfaceColour = new Vec3(float.Parse(textColourR.Text), float.Parse(textColourG.Text), float.Parse(textColourB.Text));

            GameObject newGameObject = new GameObject(selectedType, location, radius, surfaceColour, transparancy, reflectivity);

            listOfObjects.Add(newGameObject);

            refreshList();
        }

        private void refreshList()
        {
            objectList.Items.Clear();

            int i = 1;
            foreach (GameObject go in listOfObjects)
            {
                System.Windows.Forms.ListViewItem lvi = objectList.Items.Add("" + i);
                lvi.SubItems.Add(go.m_ObjectType.ToString());
                lvi.SubItems.Add(go.m_Position.ToString());
                lvi.SubItems.Add(go.m_Radius.ToString());
                lvi.SubItems.Add(go.m_SurfaceColour.ToString());
                lvi.SubItems.Add(go.m_Reflectivity.ToString());
                lvi.SubItems.Add(go.m_Transparancy.ToString());

                i++;
            }
        }

        private void SerializeDataSet(string scene_name)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataSet));
            

            // Creates a DataSet; adds a table, column, and ten rows.  
            DataSet dataset_Scene = new DataSet("Scene");

            DataTable t_SceneSettings = new DataTable("Settings");
            DataColumn c_SceneFrames = new DataColumn("NumberOfFrames");
            DataColumn c_SceneWidth = new DataColumn("SceneWidth");
            DataColumn c_SceneHeight = new DataColumn("SceneHeight");
            DataColumn c_UseMultiThreading = new DataColumn("MultiThreading");
            DataColumn c_CameraX = new DataColumn("CameraX");
            DataColumn c_CameraY = new DataColumn("CameraY");
            DataColumn c_CameraZ = new DataColumn("CameraZ");
            DataColumn c_NotionOfTime = new DataColumn("NotionOfTime");

            t_SceneSettings.Columns.Add(c_SceneFrames);
            t_SceneSettings.Columns.Add(c_SceneWidth);
            t_SceneSettings.Columns.Add(c_SceneHeight);
            t_SceneSettings.Columns.Add(c_UseMultiThreading);
            t_SceneSettings.Columns.Add(c_CameraX);
            t_SceneSettings.Columns.Add(c_CameraY);
            t_SceneSettings.Columns.Add(c_CameraZ);
            t_SceneSettings.Columns.Add(c_NotionOfTime);

            DataRow settingsrow = t_SceneSettings.NewRow();
            settingsrow[0] = numberOfFrames.Value;
            settingsrow[1] = resolutionWidth.Value;
            settingsrow[2] = resolutionHeight.Value;
            int useThreading = 0;
            if (useMultiThreading.Checked)
                useThreading = 1;
            settingsrow[3] = useThreading;
            settingsrow[4] = int.Parse(cameraX.Text);
            settingsrow[5] = int.Parse(cameraY.Text);
            settingsrow[6] = int.Parse(cameraZ.Text);
            int useTime = 0;
            if (useNotionOfTime.Checked)
                useTime = 1;
            settingsrow[7] = useTime;
            t_SceneSettings.Rows.Add(settingsrow);

            DataTable t_GameObjects = new DataTable("GameObject");

            DataColumn c_Type = new DataColumn("Type");
            DataColumn c_X = new DataColumn("X");
            DataColumn c_Y = new DataColumn("Y");
            DataColumn c_Z = new DataColumn("Z");

            DataColumn c_Radius = new DataColumn("Radius");
            DataColumn c_Reflectivity = new DataColumn("Reflectivity");
            DataColumn c_Transparency = new DataColumn("Transparency");

            DataColumn c_ColourR = new DataColumn("ColourR");
            DataColumn c_ColourG = new DataColumn("ColourG");
            DataColumn c_ColourB = new DataColumn("ColourB");

            t_GameObjects.Columns.Add(c_Type);
            t_GameObjects.Columns.Add(c_X);
            t_GameObjects.Columns.Add(c_Y);
            t_GameObjects.Columns.Add(c_Z);
            t_GameObjects.Columns.Add(c_Radius);
            t_GameObjects.Columns.Add(c_Reflectivity);
            t_GameObjects.Columns.Add(c_Transparency);
            t_GameObjects.Columns.Add(c_ColourR);
            t_GameObjects.Columns.Add(c_ColourG);
            t_GameObjects.Columns.Add(c_ColourB);

            dataset_Scene.Tables.Add(t_GameObjects);
            dataset_Scene.Tables.Add(t_SceneSettings);

            DataRow r_GameObject;
            
            foreach (GameObject go in listOfObjects)
            {

                r_GameObject = t_GameObjects.NewRow();

                r_GameObject[0] = go.m_ObjectType.ToString();
                r_GameObject[1] = go.m_Position.x;
                r_GameObject[2] = go.m_Position.y;
                r_GameObject[3] = go.m_Position.z;
                r_GameObject[4] = go.m_Radius;
                r_GameObject[5] = go.m_Reflectivity;
                r_GameObject[6] = go.m_Transparancy;
                r_GameObject[7] = go.m_SurfaceColour.x;
                r_GameObject[8] = go.m_SurfaceColour.y;
                r_GameObject[9] = go.m_SurfaceColour.z;

                t_GameObjects.Rows.Add(r_GameObject);
            }
            Console.WriteLine(dataset_Scene.GetXml());

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.OmitXmlDeclaration = true;
            //settings.ConformanceLevel = ConformanceLevel.Fragment;

            //XmlWriter writer = XmlWriter.Create("./Exported_Scene.xml", settings);

            //ser.Serialize(writer, dataset_Scene);
            //writer.Close();
            StreamWriter stringWriter = new StreamWriter("./Exported_Scene.xml");
            stringWriter.Write(dataset_Scene.GetXml());
            stringWriter.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SerializeDataSet("Scene");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = colorDialog1.Color;
                textColourR.Text = (((int)colorDialog1.Color.R) / 255f).ToString();
                textColourG.Text = (((int)colorDialog1.Color.G) / 255f).ToString();
                textColourB.Text = (((int)colorDialog1.Color.B) / 255f).ToString();
            }

            
        }

        private void cameraY_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SerializeDataSet("Scene");
            Process process = Process.Start(@"RayTracerSmall.exe");
        }
    }
}
