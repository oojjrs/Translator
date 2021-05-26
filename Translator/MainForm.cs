using Google.Apis.Auth.OAuth2;
using Google.Apis.Translate.v2;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Translator
{
    public partial class MainForm : Form
    {
        private const int BucketCount = 100;

        private static readonly string[] Scopes = { TranslateService.Scope.CloudTranslation };

        public MainForm()
        {
            InitializeComponent();
        }

        private async void loadButton_Click(object sender, EventArgs e)
        {
            loadButton.Enabled = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                wordListView.Items.Clear();

                var client = Google.Cloud.Translation.V2.TranslationClient.Create(GoogleCredential.FromFile("$credentials.json"));

                var sw = Stopwatch.StartNew();
                var lines = await File.ReadAllLinesAsync(openFileDialog.FileName);

                var index = 0;
                while (index < lines.Length)
                {
                    var rets = await client.TranslateTextAsync(lines.Skip(index).Take(BucketCount), "ko");
                    foreach (var (ret, i) in rets.Select((ret, i) => (ret, i)))
                    {
                        var item = new ListViewItem((index + i + 1).ToString());
                        item.SubItems.Add(ret.OriginalText);
                        item.SubItems.Add(ret.TranslatedText);

                        wordListView.Items.Add(item);

                        if (sw.ElapsedMilliseconds > 1000)
                        {
                            sw.Restart();

                            wordListView.Refresh();
                        }
                    }

                    index += rets.Count();
                }
            }

            loadButton.Enabled = true;
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            saveButton.Enabled = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                await File.WriteAllLinesAsync(saveFileDialog.FileName, wordListView.Items.Cast<ListViewItem>().Select(t => t.SubItems[2].Text), Encoding.Default);

                MessageBox.Show($"저장 완료 : {saveFileDialog.FileName}");
            }

            saveButton.Enabled = true;
        }
    }
}
