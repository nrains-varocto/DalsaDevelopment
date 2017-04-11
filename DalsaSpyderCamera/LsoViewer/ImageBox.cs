using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DALSA.SaperaLT.SapClassBasic;

namespace DALSA.SaperaLT.SapClassGui
{
    public partial class ImageBox : UserControl
    {

        private PictureBox picBox;
        private VScrollBar vScroll;
        private HScrollBar hScroll;
        protected TrackBar Slider;
        protected SapView m_pView;
        private Rectangle tracker;
        private Rectangle recTracker;
        private bool mouseDown = false;
        private bool useRoi = false;
        private bool useSlider = false;
        private Point StartPoint;
        private Point EndPoint;
        private ToolStripLabel pixelValueDispaly;
        private int LastvScrollValue, LasthScrollValue;
       private int SliderOffset, RightOffset, BottomOffset;
        
        public ImageBox()
        {
           InitializeComponent();
           picBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
           picBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseUp);
           picBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseMove);
           vScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScroll_Scroll);
           hScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScroll_Scroll);
           Slider.Scroll += new System.EventHandler(this.Slider_Scroll);

           mouseDown = false;
           useRoi = false;
           useSlider = false;
           // Set offset Value 
           RightOffset = 5;
           BottomOffset = 5;
           SliderOffset = 0;
           // Default : Slider is hide
           Slider.Hide();
           // Constant size's part of scrollbar 
           hScroll.Height = 15;
           vScroll.Width = 15;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
           if (m_pView != null && m_pView.Initialized)
           {
                FitImageBoxToBottomRight();
                UpdateScrollBars();
                m_pView.OnPaint();
                DisplayTracker();
           }
           base.OnPaint(e);   
        }

        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (useRoi)
            {
                mouseDown = true;
                StartPoint = new Point(e.X, e.Y);
            }
        }

        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (useRoi)
            {
                if (mouseDown)
                {
                    EndPoint = new Point(e.X, e.Y);
                    if (StartPoint.X > EndPoint.X)
                    {
                        if (StartPoint.Y > EndPoint.Y)
                            tracker = new Rectangle(EndPoint.X, EndPoint.Y, StartPoint.X - EndPoint.X, StartPoint.Y - EndPoint.Y);
                        else
                            tracker = new Rectangle(EndPoint.X, StartPoint.Y, StartPoint.X - EndPoint.X, EndPoint.Y - StartPoint.Y);
                    }
                    else
                    {
                        if (StartPoint.Y > EndPoint.Y)
                            tracker = new Rectangle(StartPoint.X, EndPoint.Y, EndPoint.X - StartPoint.X, StartPoint.Y - EndPoint.Y);
                        else
                            tracker = new Rectangle(StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
                    }
                    this.Refresh();
                }
            }
           // Pixel value over the cursor
           if(pixelValueDispaly!= null)
               pixelValueDispaly.Text = GetPixelString(new Point(e.X,e.Y));

        }

        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (useRoi)
            {
                EndPoint = new Point(e.X, e.Y);
                if (StartPoint.X > EndPoint.X)
                {
                    if (StartPoint.Y > EndPoint.Y)
                        tracker = new Rectangle(EndPoint.X, EndPoint.Y, StartPoint.X - EndPoint.X, StartPoint.Y - EndPoint.Y);
                    else
                        tracker = new Rectangle(EndPoint.X, StartPoint.Y, StartPoint.X - EndPoint.X, EndPoint.Y - StartPoint.Y);
                }
                else
                {
                    if (StartPoint.Y > EndPoint.Y)
                        tracker = new Rectangle(StartPoint.X, EndPoint.Y, EndPoint.X - StartPoint.X, StartPoint.Y - EndPoint.Y);
                    else
                        tracker = new Rectangle(StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
                }
               
                // If drawn tracker is not empty copy to recTracker 
                if (tracker.Height != 0 && tracker.Width != 0)
                    recTracker = new Rectangle(tracker.X + hScroll.Value, tracker.Y + vScroll.Value, tracker.Width, tracker.Height);
                else
                    recTracker = new Rectangle(0, 0, 0, 0);
        
                mouseDown = false;

                // Save current position of scroll bar
                LasthScrollValue = hScroll.Value;
                LastvScrollValue = vScroll.Value;
                this.Refresh();
            }
        }

        private void vScroll_Scroll(object sender, ScrollEventArgs e)
        {
           // Update view and tracker
           if (m_pView != null && m_pView.Initialized)
              m_pView.OnVScroll(vScroll.Value);
           if (useRoi)
                UpdateTracker();
           this.Refresh();
        }

        private void hScroll_Scroll(object sender, ScrollEventArgs e)
        {
           // Update view and tracker
           if (m_pView != null && m_pView.Initialized)
              m_pView.OnHScroll(hScroll.Value);  
           if (useRoi)
                UpdateTracker();
             this.Refresh();
        }

       protected virtual void Slider_Scroll(object sender, EventArgs e)
       {
          if (m_pView != null && m_pView.Initialized)
          {
             m_pView.Buffer.Index = Slider.Value;
             m_pView.Show();
          }
       }

       private String GetPixelString(Point point)
       {
          String str = "[ Pixel data not available ]";

          // if there is no buffer to display, return right away
          if (m_pView == null || m_pView.Buffer == null || !m_pView.Buffer.Mapped)
             return str;
          if (m_pView.Buffer != null)
          {
             Point pt = TranslatePos(point);
             // Get pixel value at cursor's position and create string according to pixel format
             String text = "";
             SapFormat format = m_pView.Buffer.Format;

             switch (format)
             {
                case SapFormat.Uint8:
                case SapFormat.Int8:
                case SapFormat.Int16:
                case SapFormat.Uint16:
                case SapFormat.Int24:
                case SapFormat.Uint24:
                case SapFormat.Int32:
                case SapFormat.Uint32:
                case SapFormat.Int64:
                case SapFormat.Uint64:
                case SapFormat.Mono8P2:
                case SapFormat.Mono8P3:
                case SapFormat.Mono16P2:
                case SapFormat.Mono16P3:
                   SapDataMono dataMono = new SapDataMono();
                   m_pView.Buffer.ReadElement(pt.X, pt.Y, dataMono);
                   text = String.Format("[ x= {0} y= {1} Value= {2} ]", pt.X, pt.Y, dataMono.Mono);
                   break;
                case SapFormat.LAB:
                case SapFormat.LAB101010:
                   SapDataLAB dataLAB = new SapDataLAB();
                   m_pView.Buffer.ReadElement(pt.X, pt.Y, dataLAB);
                   text = String.Format("[ x= {0} y= {1} L= (2) A= (3) B= (4) ]", pt.X, pt.Y, dataLAB.L, dataLAB.A, dataLAB.B);
                   break;
                case SapFormat.LAB16161616:
                   SapDataLABA dataLABA = new SapDataLABA();
                   m_pView.Buffer.ReadElement(pt.X, pt.Y, dataLABA);
                   text = String.Format("[ x= {0} y= {1} L= (2) A= (3) B= (4) ]", pt.X, pt.Y, dataLABA.L, dataLABA.A, dataLABA.B);
                   break;
                case SapFormat.HSI:
                case SapFormat.HSIP8:
                   SapDataHSI dataHSI = new SapDataHSI();
                   m_pView.Buffer.ReadElement(pt.X, pt.Y, dataHSI);
                   text = String.Format("[ x= {0} y= {1} H= {2} S= {3} I= {4} ]", pt.X, pt.Y, dataHSI.H, dataHSI.S, dataHSI.I);
                   break;
                case SapFormat.HSV:
                   SapDataHSV dataHSV = new SapDataHSV();
                   m_pView.Buffer.ReadElement(pt.X, pt.Y, dataHSV);
                   text = String.Format("[x= {0} y= {1} H= {2} S= {3} V= {4}]", pt.X, pt.Y, dataHSV.H, dataHSV.S, dataHSV.V);
                   break;
                case SapFormat.YUV:
                   SapDataYUV dataYUV = new SapDataYUV();
                   m_pView.Buffer.ReadElement(pt.X, pt.Y, dataYUV);
                   text = String.Format("[ x= {0} y= {1} Y= {2} U= {3} V= {4} ]", pt.X, pt.Y, dataYUV.Y, dataYUV.U, dataYUV.V);
                   break;
                case SapFormat.RGB161616:
                case SapFormat.RGB101010:
                case SapFormat.RGB565:
                case SapFormat.RGB888:
                case SapFormat.RGBR888:
                case SapFormat.BICOLOR88:
                case SapFormat.BICOLOR1616:
                   SapDataRGB dataRGB = new SapDataRGB();
                   m_pView.Buffer.ReadElement(pt.X, pt.Y, dataRGB);
                   text = String.Format("[ x= {0} y= {1} R= {2} G= {3} B= {4} ]", pt.X, pt.Y, dataRGB.Red, dataRGB.Green, dataRGB.Blue);
                   break;
				case SapFormat.RGB8888:
                case SapFormat.RGB16161616:
                   SapDataRGBA dataRGBA = new SapDataRGBA();
                   m_pView.Buffer.ReadElement(pt.X, pt.Y, dataRGBA);
                   text = String.Format("[ x= {0} y= {1} R= {2} G= {3} B= {4} ]", pt.X, pt.Y, dataRGBA.Red, dataRGBA.Green, dataRGBA.Blue);
                   break;
                 case SapFormat.RGB888_MONO8:
                 case SapFormat.RGB161616_MONO16:
                   SapDataRGBA dataMulti = new SapDataRGBA();
                   int currentPage = m_pView.Buffer.Page;
                   m_pView.Buffer.ReadElement(pt.X, pt.Y, dataMulti);
                   if (currentPage == 0)
                       text = String.Format("[ x= {0} y= {1} R= {2} G= {3} B= {4} ]", pt.X, pt.Y, dataMulti.Red, dataMulti.Green, dataMulti.Blue);
                   else
                       text = String.Format("[ x= {0} y= {1} Mono= {2} ]", pt.X, pt.Y, dataMulti.Alpha);
                   break;
               case SapFormat.RGBP8:
               case SapFormat.RGBP16:
               case SapFormat.LABP8:
               case SapFormat.LABP16:
                    dataRGB = new SapDataRGB();
                    m_pView.Buffer.ReadElement(pt.X, pt.Y, dataRGB);

                    string formatStr;
                    if (format == SapFormat.RGBP8 || format == SapFormat.LABP8)
                        formatStr = "[ x= %03ld y= %03ld Value= %03d ]";
                    else
                        formatStr = "[ x= %03ld y= %03ld Value= %04X ]";

                    int page = m_pView.Buffer.Page;
                    if (page == 0)
                        text = String.Format(formatStr, pt.X, pt.Y, dataRGB.Red);
                    else if (page == 1)
                        text = String.Format(formatStr, pt.X, pt.Y, dataRGB.Green);
                    else if (page == 2)
                        text = String.Format(formatStr, pt.X, pt.Y, dataRGB.Blue);

                    break;

               default: break;
             }
             // Append string to application title
             str = "  " + text;
          }
          return str;
       }

       private Point TranslatePos(Point point)
       {
          Point translatedPoint = point;

          if (translatedPoint.X < 0)
             translatedPoint.X = 0;

          if (translatedPoint.Y < 0)
             translatedPoint.Y = 0;

          translatedPoint.X += (int)(hScroll.Value * m_pView.ScalingZoomHorz);
          translatedPoint.Y += (int)(vScroll.Value * m_pView.ScalingZoomVert);

          translatedPoint.X = (int)(translatedPoint.X / m_pView.ScalingZoomHorz);
          translatedPoint.Y = (int)(translatedPoint.Y / m_pView.ScalingZoomVert);

          if (m_pView != null && m_pView.Buffer != null)
          {
             if (translatedPoint.X >= m_pView.Buffer.Width)
                translatedPoint.X = m_pView.Buffer.Width - 1;

             if (translatedPoint.Y >= m_pView.Buffer.Height)
                translatedPoint.Y = m_pView.Buffer.Height - 1;
          }
          return translatedPoint;
       }

       private Point UntranslatePos(Point point)
       {
          Point translatedPoint = point;

          if (translatedPoint.X < 0)
             translatedPoint.X = 0;

          if (translatedPoint.Y < 0)
             translatedPoint.Y = 0;

          translatedPoint.X = (int)(translatedPoint.X * m_pView.ScalingZoomHorz);
          translatedPoint.Y = (int)(translatedPoint.Y * m_pView.ScalingZoomVert);

          translatedPoint.X -= (int)(hScroll.Value * m_pView.ScalingZoomHorz);
          translatedPoint.Y -= (int)(vScroll.Value * m_pView.ScalingZoomVert);

          if (m_pView != null)
          {
             if (translatedPoint.X >= m_pView.BufferAreaWidth)
                translatedPoint.X = m_pView.BufferAreaWidth - 1;

             if (translatedPoint.Y >= m_pView.BufferAreaHeight)
                translatedPoint.Y = m_pView.BufferAreaHeight - 1;
          }

          return translatedPoint;
       }

        private void UpdateTracker()
        {
            tracker.X += (LasthScrollValue - hScroll.Value);
            tracker.Y += (LastvScrollValue - vScroll.Value);
            LasthScrollValue = hScroll.Value;
            LastvScrollValue = vScroll.Value;
        }


        // Fit picture box and scroll bars to the bottom right corner
        // of the application's form
        private void FitImageBoxToBottomRight()
        {
           Form frm = this.ParentForm;
           if (frm != null)
           {
               if(frm.WindowState == FormWindowState.Minimized)
                  return;
   
               // Set ImageBox size
               this.Width = frm.ClientRectangle.Width - (this.Left + RightOffset);
               this.Height = frm.ClientRectangle.Height - (this.Top + BottomOffset);

               int width = this.ClientRectangle.Width - (picBox.Left + vScroll.Width);
               if (width < (m_pView.Buffer.Width * m_pView.ScalingZoomHorz))
                  picBox.Width = width;
               else
                  picBox.Width = (int)(m_pView.Buffer.Width * m_pView.ScalingZoomHorz);

               int height = this.ClientRectangle.Height - (picBox.Top + hScroll.Height + SliderOffset);
               if (height < (m_pView.Buffer.Height * m_pView.ScalingZoomVert))
                  picBox.Height = height;
               else
                  picBox.Height = (int)(m_pView.Buffer.Height * m_pView.ScalingZoomVert);

               // Set Scroll bar size and position
               hScroll.Top = picBox.Top + picBox.Height;
               hScroll.Width = picBox.Left + picBox.Width - hScroll.Left;
               vScroll.Left = picBox.Left + picBox.Width;   
               vScroll.Height = picBox.Top + picBox.Height - vScroll.Top;

               //Set Slider width and position
               if (useSlider)
               {
                  Slider.Show();
                  Slider.Top = picBox.Top + picBox.Height + hScroll.Height;
                  Slider.Width = picBox.Left + picBox.Width - hScroll.Left;
               }
               else
                  Slider.Hide();
            }
        }

       public void DisplayTracker()
       {
          if (useRoi && !tracker.IsEmpty)
          {
             Graphics g = m_pView.GetGraphics();
             g.DrawRectangle(new Pen(Color.Gainsboro, 2), tracker);
             m_pView.ReleaseGraphics(g);
          }
       }

       public void OnSize()
       {
           if (m_pView != null && m_pView.Initialized)
           {
              FitImageBoxToBottomRight();
              m_pView.OnSize();
              UpdateScrollBars();        
           }
        }

        private void UpdateScrollBars()
        {

           // Note: the view pointer has already been validated by the caller (OnSize method)
           int viewWidth = m_pView.BufferAreaWidth;
           int viewHeight = m_pView.BufferAreaHeight;
           int pageWidth = m_pView.BufferAreaWidth;
           int pageHeight = m_pView.BufferAreaHeight;

           switch (m_pView.ScalingMode)
           {
              case SapView.DisplayScalingMode.None:
                 {
                    if (m_pView.Buffer != null)
                    {
                       viewWidth = m_pView.Buffer.Width;
                       viewHeight = m_pView.Buffer.Height;
                    }
                    break;// pageWidth and pageHeight are already initialized correctly
                 }
              case SapView.DisplayScalingMode.FitToWindow:
                 {
                    // viewWidth and viewHeight are already initialized correctly
                    // pageWidth and pageHeight are already initialized correctly
                    break;
                 }
              case SapView.DisplayScalingMode.Zoom:
              case SapView.DisplayScalingMode.UserDefined:
                 {
                    if (m_pView.Buffer != null)
                    {
                       viewWidth = (int)(m_pView.Buffer.Width);
                       viewHeight = (int)(m_pView.Buffer.Height);
                    }
                    pageWidth = (int)(m_pView.ScalingSrcArea.Width);
                    pageHeight = (int)(m_pView.ScalingSrcArea.Height);
                    break;
                 }
           }
        

           if (hScroll != null && vScroll != null)
           {
              // Size Horitontal scrollbar
              hScroll.Minimum = 0;
              hScroll.Maximum = (int)((float)(viewWidth + 0.5) - 1);
              hScroll.LargeChange = pageWidth;
              hScroll.Value = m_pView.HorzScrollPosition;


              // Size Vertical scrollbar
              vScroll.Minimum = 0;
              vScroll.Maximum = (int)(((float)viewHeight + 0.5) - 1);
              vScroll.LargeChange = pageHeight;
              vScroll.Value = m_pView.VertScrollPosition;

              // Show/hide scroll bars

              if (m_pView.HorzScrollRange > 0) hScroll.Show();
              else hScroll.Hide();
              if (m_pView.VertScrollRange > 0) vScroll.Show();
              else vScroll.Hide();
           }
        }

        // Properties
       public SapView View
       {
          get { return m_pView;}
          set { 
             m_pView = value;
             if (m_pView != null)
             {
                m_pView.Window = picBox;
             }
          }
       }

       public ToolStripLabel PixelValueDisplay
       {
          get { return pixelValueDispaly; }
          set 
          { 
             pixelValueDispaly = value;
             if (pixelValueDispaly != null)
                BottomOffset = pixelValueDispaly.Height + 5;
             else
                BottomOffset = 5;
          }
       }

       public Rectangle ViewRectangle
       {
          get {
            Size ViewSize = new Size(this.Width - vScroll.Width, this.Height - hScroll.Height);
            return new Rectangle(this.Location, ViewSize);
         }
       }
       
        public Rectangle Tracker
        {
            get 
            {
                if (useRoi)
                    return recTracker;
                else
                    return new Rectangle(0, 0, 0, 0);
            }
        }

        public bool IsTrackerEmpty
        {
            get
            {
                if (recTracker.Height == 0 || recTracker.Width == 0)
                    return true;
                else
                    return false;
            }
        }

        public bool TrackerEnable
        {
            get { return useRoi; }
            set 
            { 
                useRoi = value;
                recTracker = new Rectangle(0,0,0,0);
                tracker = new Rectangle(0,0,0,0);
                this.Refresh();   
            }
        }

       public bool SliderVisible
       {
          get { return useSlider; }
          set
          {
             useSlider = value;
             if (useSlider)
                SliderOffset = 42;
             else
                SliderOffset = 0;
             this.OnSize();
          }
       }

       public bool SliderEnable
       {
          get { return Slider.Enabled; }
          set { Slider.Enabled = value; }
       }

       public int SliderMinimum
       {
          get { return Slider.Minimum; }
          set { Slider.Minimum = value; }
       }

       public int SliderMaximum
       {
          get { return Slider.Maximum; }
          set { Slider.Maximum = value; }
       }

       public int SliderValue
       {
          get { return Slider.Value; }
          set { Slider.Value = value; }
       }

      


      
    }
}
