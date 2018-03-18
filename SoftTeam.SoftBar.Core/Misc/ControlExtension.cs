namespace System.Windows.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;

    public static class ControlExtension
    {
        /// <summary>
        /// A private class that contains information about a draggable control and any 
        /// controls that should be attached to it (i e dragging multiple controls).
        /// </summary>
        private class DraggableControlInfo
        {
            // The control that is being dragged
            public Control Control { get; internal set; }
            // Dragging status (true = being dragged right now)
            public bool Draggable { get; internal set; }
            // Controls that should follow along when the main
            // control is being dragged.
            public List<Control> ConnectedControls { get; internal set; }

            // Constructor
            public DraggableControlInfo(Control control, List<Control> connectedControls)
            {
                Control = control;
                ConnectedControls = connectedControls;
            }
        }

        // TKey is control to drag, TValue is a flag used while dragging
        private static Dictionary<Control, DraggableControlInfo> draggables =
                   new Dictionary<Control, DraggableControlInfo>();
        private static Size mouseOffset;

        /// <summary>
        /// Enabling/disabling dragging for control
        /// </summary>
        public static void Draggable(this Control control, bool enable, List<Control> connectedControls = null)
        {
            if (enable)
            {
                // enable drag feature
                if (draggables.ContainsKey(control))
                {   // return if control is already draggable
                    return;
                }

                // Create an instance of DraggableControl
                DraggableControlInfo draggableControl = new DraggableControlInfo(control, connectedControls);

                // 'false' - initial state is 'not dragging'
                draggables.Add(control, draggableControl);

                // assign required event handler
                control.MouseDown += new MouseEventHandler(control_MouseDown); ;
                control.MouseUp += new MouseEventHandler(control_MouseUp);
                control.MouseMove += new MouseEventHandler(control_MouseMove);

                // assign required event handler for contained control
                foreach (Control containedControl in control.Controls)
                {
                    containedControl.MouseDown += new MouseEventHandler(control_MouseDown); ;
                    containedControl.MouseUp += new MouseEventHandler(control_MouseUp);
                    containedControl.MouseMove += new MouseEventHandler(control_MouseMove);
                }
            }
            else
            {
                // disable drag feature
                if (!draggables.ContainsKey(control))
                {  // return if control is not draggable
                    return;
                }
                // remove event handlers
                control.MouseDown -= control_MouseDown;
                control.MouseUp -= control_MouseUp;
                control.MouseMove -= control_MouseMove;
                draggables.Remove(control);
            }
        }

        static void control_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Size(e.Location);

            var control = (Control)sender;
            // If the control is not in the list of draggable controls
            // it is a contained control, find the parent that is draggable
            control = GetDraggableControl(control);

            // turning on dragging
            draggables[control].Draggable = true;
        }

        static void control_MouseUp(object sender, MouseEventArgs e)
        {
            var control = (Control)sender;
            // If the control is not in the list of draggable controls
            // it is a contained control, find the parent that is draggable
            control = GetDraggableControl(control);
            // turning off dragging
            draggables[control].Draggable = false;
        }

        static void control_MouseMove(object sender, MouseEventArgs e)
        {
            // The control that is being dragged
            var control = (Control)sender;
            // If the control is not in the list of draggable controls
            // it is a contained control, find the parent that is draggable
            control = GetDraggableControl(control);
            // DraggableControlInfo for the control
            var draggableControlInfo = draggables[control];

            // only if dragging is turned on
            if (draggableControlInfo.Draggable == true)
            {
                // calculations of control's new position
                Point newLocationOffset = e.Location - mouseOffset;
                control.Left += newLocationOffset.X;
                control.Top += newLocationOffset.Y;

                // Check if we have any connected controls
                if (draggableControlInfo.ConnectedControls != null)
                {
                    // Adjust position of the connected controls
                    foreach (var conectedControl in draggableControlInfo.ConnectedControls)
                    {
                        conectedControl.Left += newLocationOffset.X;
                        conectedControl.Top += newLocationOffset.Y;
                    }
                }
            }
        }

        /// <summary>
        /// If the control is not contained in draggables collection
        /// it must be a control that is contained inside the draggable control
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private static Control GetDraggableControl(Control control)
        {
            while (!draggables.ContainsKey(control))
                control = control.Parent;

            return control;
        }
    }
}