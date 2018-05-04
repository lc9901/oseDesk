using System;
using System.Drawing;
using System.Windows.Forms;

namespace OnlineExamSystem.UI
{
    public class BaseForm : Form
    {
        #region Private Field

        private bool isMouseDown = false;
        private Point formStartPoint;
        private Point mouserStartPoint;
        #endregion

        /// <summary>
        /// Handles the mouse up event for mouse.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        public void DoPnlTitleMouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        /// <summary>
        /// Handles the mouse move event for mouse.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        public void DoPnlTitleMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isMouseDown = true;
                    Point nowPoint = Control.MousePosition;
                    int xChange = nowPoint.X - mouserStartPoint.X;
                    int yChange = nowPoint.Y - mouserStartPoint.Y;
                    this.Location = new Point(formStartPoint.X + xChange, formStartPoint.Y + yChange);
                }
            }
        }

        /// <summary>
        /// Handles the mouse key down event for mouse.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        public void DoPnlTitleMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                formStartPoint = this.Location;
                mouserStartPoint = Control.MousePosition;
            }
        }

        /// <summary>
        /// Handles the click event for the close button.
        /// Closes current windows and exit this project
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        public virtual void DoLblOpreaCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the click event for min button.
        ///      Hiddens current window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DoLblOperaMinClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region Protected Method

        /// <summary>
        /// Prevents flash screen.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion
    }
}