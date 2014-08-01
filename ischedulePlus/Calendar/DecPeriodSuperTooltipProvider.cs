using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ischedulePlus
{
    public class DecPeriodSuperTooltipProvider : Component, DevComponents.DotNetBar.ISuperTooltipInfoProvider
    {
        private DecPeriod  mPeriod = null;

		/// <summary>
		/// Creates new instance of the object.
		/// </summary>
		/// <param name="node">Node to provide tooltip information for</param>
        public DecPeriodSuperTooltipProvider(DecPeriod vPeriod)
		{
            mPeriod = vPeriod;
		}

		/// <summary>
		/// Call this method to show tooltip for given node.
		/// </summary>
		public void Show()
		{
			if(this.DisplayTooltip!=null)
				DisplayTooltip(this,new EventArgs());
		}

		/// <summary>
		/// Call this method to hide tooltip for given node.
		/// </summary>
		public void Hide()
		{
			if(this.HideTooltip!=null)
				this.HideTooltip(this,new EventArgs());
		}

        #region ISuperTooltipInfoProvider 成員

        public System.Drawing.Rectangle ComponentRectangle
        {
            get 
            {
                Rectangle r = mPeriod.Panel.Bounds;
                r.Y = r.Y + 50;
                r.X = r.X + 50;
                return r;
            }
        }

        public event EventHandler DisplayTooltip;

        public event EventHandler HideTooltip;

        #endregion
    }
}