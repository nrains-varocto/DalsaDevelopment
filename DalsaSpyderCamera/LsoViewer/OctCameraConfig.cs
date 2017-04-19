using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Varocto.Cameras;

namespace LsoViewer
{
    public partial class OctCameraConfig : Form
    {
        OctoplusCamera octCamera;

        public OctCameraConfig(OctoplusCamera OctCamera)
        {
            octCamera = OctCamera;
            if (octCamera == null)
                MessageBox.Show("OctoplusCamera is null");
            else
            { 
                InitializeComponent();
                fillTriggerComboBox();
                fillTestPatternComboBox();
            }
        }

        private void fillTriggerComboBox()
        {
            triggerModeComboBox.Items.Add(TriggerModes.InteralProgrammbleMaxExposureTimeLinePeriod.ToString());
            triggerModeComboBox.Items.Add(TriggerModes.InternalMaxExposureTimeProgrammablePeriod.ToString());
            triggerModeComboBox.Items.Add(TriggerModes.ExternalProgrammableMaxExposure.ToString());
            triggerModeComboBox.Items.Add(TriggerModes.ExternalMaxExposureTime.ToString());

            triggerModeComboBox.SelectedIndex = 0;
        }

        private void fillTestPatternComboBox()
        {
            testPatterComboBox.Items.Add(TestPattern.Off.ToString());
            testPatterComboBox.Items.Add(TestPattern.GreyHorizontalRamp.ToString());
            testPatterComboBox.Items.Add(TestPattern.GreyVerticalRamp.ToString());
            testPatterComboBox.Items.Add(TestPattern.GreyDiagonalRamp.ToString());
            testPatterComboBox.Items.Add(TestPattern.MovingGreyHorizontalRamp.ToString());
            testPatterComboBox.Items.Add(TestPattern.MovingGreyVerticalRamp.ToString());
            testPatterComboBox.Items.Add(TestPattern.MovingGreyDiagonalRamp.ToString());
            testPatterComboBox.Items.Add(TestPattern.CheckerBoard.ToString());
            testPatterComboBox.Items.Add(TestPattern.ConstantPattern.ToString());

            testPatterComboBox.SelectedIndex = 0;

        }

        private void widthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b') //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(widthTextBox.Text);
            if (value > 2048 || value < 0)
                octCamera.RoiSensorWidth = value.ToString();
                
        }

        private void testPatterComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            octCamera.SetTestPattern(testPatterComboBox.SelectedIndex);
        }

        private void triggerModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = triggerModeComboBox.SelectedIndex;
            if (value == 0)
            {
                octCamera.SetTriggerMode(false, true);
            }
            else if (value == 1)
            {
                octCamera.SetTriggerMode(false, false);
            }
            else if (value == 2)
                octCamera.SetTriggerMode(true, true);
            else if (value == 3)
                octCamera.SetTriggerMode(true, false);                
        }
    }
}
