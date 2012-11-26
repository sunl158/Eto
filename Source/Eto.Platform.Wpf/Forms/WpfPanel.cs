﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eto.Forms;
using Eto.Drawing;
using Eto.Cache;
using swm = System.Windows.Media;

namespace Eto.Platform.Wpf.Forms
{
	public class WpfPanel<T,W> : WpfFrameworkElement<T,W>, IControl
		where T : System.Windows.Controls.Panel
		where W: Control
	{
		public override Color BackgroundColor
		{
			get
			{
				var brush = Control.Background as swm.SolidColorBrush;
                if (brush != null) return brush.Color.ToEto ();
                else return Colors.Black;
			}
			set
			{
                Control.Background = BrushCache.GetBrush(this.Generator,value).ControlObject as swm.Brush;
			}
		}
	}
}
