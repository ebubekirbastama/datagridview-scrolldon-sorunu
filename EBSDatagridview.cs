using System.Windows.Forms;

namespace PropertyGrid_Ornegi
{
    public partial class EBSDatagridview : UserControl
    {
        public EBSDatagridview()
        {
            InitializeComponent();
        }


        // Bu metot ile TableLayoutPanel içindeki DataGridView'e erişim sağlarız
        public DataGridView GetDataGridViewInTableLayoutPanel()
        {
            // Diyelim ki TableLayoutPanel içindeki DataGridView kontrolü 0. sırada
            Control control = tableLayoutPanel1.GetControlFromPosition(0, 0);

            // Eğer kontrol bir DataGridView ise dönüş yap
            if (control is DataGridView dataGridView)
            {
                return dataGridView;
            }
            else
            {
                // Kontrol bir DataGridView değilse null döndür
                return null;
            }
        }
    }

}
