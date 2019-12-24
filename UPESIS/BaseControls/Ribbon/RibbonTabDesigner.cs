/*
 
 2008 Jos?Manuel Men�ndez Poo
 * 
 * Please give me credit if you use this code. It's all I ask.
 * 
 * Contact me for more info: menendezpoo@gmail.com
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace BaseControls.Ribbon
{
    internal class RibbonTabDesigner
        : ComponentDesigner
    {
        public override DesignerVerbCollection Verbs
        {
            get
            {
                return new DesignerVerbCollection(new DesignerVerb[] { 
                    new DesignerVerb("Add Panel", new EventHandler(AddPanel))
                });
            }
        }

        public RibbonTab Tab
        {
            get { return Component as RibbonTab; }
        }

        public void AddPanel(object sender, EventArgs e)
        {
            IDesignerHost host = GetService(typeof(IDesignerHost)) as IDesignerHost;

            if (host != null && Tab != null)
            {
                

                DesignerTransaction transaction = host.CreateTransaction("AddPanel" + Component.Site.Name);
                MemberDescriptor member = TypeDescriptor.GetProperties(Component)["Panels"];
                base.RaiseComponentChanging(member);

                RibbonPanel panel = host.CreateComponent(typeof(RibbonPanel)) as RibbonPanel;

                if (panel != null)
                {
                    panel.Text = panel.Site.Name;
                    Tab.Panels.Add(panel);
                    Tab.Owner.OnTabsChanged();
                }

                base.RaiseComponentChanged(member, null, null);
                transaction.Commit();
            }
        }
    }
}
