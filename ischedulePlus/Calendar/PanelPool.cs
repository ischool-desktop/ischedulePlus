using System.Collections.Generic;
using System.ComponentModel;
using DevComponents.DotNetBar;

namespace ischedulePlus
{
    public class PanelPool
    {
        private static PanelPool mPanelPool = null;
        private List<PanelEx> Panels = new List<PanelEx>();

        public static PanelPool Instance
        {
            get
            {
                if (mPanelPool == null)
                    mPanelPool = new PanelPool();

                return mPanelPool;
            }
        }

        public PanelEx GetPanel()
        {
            PanelEx result = null;

            if (Panels.Count > 0)
            {
                result = Panels[0];
                Panels.RemoveAt(0);
            }
            else
                result = new PanelEx();

            return result;
        }

        public void CreateAnysc()
        {
            BackgroundWorker worker = new BackgroundWorker();

            List<PanelEx> Panels = new List<PanelEx>();

            worker.DoWork += (sender, e) =>
            {
                //if (SelectedPanel.Tag == null)
                //{
                //    vDecCalendar = new DecCalendar(SelectedPanel);
                //    SelectedPanel.Tag = vDecCalendar;
                //}

                //Stopwatch mWatch = Stopwatch.StartNew();

                //for (int i = 0; i < 1000; i++)
                //{
                //    DevComponents.DotNetBar.PanelEx pnl = new DevComponents.DotNetBar.PanelEx();
                    
                //    //pnl.CanvasColor = System.Drawing.SystemColors.Control;
                //    //pnl.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                //    //pnl.Style.Alignment = System.Drawing.StringAlignment.Center;
                //    //pnl.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
                //    //pnl.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
                //    //pnl.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
                //    //pnl.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
                //    //pnl.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
                //    //pnl.Style.GradientAngle = 90;
                //    //pnl.TabIndex = 1;

                //    Panels.Add(pnl);
                //}

                //mWatch.Stop();

                //Console.WriteLine(mWatch.ElapsedMilliseconds);
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {

            };

            worker.RunWorkerAsync();
        }
    }
}