using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;



namespace Serialize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //save information into a XML file (Release folder)
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Data info = new Data();
                info.Name = textBoxName.Text;
                info.Address = textBoxAddress.Text;
                info.Phone = textBoxPhone.Text;
                SaveToXml.SerializeObject(info, "data.xml");
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Data));
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Data info = (Data)xs.Deserialize(read);
                textBoxName.Text = info.Name;
                textBoxAddress.Text = info.Address;
                textBoxPhone.Text = info.Phone;
                read.Close();
            }
        }
    }
}
