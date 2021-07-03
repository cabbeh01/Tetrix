using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class DoubleBufferedPanel : Panel
    {
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        public DoubleBufferedPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
        }

        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}