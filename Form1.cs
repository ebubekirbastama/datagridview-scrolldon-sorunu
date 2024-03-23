using System;
using System.Threading;
using System.Windows.Forms;

namespace PropertyGrid_Ornegi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Çapraz iş parçacığı çağrıları için denetim sağlama kontrolünü devre dışı bırakma
            CheckForIllegalCrossThreadCalls = false;
            // DataGridView'in scroll çubuklarını devre dışı bırakma
            dataGridView1.ScrollBars = ScrollBars.None;
        }

        Thread th;

        // DataGridView bileşenine 10 bin adet veri ekleyen fonksiyon
        private void AddSampleData()
        {
            // DataGridView'in sütunlarını ayarlayalım
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Age";

            // 10 bin adet veri ekleyelim
            for (int i = 0; i < 10000; i++)
            {
                dataGridView1.Rows.Add((i + 1).ToString(), "Name " + (i + 1), (i + 20).ToString());
            }

            // vScrollBar'ın maksimum değerini DataGridView'in satır sayısına ayarlayalım
            vScrollBar1.Maximum = dataGridView1.Rows.Count;
        }

        // Veri ekleme butonunun tıklanma olayı
        private void button1_Click(object sender, EventArgs e)
        {
            // Veri ekleme işlemini yeni bir iş parçacığında başlat
            th = new Thread(AddSampleData);
            th.Start();
        }

        // vScrollBar'ın kaydırma olayı
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // vScrollBar değeri değiştikçe, DataGridView'in görüntülenen ilk satırının indeksini ayarla
            int startIndex = vScrollBar1.Value;
            dataGridView1.FirstDisplayedScrollingRowIndex = startIndex;
        }
    }
}
