using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using DALSA.SaperaLT.SapClassBasic;

namespace DALSA.SaperaLT.SapClassGui
{
    public class ImageWnd
    {
        public ImageWnd(SapView pView, Control pViewWnd, HScrollBar pHorzScr, VScrollBar pVertScr, Form pAppWnd)
        {
            m_pView = pView;
            m_pViewWnd = pViewWnd;
            m_pHorzScr = pHorzScr;
            m_pVertScr = pVertScr;
            m_pAppWnd = pAppWnd;

            m_Rightoffset = m_pAppWnd.ClientRectangle.Right - (m_pViewWnd.ClientRectangle.Right + m_pViewWnd.Location.X);
            m_Bottomoffset = m_pAppWnd.ClientRectangle.Bottom - (m_pViewWnd.ClientRectangle.Bottom + m_pViewWnd.Location.Y);
              
	        ////TODO in Phase 2////
            //m_roi = new Rectangle(0,0,0,0);
            //UpdateRectTracker();
	        OnSize();
        }

        public ImageWnd(SapView pView, Control pViewWnd, HScrollBar pHorzScr, VScrollBar pVertScr, Form pAppWnd, TrackBar pSlider)
        {
            m_pView = pView;
            m_pViewWnd = pViewWnd;
            m_pHorzScr = pHorzScr;
            m_pVertScr = pVertScr;
            m_pAppWnd = pAppWnd;
            m_pSlider = pSlider;

            m_Rightoffset = m_pAppWnd.ClientRectangle.Right - (m_pViewWnd.ClientRectangle.Right + m_pViewWnd.Location.X);
            m_Bottomoffset = m_pAppWnd.ClientRectangle.Bottom - (m_pViewWnd.ClientRectangle.Bottom + m_pViewWnd.Location.Y);

            ////TODO in Phase 2////
            //m_roi = new Rectangle(0, 0, 0, 0);
            //UpdateRectTracker();
            OnSize();
        }

        public String GetPixelString(Point point) 
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

                switch(format)
                {          
                    case SapFormat.Uint8 :    
                    case SapFormat.Int8 : 
                    case SapFormat.Int16 :
                    case SapFormat.Uint16 :
                    case SapFormat.Int24 :
                    case SapFormat.Uint24 :
                    case SapFormat.Int32 :
                    case SapFormat.Uint32 :
                    case SapFormat.Int64 :
                    case SapFormat.Uint64 :
                        SapDataMono dataMono = new SapDataMono();
                        m_pView.Buffer.ReadElement(pt.X, pt.Y, dataMono);
                        text = String.Format("[ x= {0} y= {1} Value= {2} ]", pt.X, pt.Y, dataMono.Mono);
                        break;
                    case SapFormat.LAB :
                    case SapFormat.LABP8 :
                    case SapFormat.LAB101010 :
                    case SapFormat.LABP16 :
                        SapDataLAB dataLAB = new SapDataLAB();
                        m_pView.Buffer.ReadElement(pt.X, pt.Y, dataLAB);
                        text = String.Format("[ x= {0} y= {1} L= (2) A= (3) B= (4) ]", pt.X, pt.Y, dataLAB.L, dataLAB.A, dataLAB.B);
                        break;
                    case SapFormat.LAB16161616 :
                        SapDataLABA dataLABA = new SapDataLABA();
                        m_pView.Buffer.ReadElement(pt.X, pt.Y, dataLABA);
                        text = String.Format("[ x= {0} y= {1} L= (2) A= (3) B= (4) ]", pt.X, pt.Y, dataLABA.L, dataLABA.A, dataLABA.B);
                        break;
                    case SapFormat.HSI : 
                    case SapFormat.HSIP8 :
                        SapDataHSI dataHSI = new SapDataHSI();
                        m_pView.Buffer.ReadElement(pt.X, pt.Y, dataHSI);
                        text = String.Format("[ x= {0} y= {1} H= {2} S= {3} I= {4} ]", pt.X, pt.Y, dataHSI.H, dataHSI.S, dataHSI.I);
                        break;
                    case SapFormat.HSV :
                        SapDataHSV dataHSV = new SapDataHSV();
                        m_pView.Buffer.ReadElement(pt.X, pt.Y, dataHSV);
                        text = String.Format("[x= {0} y= {1} H= {2} S= {3} V= {4}]", pt.X, pt.Y, dataHSV.H, dataHSV.S, dataHSV.V);
                        break;
                    case SapFormat.YUV :
                        SapDataYUV dataYUV = new SapDataYUV();
                        m_pView.Buffer.ReadElement(pt.X, pt.Y, dataYUV);
                        text = String.Format("[ x= {0} y= {1} Y= {2} U= {3} V= {4} ]", pt.X, pt.Y, dataYUV.Y, dataYUV.U, dataYUV.V);
                        break;
                    case SapFormat.RGB161616 :
                    case SapFormat.RGB101010 :
                    case SapFormat.RGB565 :
                    case SapFormat.RGB888 :
                    case SapFormat.RGBR888 :
                    case SapFormat.BICOLOR88:
                    case SapFormat.BICOLOR1616:
                        SapDataRGB dataRGB = new SapDataRGB();
                        m_pView.Buffer.ReadElement(pt.X, pt.Y, dataRGB);
                        text = String.Format("[ x= {0} y= {1} R= {2} G= {3} B= {4} ]", pt.X, pt.Y, dataRGB.Red, dataRGB.Green, dataRGB.Blue);
                        break;
                    case SapFormat.RGB16161616 :
                    case SapFormat.RGB8888 :
                        SapDataRGBA dataRGBA = new SapDataRGBA();
                        m_pView.Buffer.ReadElement(pt.X, pt.Y, dataRGBA);
                        text = String.Format("[ x= {0} y= {1} R= {2} G= {3} B= {4} ]", pt.X, pt.Y, dataRGBA.Red, dataRGBA.Green, dataRGBA.Blue);
                        break;
                    default: break;    
                }
                // Append string to application title
                str = "  " + text;
            }
            return str;        
        }

        public void OnMove()
        {
	       // Call corresponding handler if application window is not being iconified
           if (m_pView != null && m_pAppWnd != null && m_pAppWnd.WindowState != FormWindowState.Minimized)
           {
   	            m_pView.OnMove();
           }
        }

        public void OnPaint()
        {
	       // Call corresponding handler if application window is not being iconified
           if (m_pView != null && m_pAppWnd != null && m_pAppWnd.WindowState != FormWindowState.Minimized)
           {
   	            m_pView.OnPaint();
           }     
        }

        public void OnSize()
        {
           if (m_pViewWnd == null)
              return;

           // If application window is being iconified, hide the current view
           if (m_pAppWnd.WindowState == FormWindowState.Minimized)
           {
              if (m_pView != null)
                 m_pView.Hide();
              return;
           }

           // Get application rectangle
           Rectangle appRect;
           appRect = m_pAppWnd.ClientRectangle;

           // Get view rectangle and offset
           Rectangle viewRect;

           if (m_pViewWnd != null)
           {
              viewRect = new Rectangle(m_pViewWnd.Location, m_pViewWnd.Size);
           }
           else
           {
              viewRect = appRect;
           }

           if (m_pViewWnd != null && m_pHorzScr != null && m_pVertScr != null)
           {

              ///////////////////////////////////////////////////////////
              // Adjust windows' position
              //////////////////////////////////////////////////////////

              // Get scroll bars rectangles
              Rectangle horzRect;
              Rectangle vertRect;
              vertRect = new Rectangle(m_pVertScr.Location, m_pVertScr.Size);
              horzRect = new Rectangle(m_pHorzScr.Location, m_pHorzScr.Size);

              // Adjust view
              viewRect.Width = appRect.Right - (m_Rightoffset + viewRect.Left);
              if (viewRect.Width > (m_pView.Buffer.Width * m_pView.ScalingZoomHorz))
                 viewRect.Width = (int)(m_pView.Buffer.Width * m_pView.ScalingZoomHorz);

              viewRect.Height = appRect.Bottom - (m_Bottomoffset + viewRect.Top);
              if (viewRect.Height > (m_pView.Buffer.Height * m_pView.ScalingZoomVert))
                 viewRect.Height = (int)(m_pView.Buffer.Height * m_pView.ScalingZoomVert);

              m_pViewWnd.Size = new Size(viewRect.Width, viewRect.Height);

              // Adjust Horizontal scrollbar
              horzRect.X = viewRect.Left;
              horzRect.Y = viewRect.Top - horzRect.Height;
              horzRect.Width = viewRect.Width;
              m_pHorzScr.Location = new Point(horzRect.X, horzRect.Y);
              m_pHorzScr.Size = new Size(horzRect.Width, horzRect.Height);

              // Adjust vertical scrollbar
              vertRect.X = viewRect.Left - vertRect.Width;
              vertRect.Y = viewRect.Top;
              vertRect.Height = viewRect.Height;
              m_pVertScr.Location = new Point(vertRect.X, vertRect.Y);
              m_pVertScr.Size = new Size(vertRect.Width, vertRect.Height);

              // Adjust Slider
              if (m_pSlider != null)
              {
                 Rectangle SliderRect = new Rectangle(m_pSlider.Location, m_pSlider.Size);
                 SliderRect.X = viewRect.Left;
                 SliderRect.Y = viewRect.Bottom;
                 SliderRect.Width = viewRect.Width;
                 m_pSlider.Location = new Point(SliderRect.X, SliderRect.Y);
                 m_pSlider.Size = new Size(SliderRect.Width, SliderRect.Height);
              }
           }

           if (m_pView != null)
           {
              // Call corresponding handler
              m_pView.OnSize();

              // Update scroll bars' position and range
              UpdateScrollBars();

              // Update view rectangle
              //m_ViewRect = viewRect;
              //m_ViewRect.X += m_pView.ScalingDestArea.Left;
              //m_ViewRect.Y += m_pView.ScalingDestArea.Top;
              //m_ViewRect.Width = m_pView.BufferAreaWidth;
              //m_ViewRect.Height =  m_pView.BufferAreaHeight;

              // Update view rectangle
              m_ViewRect.X = viewRect.X;
              m_ViewRect.Y = viewRect.Y;
              m_ViewRect.Width = appRect.Right - (m_Rightoffset + viewRect.Left);
              m_ViewRect.Height = appRect.Bottom - (m_Bottomoffset + viewRect.Top);

              ////// TODO in phase 2 ////////// 
              // Update tracker limits
              //Rectangle limitRect = new Rectangle(0,0,m_pView.BufferAreaWidth,m_pView.BufferAreaHeight);
              //m_RectTracker.SetLimitRect(limitRect);
              /////////////////////////////////

              ////////TODO in phase 2////////////
              /*if (m_pViewWnd == null)
              {
                  // Check if unused region of the AppWnd should be repainted
                  int viewWidth = m_pView.BufferAreaWidth;
                  int viewHeight = m_pView.BufferAreaHeight;

                  if (appRect.Width > viewWidth)
                  {
                      Rectangle rect = appRect;
                      rect.X = viewWidth;
                      m_pAppWnd.Invalidate(rect, true);
                  }
                  if (appRect.Height > viewHeight)
                  {
                      Rectangle rect = appRect;
                      rect.Y = viewHeight;
                      m_pAppWnd.Invalidate(rect, true);
                  }                 
              }*/
           }
        }

        public void Update()
        {
            // Redraw m_pViewWnd
            m_pViewWnd.Invalidate();
            m_pViewWnd.Update();
            // Redraw m_pView
            m_pView.OnPaint();
        
        }

        public void OnHScroll(ScrollEventArgs e)
        {
           // Update view and tracker
           if (m_pView !=null)
               m_pView.OnHScroll(m_pHorzScr.Value);

            OnPaint();
            UpdateRectTracker();
        }

        public void OnVScroll(ScrollEventArgs e)
        {
            // Update view and tracker
            if (m_pView != null)
                m_pView.OnVScroll(m_pVertScr.Value);

            OnPaint();
            UpdateRectTracker();
        }

        public void OnSliderScroll(EventArgs e)
        {
            if (m_pView != null)
                m_pView.Show(m_pSlider.Value);

            UpdateRectTracker();
        }

        private void UpdateScrollBars()
        {
           // Note: the view pointer has already been validated by the caller (OnSize method)
	        int viewWidth  = m_pView.BufferAreaWidth;
	        int viewHeight = m_pView.BufferAreaHeight;
	        int pageWidth  = m_pView.BufferAreaWidth;
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
	        // Update tracker position
	        UpdateRectTracker();

            if (m_pHorzScr != null && m_pVertScr != null)
            {
                // Size Horitontal scrollbar
	             m_pHorzScr.Minimum = 0;
                m_pHorzScr.Maximum = (int)((float)(viewWidth + 0.5) - 1);
                m_pHorzScr.LargeChange = pageWidth;
                m_pHorzScr.Value = m_pView.HorzScrollPosition;

                
                // Size Vertical scrollbar
                m_pVertScr.Minimum = 0;
                m_pVertScr.Maximum = (int)(((float)viewHeight + 0.5) - 1);
                m_pVertScr.LargeChange = pageHeight;
	             m_pVertScr.Value = m_pView.VertScrollPosition;

                // Show/hide scroll bars
    	       
                if (m_pView.HorzScrollRange > 0) m_pHorzScr.Show();
                else m_pHorzScr.Hide();
                if (m_pView.VertScrollRange > 0) m_pVertScr.Show();
                else m_pVertScr.Hide();
	        }
        }

        private Point TranslatePos(Point point)
        {
	       Point translatedPoint= point;
        	
	       if( translatedPoint.X < 0)
		       translatedPoint.X = 0;

	       if( translatedPoint.Y < 0)
		       translatedPoint.Y = 0;

           translatedPoint.X += (int)(m_pHorzScr.Value * m_pView.ScalingZoomHorz);
	       translatedPoint.Y += (int) (m_pVertScr.Value * m_pView.ScalingZoomVert);

           translatedPoint.X = (int)(translatedPoint.X / m_pView.ScalingZoomHorz);
           translatedPoint.Y = (int)(translatedPoint.Y / m_pView.ScalingZoomVert);

           if (m_pView != null && m_pView.Buffer != null)
           {
	           if( translatedPoint.X >= m_pView.Buffer.Width)
		           translatedPoint.X= m_pView.Buffer.Width-1;

	           if( translatedPoint.Y >= m_pView.Buffer.Height)
		           translatedPoint.Y= m_pView.Buffer.Height-1;
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

            translatedPoint.X -= (int)(m_pHorzScr.Value * m_pView.ScalingZoomHorz);
            translatedPoint.Y -= (int)(m_pVertScr.Value * m_pView.ScalingZoomVert);

            if (m_pView != null)
            {
                if (translatedPoint.X >= m_pView.BufferAreaWidth)
                    translatedPoint.X = m_pView.BufferAreaWidth - 1;

                if (translatedPoint.Y >= m_pView.BufferAreaHeight)
                    translatedPoint.Y = m_pView.BufferAreaHeight - 1;
            }

            return translatedPoint;
        }
     
        private void UpdateRectTracker()
        {
	        ////// TODO in phase 2 ////////// 
            //m_RectTracker.m_rect.TopLeft()    = UntranslatePos( new Point(m_roi.Left,m_roi.Top));
	        //m_RectTracker.m_rect.BottomRight()= UntranslatePos( new Point(m_roi.Right,m_roi.Bottom));
        }

        public Rectangle ViewRectangle
        {
            get { return m_ViewRect; }
        }

        public SapView View
        {
            get { return m_pView; }
            set { m_pView = value; }
        }

        private SapView m_pView;
        private Control m_pViewWnd;
        private HScrollBar m_pHorzScr;
        private VScrollBar m_pVertScr;
        private Form m_pAppWnd;
        private TrackBar m_pSlider;
    
        // Other variables
        private Rectangle m_ViewRect;
        //private Rectangle m_roi;
        private int m_Rightoffset;
        private int m_Bottomoffset;

        // Variable for Phase 2
        //private RectTracker m_RectTracker; 
        
    }
}
