using System.Windows.Forms;

using CircularProgressBar;

namespace quanlitrungtamngoaingu.UChethong
{
    public partial class UCprogressbar : UserControl
    {
        public UCprogressbar()
        {
            InitializeComponent();
        }
  
       private void UserControl1_Load(object sender, System.EventArgs e)
        {
           
        }
        public int giatri
        {
            get
            {
               return circularProgressBar1.Value;
            }
            set
            {
                circularProgressBar1.Value = value;
            }
        }
        public string hienthi
        {
            get
            {
                return circularProgressBar1.Text;
            }
            set
            {
                circularProgressBar1.Text = value;
            }
        }

        private void circularProgressBar1_Click(object sender, System.EventArgs e)
        {

        }
    }
   
}
