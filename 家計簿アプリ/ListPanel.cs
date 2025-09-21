using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearVale
{
    public partial class ListPanel : UserControl
    {
        public IEData IEdata { get; set; }
        public int ID { get { return IEdata.ID; } }

        public ListPanel(IEData IE)
        {
            InitializeComponent();
            IEdata = IE;
        }

        private void ListPanel_Load(object sender, EventArgs e)
        {
            label1.Text = IEdata.IorE;
            label2.Text = IEdata.categry;
            label3.Text = IEdata.amount.ToString();
            label4.Text = IEdata.memo;
        }
    }
}
