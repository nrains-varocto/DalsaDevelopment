using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

using DALSA.SaperaLT.SapClassBasic;


namespace DALSA.SaperaLT.SapClassGui
{

    public partial class AcqConfigDlg : Form
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        static string ConfigKeyName     = "Camera Name";
        static string CompanyKeyName    = "Company Name";
        static string ModelKeyName      = "Model Name";
        static string VicName           = "Vic Name";
        static string Acquisition_Default_folder = "\\CamFiles\\User";

        public AcqConfigDlg()
        {
            InitializeComponent();
        }

        public AcqConfigDlg(ServerCategory serverCategory)
        {
            m_ServerCategory = serverCategory;
            // Load parameters from registry
	        LoadSettings();
            InitializeComponent();
        }


        public AcqConfigDlg(SapLocation loc, string productDir, ServerCategory serverCategory)
        {
           m_ProductDir = productDir;
           m_ServerCategory = serverCategory;

           if (loc != null)
           {
               m_ServerName = loc.ServerName;
               m_ResourceIndex = loc.ServerIndex;
           }
           // Load parameters from registry
           LoadSettings();
           InitializeComponent();
           
        }

        private void comboBox_Server_SelectedIndexChanged(object sender, EventArgs e)
        {
	        if(m_init)
            {
                InitResourceCombo();
	            UpdateNames();
	            UpdateBoxAvailability();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize Servers Combo
            if (!InitServerCombo())
            {
                this.Close();
            }
            else
            {
                // Initialize directories
                SetDirectories();
                // Scan all files in the current directory and fill the list box
                UpdateNames();
            }
            m_init = true;
        }

        private bool InitServerCombo()
        {
            comboBox_Server.Items.Clear();
            for (int i = 0; i < SapManager.GetServerCount(); i++)
	        {
		        // Does this server support "Acq" (frame-grabber) or "AcqDevice" (camera)?
                bool bAcq = (m_ServerCategory == ServerCategory.ServerAcq || m_ServerCategory == ServerCategory.ServerAll) &&
                           (SapManager.GetResourceCount(i, SapManager.ResourceType.Acq) > 0);
                bool bAcqDevice = (m_ServerCategory == ServerCategory.ServerAcqDevice || m_ServerCategory == ServerCategory.ServerAll) &&
                            (SapManager.GetResourceCount(i, SapManager.ResourceType.AcqDevice) > 0);

                if (bAcq)
	            {
                    string serverName = SapManager.GetServerName(i);
                    comboBox_Server.Items.Add(new MyListBoxItem(serverName, true));
                }
                else if (bAcqDevice)
                {
                    string serverName = SapManager.GetServerName(i);
                    if (serverName.Contains("CameraLink_") == false)
                     comboBox_Server.Items.Add(new MyListBoxItem(serverName, false));
                }
	        }
           if (comboBox_Server.Items.Count <= 0)
           {
              return false;
            }
            else
            {   
                if (string.IsNullOrEmpty(m_ServerName) || comboBox_Server.FindString(m_ServerName, 0) == -1)
                {
                    comboBox_Server.SelectedIndex = 0;
                    m_ServerName = comboBox_Server.SelectedItem.ToString();
                }
                else
                    comboBox_Server.SelectedIndex = comboBox_Server.FindString(m_ServerName, 0);
                
                InitResourceCombo();
                return true;
            }
        }

        private void InitResourceCombo()
        {
            comboBox_Device.Items.Clear();
	        int i=0;
            Object selectedItem = comboBox_Server.SelectedItem;
            // Add "Acq" resources (cameras) to combo
	        for (i=0; i < SapManager.GetResourceCount(selectedItem.ToString(), SapManager.ResourceType.Acq); i++)
	        {
                string resourceName = SapManager.GetResourceName(selectedItem.ToString(), SapManager.ResourceType.Acq, i);
                if (SapManager.IsResourceAvailable(selectedItem.ToString(), SapManager.ResourceType.Acq, i))
                {
                    comboBox_Device.Items.Add(resourceName);
                    if (i == m_ResourceIndex)
                        comboBox_Device.SelectedItem = resourceName;
                }
                else
                {
                    comboBox_Device.Items.Add("Not Available - Resource in Use");
                    comboBox_Device.SelectedIndex = 0;
                }
	        }
	        // Add "AcqDevice" resources (cameras) to combo
            if (SapManager.GetResourceCount(selectedItem.ToString(), SapManager.ResourceType.Acq) == 0)
            {
                for (i = 0; i < SapManager.GetResourceCount(selectedItem.ToString(), SapManager.ResourceType.AcqDevice); i++)
                {
                    string resourceName;
                    resourceName = SapManager.GetResourceName(selectedItem.ToString(), SapManager.ResourceType.AcqDevice, i);
                    comboBox_Device.Items.Add(resourceName);
                    if (i == m_ResourceIndex)
                        comboBox_Device.SelectedItem = resourceName;
                }
            }
            m_ResourceIndex = comboBox_Device.SelectedIndex;
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.Description = "Select a directory.";
            this.folderBrowserDialog1.SelectedPath = m_currentConfigDir;
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(this.folderBrowserDialog1.SelectedPath))
                    UpdateCurrentDir(folderBrowserDialog1.SelectedPath);
                int countItems = comboBox_configfile.Items.Count;
                comboBox_configfile.Items.Clear();
                UpdateNames();
            }
        }

        private void UpdateCurrentDir(string newCurrentDir)
        {
            if (string.Compare(newCurrentDir, m_currentConfigDir, StringComparison.Ordinal) != 0)
            {
                textBox_configfile.Text = newCurrentDir;
                m_currentConfigDir = newCurrentDir;
            }
        }

        private void LoadSettings()
        {
            String KeyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapAcquisition";
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(KeyPath);
            if(RegKey != null) 
            {
                // Read location (server and resource) and file name
                m_ServerName    = RegKey.GetValue("Server","").ToString();
                m_ResourceIndex = (int)RegKey.GetValue("Resource",0);
                if (File.Exists(RegKey.GetValue("ConfigFile", "").ToString()))
                    m_ConfigFile = RegKey.GetValue("ConfigFile", "").ToString();
            }
        }

        private void SaveSettings()
        {
            String KeyPath = "Software\\Teledyne DALSA\\" + Application.ProductName + "\\SapAcquisition";
            RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(KeyPath);
            // Write config file name and location (server and resource)
            RegKey.SetValue("Server", m_ServerName);
            RegKey.SetValue("ConfigFile", m_ConfigFile);
            RegKey.SetValue("Resource", m_ResourceIndex);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            m_ConfigFileEnable = checkBox_configfile.Checked;
            UpdateNames();
        }

        private void UpdateNames()
        {
            //Delete ccf name file list 
            ccffiles.Clear();

            string currentDir = m_currentConfigDir;
            string keyName = ConfigKeyName;
            string curServerName = comboBox_Server.SelectedItem.ToString();
            m_ResourceIndex = comboBox_Device.SelectedIndex;
            m_ServerName = curServerName;
            curServerName = curServerName.Substring(0, curServerName.Length - 2);

            DirectoryInfo dir = new DirectoryInfo(currentDir);
            if (dir.Exists)
            {
               FileInfo[] ccffileInfo = dir.GetFiles("*.ccf");
               comboBox_configfile.Items.Clear(); 

               foreach (FileInfo f in ccffileInfo)
               {
                  string filePath = m_currentConfigDir + "\\" + f.Name;
                  StringBuilder tempServerName = new StringBuilder(512);
                  StringBuilder sbCameraName = new StringBuilder(512);
                  StringBuilder sbCompanyName = new StringBuilder(512);
                  StringBuilder sbModelName = new StringBuilder(512);
                  StringBuilder sbVicName = new StringBuilder(512);
                  string companyName = "";
                  string modelName = "";
                  string cameraDesc = "";

                  GetPrivateProfileString("Board", "Server name", "Unknow", tempServerName, 512, filePath);

                  // Check if the current configuration file has been created for the current server 
                  if (string.Compare(curServerName, tempServerName.ToString(), StringComparison.OrdinalIgnoreCase) != 0)
                     continue;
                  // Add ccf File name
                  ccffiles.Add(f.Name);

                  GetPrivateProfileString("General", keyName, "Unknown", sbCameraName, 512, filePath);
                  GetPrivateProfileString("General", CompanyKeyName, "", sbCompanyName, 512, filePath);
                  GetPrivateProfileString("General", ModelKeyName, "", sbModelName, 512, filePath);
                  GetPrivateProfileString("General", VicName, "", sbVicName, 512, filePath);

                  if (sbCompanyName.ToString().Length != 0 && sbModelName.ToString().Length != 0)
                     companyName = sbCompanyName.ToString() + ", ";
                  if (sbModelName.ToString().Length != 0 && sbCameraName.ToString().Length != 0)
                     modelName = sbModelName.ToString() + ", ";

                  cameraDesc = companyName + modelName + sbCameraName.ToString() + " - " + sbVicName.ToString();


                  MyListBoxItem item = new MyListBoxItem(cameraDesc, true);
                  comboBox_configfile.Items.Add(item);
               }
           }

	        if (comboBox_configfile.Items.Count != 0)
	        {
                m_configFileAvailable = true;
                int newFileIndex = 0;
                
                // Try to find the current camera file selected
                for(int i =0; i<ccffiles.Count;i++)
                {
                    String currentccf = (String)ccffiles[i];
                    if (string.Compare(m_currentConfigFileName, currentccf, StringComparison.Ordinal) == 0)
                        newFileIndex = i;
                }
                comboBox_configfile.SelectedIndex = newFileIndex;
                
	        }
	        else
	        {
                m_configFileAvailable = false;
	        }
            UpdateBoxAvailability();
        }


        private void UpdateBoxAvailability()
        {
            // Is config file is required by this type of server?
            MyListBoxItem item = (MyListBoxItem)comboBox_Server.SelectedItem;
            bool configFileRequired = item.ItemData;
            checkBox_configfile.Enabled = !configFileRequired;

            if (configFileRequired)
            {
                m_ConfigFileEnable = configFileRequired;
                checkBox_configfile.Checked = configFileRequired;
            }
            else
                m_ConfigFileEnable = checkBox_configfile.Checked;

            comboBox_configfile.Enabled = (m_ConfigFileEnable && m_configFileAvailable);
            textBox_configfile.Enabled = (m_ConfigFileEnable);
            button_browse.Enabled = (m_ConfigFileEnable);
            button_ok.Enabled = !m_ConfigFileEnable || m_configFileAvailable;         
        }

        private void SetDirectories()
        {            
            string productDirectory = "";
            
            if (!string.IsNullOrEmpty(m_ProductDir))
                productDirectory = Environment.GetEnvironmentVariable(m_ProductDir);
        	
            string saperaDir = Environment.GetEnvironmentVariable("SAPERADIR");

            if (m_ConfigFile.Length != 0)
            {
                m_currentConfigDir = System.IO.Path.GetDirectoryName(m_ConfigFile);
                m_currentConfigFileName = System.IO.Path.GetFileName(m_ConfigFile);
                textBox_configfile.Text = m_currentConfigDir;
            }
            else
            {
                m_currentConfigFileName = "";
                if (!string.IsNullOrEmpty(productDirectory))
                    m_currentConfigDir = productDirectory;
                else if (saperaDir.Length != 0)
                    m_currentConfigDir = saperaDir + Acquisition_Default_folder;
                textBox_configfile.Text = m_currentConfigDir;
            } 
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (checkBox_configfile.Checked)
                m_ConfigFile = m_currentConfigDir + "\\" + m_currentConfigFileName;
            else
                m_ConfigFile = "";

            if (m_ServerCategory == ServerCategory.ServerAll)
            {
                if (SapManager.GetResourceCount(new SapLocation(m_ServerName, m_ResourceIndex), SapManager.ResourceType.Acq) > 0)
                    m_ServerCategory = ServerCategory.ServerAcq;
                else if (SapManager.GetResourceCount(new SapLocation(m_ServerName, m_ResourceIndex), SapManager.ResourceType.AcqDevice) > 0)
                    m_ServerCategory = ServerCategory.ServerAcqDevice;
            }
            SaveSettings();
        }

      
        private void comboBox_configfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_currentConfigFileIndex = comboBox_configfile.SelectedIndex;
            m_currentConfigFileName = (String)ccffiles[m_currentConfigFileIndex];
        }

        private void comboBox_Device_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_init)
                UpdateNames();
        }

        /// <summary>
        /// Property of the form 
        /// </summary>
        public string ConfigFile
        {
            get 
            {
                if (m_ConfigFileEnable)
                    return m_ConfigFile;
                else
                    return "";
            }
        }

        public ServerCategory ServCategory
        {
            get
            {
                return m_ServerCategory;
            }
        }

        public SapLocation ServerLocation
        {
            get {return new SapLocation(m_ServerName, m_ResourceIndex);}
        }

        /// <summary>
        /// Enum of server category
        /// </summary>

        public enum ServerCategory
        {
            ServerAll,
            ServerAcq,
            ServerAcqDevice
        };

        /// <summary>
        /// Class to handle listbox item
        /// </summary>
        class MyListBoxItem
        {
            public MyListBoxItem(string Text)
            {
                Camdesc = Text;
                itemData = false;
            }

            public MyListBoxItem(string Text, bool ItemData)
            {
                Camdesc = Text;
                itemData = ItemData;
            }

            public bool ItemData
            {
                get
                {
                    return itemData;
                }
                set
                {
                    itemData = value;
                }
            }

            public override string ToString()
            {
                return Camdesc;
            }

            private string Camdesc;
            private bool itemData;
        }

    }




}