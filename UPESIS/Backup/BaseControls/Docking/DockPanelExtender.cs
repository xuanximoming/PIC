using System;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;

namespace BaseControls.Docking
{
	public sealed class DockPanelExtender
	{
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IDockPaneFactory
		{
			DockPane CreateDockPane(IDockContent content, DockState visibleState, bool show);
            [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "1#")]            
			DockPane CreateDockPane(IDockContent content, FloatWindow floatWindow, bool show);
			DockPane CreateDockPane(IDockContent content, DockPane previousPane, DockAlignment alignment, double proportion, bool show);
            [SuppressMessage("Microsoft.Naming", "CA1720:AvoidTypeNamesInParameters", MessageId = "1#")]            
			DockPane CreateDockPane(IDockContent content, Rectangle floatWindowBounds, bool show);
		}

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IFloatWindowFactory
		{
			FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane);
			FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds);
		}

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IDockPaneCaptionFactory
		{
			DockPaneCaptionBase CreateDockPaneCaption(DockPane pane);
		}

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IDockPaneStripFactory
		{
			DockPaneStripBase CreateDockPaneStrip(DockPane pane);
		}

        ///// <include file='CodeDoc\DockPanelExtender.xml' path='//CodeDoc/Class[@name="DockPanelExtender"]/Interface[@name="IAutoHideTabFactory"]/InterfaceDef/*'/>
        //public interface IAutoHideTabFactory
        //{
        //    /// <include file='CodeDoc\DockPanelExtender.xml' path='//CodeDoc/Class[@name="DockPanelExtender"]/Interface[@name="IAutoHideTabFactory"]/Method[@name="CreateAutoHideTab(IDockContent)"]/*'/>
        //    AutoHideTab CreateAutoHideTab(IDockContent content);
        //}

        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public interface IAutoHideStripFactory
		{
			AutoHideStripBase CreateAutoHideStrip(DockPanel panel);
		}

        ///// <include file='CodeDoc\DockPanelExtender.xml' path='//CodeDoc/Class[@name="DockPanelExtender"]/Interface[@name="IDockPaneTabFactory"]/InterfaceDef/*'/>
        //public interface IDockPaneTabFactory
        //{
        //    /// <include file='CodeDoc\DockPanelExtender.xml' path='//CodeDoc/Class[@name="DockPanelExtender"]/Interface[@name="IDockPaneTabFactory"]/Method[@name="CreateDockPaneTab(IDockContent)"]/*'/>
        //    DockPaneTab CreateDockPaneTab(IDockContent content);
        //}

		#region DefaultDockPaneFactory
		private class DefaultDockPaneFactory : IDockPaneFactory
		{
			public DockPane CreateDockPane(IDockContent content, DockState visibleState, bool show)
			{
				return new DockPane(content, visibleState, show);
			}

			public DockPane CreateDockPane(IDockContent content, FloatWindow floatWindow, bool show)
			{
				return new DockPane(content, floatWindow, show);
			}

			public DockPane CreateDockPane(IDockContent content, DockPane prevPane, DockAlignment alignment, double proportion, bool show)
			{
				return new DockPane(content, prevPane, alignment, proportion, show);
			}

			public DockPane CreateDockPane(IDockContent content, Rectangle floatWindowBounds, bool show)
			{
				return new DockPane(content, floatWindowBounds, show);
			}
		}
		#endregion

		#region DefaultFloatWindowFactory
		private class DefaultFloatWindowFactory : IFloatWindowFactory
		{
			public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane)
			{
				return new FloatWindow(dockPanel, pane);
			}

			public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds)
			{
				return new FloatWindow(dockPanel, pane, bounds);
			}
		}
		#endregion

        //#region DefaultDockPaneTabFactory
        //private class DefaultDockPaneTabFactory : IDockPaneTabFactory
        //{
        //    public DockPaneTab CreateDockPaneTab(IDockContent content)
        //    {
        //        return new DockPaneTabVS2003(content);
        //    }
        //}
        //#endregion

		#region DefaultDockPaneCaptionFactory
		private class DefaultDockPaneCaptionFactory : IDockPaneCaptionFactory
		{
			public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
			{
				return new VS2005DockPaneCaption(pane);
			}
		}
		#endregion

		#region DefaultDockPaneTabStripFactory
		private class DefaultDockPaneStripFactory : IDockPaneStripFactory
		{
			public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
			{
				return new VS2005DockPaneStrip(pane);
			}
		}
		#endregion

		#region DefaultAutoHideStripFactory
		private class DefaultAutoHideStripFactory : IAutoHideStripFactory
		{
			public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
			{
				return new VS2005AutoHideStrip(panel);
			}
		}
		#endregion

        //#region DefaultAutoHideTabFactory
        //private class DefaultAutoHideTabFactory : IAutoHideTabFactory
        //{
        //    public AutoHideTab CreateAutoHideTab(IDockContent content)
        //    {
        //        return new AutoHideTabVS2003(content);
        //    }
        //}
        //#endregion

		internal DockPanelExtender(DockPanel dockPanel)
		{
			m_dockPanel = dockPanel;
		}

		private DockPanel m_dockPanel;
		private DockPanel DockPanel
		{
			get	{	return m_dockPanel;	}
		}

		private IDockPaneFactory m_dockPaneFactory = null;
		public IDockPaneFactory DockPaneFactory
		{
			get
			{
				if (m_dockPaneFactory == null)
					m_dockPaneFactory = new DefaultDockPaneFactory();

				return m_dockPaneFactory;
			}
			set
			{
				if (DockPanel.Panes.Count > 0)
					throw new InvalidOperationException();

				m_dockPaneFactory = value;
			}
		}

		private IFloatWindowFactory m_floatWindowFactory = null;
		public IFloatWindowFactory FloatWindowFactory
		{
			get
			{
				if (m_floatWindowFactory == null)
					m_floatWindowFactory = new DefaultFloatWindowFactory();

				return m_floatWindowFactory;
			}
			set
			{
				if (DockPanel.FloatWindows.Count > 0)
					throw new InvalidOperationException();

				m_floatWindowFactory = value;
			}
		}

		private IDockPaneCaptionFactory m_dockPaneCaptionFactory = null;
		public IDockPaneCaptionFactory DockPaneCaptionFactory
		{	
			get
			{
				if (m_dockPaneCaptionFactory == null)
					m_dockPaneCaptionFactory = new DefaultDockPaneCaptionFactory();

				return m_dockPaneCaptionFactory;
			}
			set
			{
				if (DockPanel.Panes.Count > 0)
					throw new InvalidOperationException();

				m_dockPaneCaptionFactory = value;
			}
		}

        //private IDockPaneTabFactory m_dockPaneTabFactory = null;
        ///// <include file='CodeDoc/DockPanelExtender.xml' path='//CodeDoc/Class[@name="DockPanelExtender"]/Property[@name="DockPaneTabFactory"]/*'/>
        //public IDockPaneTabFactory DockPaneTabFactory
        //{
        //    get
        //    {
        //        if (m_dockPaneTabFactory == null)
        //            m_dockPaneTabFactory = new DefaultDockPaneTabFactory();

        //        return m_dockPaneTabFactory;
        //    }
        //    set
        //    {
        //        if (DockPanel.Contents.Count > 0)
        //            throw new InvalidOperationException();

        //        m_dockPaneTabFactory = value;
        //    }
        //}

		private IDockPaneStripFactory m_dockPaneStripFactory = null;
		public IDockPaneStripFactory DockPaneStripFactory
		{
			get
			{
				if (m_dockPaneStripFactory == null)
					m_dockPaneStripFactory = new DefaultDockPaneStripFactory();

				return m_dockPaneStripFactory;
			}
			set
			{
				if (DockPanel.Contents.Count > 0)
					throw new InvalidOperationException();

				m_dockPaneStripFactory = value;
			}
		}

        //private IAutoHideTabFactory m_autoHideTabFactory = null;
        // <include file='CodeDoc/DockPanelExtender.xml' path='//CodeDoc/Class[@name="DockPanelExtender"]/Property[@name="AutoHideTabFactory"]/*'/>
        //public IAutoHideTabFactory AutoHideTabFactory
        //{
        //    get
        //    {
        //        if (m_autoHideTabFactory == null)
        //            m_autoHideTabFactory = new DefaultAutoHideTabFactory();

        //        return m_autoHideTabFactory;
        //    }
        //    set
        //    {
        //        if (DockPanel.Contents.Count > 0)
        //            throw new InvalidOperationException();

        //        m_autoHideTabFactory = value;
        //    }
        //}

		private IAutoHideStripFactory m_autoHideStripFactory = null;
		public IAutoHideStripFactory AutoHideStripFactory
		{	
			get
			{
				if (m_autoHideStripFactory == null)
					m_autoHideStripFactory = new DefaultAutoHideStripFactory();

				return m_autoHideStripFactory;
			}
			set
			{
				if (DockPanel.Contents.Count > 0)
					throw new InvalidOperationException();

				if (m_autoHideStripFactory == value)
					return;

				m_autoHideStripFactory = value;
                DockPanel.ResetAutoHideStripControl();
			}
		}
	}
}
