using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace ObjectCounterApp
{
    public partial class MainForm : Form
    {
        private List<string> classNames = new List<string>
        {
                "Nasi goreng",
                "Ayam bakar",
                "Roti bakar",
                "Sate kambing",
                "Pizza margherita",
                "Sushi salmon",
                "Spaghetti carbonara",
                "Gado-gado",
                "Tahu tempe",
                "Cendol",
                "Rendang daging",
                "Kue lapis",
                "Es kelapa muda",
                "Bakso kuah",
                "Mie goreng",
                "Ramen miso",
                "Pancake blueberry",
                "Salad buah",
                "Keripik singkong",
                "Pudding cokelat",
                "Martabak manis",
                "Kebab ayam",
                "Bubur ayam",
                "Tacos daging",
                "Dimsum udang",
                "Popcorn mentega",
                "Churros dengan cokelat",
                "Quiche sayuran",
                "Sushi rolls",
                "Smoothie mangga"
        };

        private List<(int, DateTime, string)> scheduleList = new List<(int, DateTime, string)>();

        // Variabel untuk menyimpan hasil perhitungan objek
        private ConcurrentDictionary<string, int> classCounts = new ConcurrentDictionary<string, int>();
        private int totalObjects = 0;
        private int imageCount = 0;

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtActivity.Text))
            {
                int num = scheduleList.Count + 1;
                scheduleList.Add((num, dtpTime.Value, txtActivity.Text));
                txtActivity.Clear();
                GenerateDocxReport();
            }
            else
            {
                MessageBox.Show("Silakan masukkan aktivitas.");
            }
        }

        private void GenerateDocxReport()
        {
            string filePath = "Laporan_ObjectCounterApp.docx";
            var doc = DocX.Create(filePath);
            
            // Tambahkan judul
            doc.InsertParagraph("Laporan Object Counter App")
                .FontSize(16)
                .Bold()
                .Alignment = Xceed.Document.NET.Alignment.center; // Mengganti ParagraphAlignment.Center menjadi Alignment.center

            // Tambahkan hasil hitungan objek
            doc.InsertParagraph("\nHasil Hitungan Objek:\n")
                .FontSize(14)
                .Bold();
            
            doc.InsertParagraph($"Jumlah file gambar: {imageCount} file\n");
            doc.InsertParagraph($"Total objek ditemukan: {totalObjects} objek\n\n");
            doc.InsertParagraph("Rincian objek per kelas:");

            foreach (var entry in classCounts)
            {
                doc.InsertParagraph($"- {entry.Key}: {entry.Value} objek");
            }

            // Tambahkan tabel jadwal
            doc.InsertParagraph("\n\nJadwal Kegiatan:\n")
                .FontSize(14)
                .Bold();

            var table = doc.AddTable(scheduleList.Count + 1, 3);
            table.Design = Xceed.Document.NET.TableDesign.LightShadingAccent1; // Mengganti TableDesign menjadi TableDesigns
            table.Rows[0].Cells[0].Paragraphs[0].Append("No").Bold();
            table.Rows[0].Cells[1].Paragraphs[0].Append("Jam").Bold();
            table.Rows[0].Cells[2].Paragraphs[0].Append("Aktivitas").Bold();

            for (int i = 0; i < scheduleList.Count; i++)
            {
                table.Rows[i + 1].Cells[0].Paragraphs[0].Append(scheduleList[i].Item1.ToString());
                table.Rows[i + 1].Cells[1].Paragraphs[0].Append(scheduleList[i].Item2.ToString("HH:mm"));
                table.Rows[i + 1].Cells[2].Paragraphs[0].Append(scheduleList[i].Item3);
            }

            doc.InsertTable(table);

            // Simpan dokumen
            doc.Save();
            MessageBox.Show("Laporan telah dibuat: " + filePath);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFolderPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private async void btnCountObjects_Click(object sender, EventArgs e)
        {
            string folderPath = txtFolderPath.Text;

            if (Directory.Exists(folderPath))
            {
                lblStatus.Text = "Counting objects, please wait...";
                var result = await Task.Run(() => CountObjectsAndImages(folderPath));
                classCounts = result.classCounts;
                totalObjects = result.totalObjects;
                imageCount = result.imageCount;
                DisplayResults(result);
                lblStatus.Text = "Process completed!";
            }
            else
            {
                MessageBox.Show("Please select a valid folder.");
            }
        }

        private void DisplayResults((ConcurrentDictionary<string, int> classCounts, int totalObjects, int imageCount) result)
        {
            txtResults.Clear();
            txtResults.AppendText($"Jumlah file gambar: {result.imageCount} file\n" + Environment.NewLine);
            txtResults.AppendText($"Total objek ditemukan: {result.totalObjects} objek\n\n"  + Environment.NewLine);
            txtResults.AppendText("Rincian objek per kelas:\n "  + Environment.NewLine);

            foreach (var entry in result.classCounts)
            {
                txtResults.AppendText($"- {entry.Key}: {entry.Value} objek\n" + Environment.NewLine);
            }
        }

        private (ConcurrentDictionary<string, int> classCounts, int totalObjects, int imageCount) CountObjectsAndImages(string rootFolder)
        {
            var classCounts = new ConcurrentDictionary<string, int>();
            int imageCount = 0;
            int totalObjects = 0;

            var txtFiles = Directory.GetFiles(rootFolder, "*.txt", SearchOption.AllDirectories)
                                    .Where(f => !f.EndsWith("classes.txt")).ToList();
            var imageFiles = Directory.GetFiles(rootFolder, "*.*", SearchOption.AllDirectories)
                                      .Where(f => f.EndsWith(".jpg") || f.EndsWith(".jpeg") || f.EndsWith(".png"))
                                      .ToList();
            
            imageCount = imageFiles.Count;

            Parallel.ForEach(txtFiles, txtFile =>
            {
                var lines = File.ReadAllLines(txtFile);
                totalObjects += lines.Length;

                foreach (var line in lines)
                {
                    try
                    {
                        int classId = int.Parse(line.Split()[0]);

                        if (classId >= 0 && classId < classNames.Count)
                        {
                            classCounts.AddOrUpdate(classNames[classId], 1, (key, oldValue) => oldValue + 1);
                        }
                    }
                    catch
                    {
                        // Handle any invalid line here
                    }
                }
            });

            return (classCounts, totalObjects, imageCount);
        }
    }
}
