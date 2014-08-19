using System;
using Eto.Drawing;

namespace Eto.Forms
{
	[Handler(typeof(LinkButton.IHandler))]
	public class LinkButton : TextControl
	{
		new IHandler Handler { get { return (IHandler)base.Handler; } }

		/// <summary>
		/// Event identifier for the <see cref="Click"/> event.
		/// </summary>
		public const string ClickEvent = "LinkButton.Click";

		/// <summary>
		/// Occurs when an individual cell is clicked.
		/// </summary>
		public event EventHandler<EventArgs> Click
		{
			add { Properties.AddHandlerEvent(ClickEvent, value); }
			remove { Properties.RemoveEvent(ClickEvent, value); }
		}

		/// <summary>
		/// Raises the <see cref="Click"/> event.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected virtual void OnClick(EventArgs e)
		{
			Properties.TriggerEvent(ClickEvent, this, e);
		}

		public Color TextColor
		{
			get { return Handler.TextColor; }
			set { Handler.TextColor = value; }
		}

		static readonly object callback = new Callback();
		/// <summary>
		/// Gets an instance of an object used to perform callbacks to the widget from handler implementations
		/// </summary>
		/// <returns>The callback instance to use for this widget</returns>
		protected override object GetCallback() { return callback; }

		/// <summary>
		/// Callback interface for <see cref="LinkButton"/>
		/// </summary>
		public new interface ICallback : TextControl.ICallback
		{
			/// <summary>
			/// Raises the click event.
			/// </summary>
			void OnClick(LinkButton widget, EventArgs e);
		}

		/// <summary>
		/// Callback implementation for handlers of <see cref="LinkButton"/>
		/// </summary>
		protected new class Callback : TextControl.Callback, ICallback
		{
			/// <summary>
			/// Raises the click event.
			/// </summary>
			public void OnClick(LinkButton widget, EventArgs e)
			{
				widget.Platform.Invoke(() => widget.OnClick(e));
			}
		}

		/// <summary>
		/// Handler interface for the <see cref="LinkButton"/> control
		/// </summary>
		/// <copyright>(c) 2012-2014 by Curtis Wensley</copyright>
		/// <license type="BSD-3">See LICENSE for full terms</license>
		public new interface IHandler : TextControl.IHandler
		{
			Color TextColor { get; set; }
		}
	}
}
