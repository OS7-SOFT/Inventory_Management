using DevExpress.Utils.Layout;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Notification
{
    internal class NotificationBox
    {
        private static NotificationBox Object;
        public static NotificationBox Instance()
        {
            if (Object == null)
            {
                Object = new NotificationBox();
            }
            return Object;
        }
        int NewRow = 1; // Get the current row count
        public void CreateNotifiction(string NotificationText,string WaringText,Color WaringColor, TablePanel tablePanel, GroupControl groupControl)
        {
            FlowLayoutPanel FlowLayoutPanelStatus = new FlowLayoutPanel();
            FlowLayoutPanel FlowLayoutPanelMessage = new FlowLayoutPanel();
            tablePanel.Controls.Add(FlowLayoutPanelStatus);
            tablePanel.Controls.Add(FlowLayoutPanelMessage);
            FlowLayoutPanelStatus.Size = new Size(409, 74);
            FlowLayoutPanelMessage.Size = new Size(409, 74);


            tablePanel.SetRow(FlowLayoutPanelStatus, NewRow); // Set row to the current row count
            tablePanel.SetColumn(FlowLayoutPanelStatus, 0); // Set column to 0 for FlowLayoutPanelMessage

            tablePanel.SetRow(FlowLayoutPanelMessage, NewRow); // Set row to the current row count
            tablePanel.SetColumn(FlowLayoutPanelMessage, 1); // Set column to 1 for FlowLayoutPanelStatus
            FlowLayoutPanelMessage.Controls.Add(CreateLabel(NotificationText));
            FlowLayoutPanelStatus.Controls.Add(NotifiBox(WaringText, WaringColor));
            tablePanel.Rows.Add(TablePanelEntityStyle.Absolute, 80, true);
            tablePanel.AutoScroll = true;
            groupControl.Controls.Add(tablePanel);
            NewRow++;
        }
        //Method to create Notifiction Lable in Alert
        private LabelControl CreateLabel(string text)
        {
            LabelControl labelControl = new LabelControl();
            labelControl.Text = text;
            labelControl.ForeColor = Color.Black;
            labelControl.LineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            labelControl.Margin = new System.Windows.Forms.Padding(35, 25, 3, 3);
            labelControl.Font = new Font("Tahoma", 12, FontStyle.Regular);
            return labelControl;
        }
        //Method to add notification box
        private SimpleButton NotifiBox(string text, Color color)
        {
            SimpleButton button = new SimpleButton();
            button.Text = text;
            button.Appearance.BackColor = color;
            button.ForeColor = Color.WhiteSmoke;
            button.Margin = new System.Windows.Forms.Padding(3, 14, 3, 3);
            button.Font = new Font("Tahoma", 8, FontStyle.Bold);
            button.Size = new System.Drawing.Size(65, 45);
            button.Cursor = Cursors.Default;

            return button;
        }

    }
}
