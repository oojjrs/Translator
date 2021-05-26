using Google.Apis.Auth.OAuth2;
using Google.Apis.Translate.v2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                var regex = new Regex(@"<[^>]+>");
                var regex2 = new Regex(@"</[^>]+>");
                var regex3 = new Regex(@"#[^\s]+");
                var regexT = new Regex(@"\{-?\d+\}");

                var sw = Stopwatch.StartNew();
                var lines = await File.ReadAllLinesAsync(openFileDialog.FileName);

                var dic = new Dictionary<string, string>();
                var key = DateTime.UtcNow.GetHashCode();
                var index = 0;
                while (index < lines.Length)
                {
                    var rets = await client.TranslateTextAsync(lines.Skip(index).Take(BucketCount).Select(line =>
                    {
                        line = regex.Replace(line, match =>
                        {
                            var id = "{" + key++.ToString("d10") + "}";
                            dic.Add(id, match.Value);
                            return id;
                        });
                        line = regex2.Replace(line, match =>
                        {
                            var id = "{" + key++.ToString("d10") + "}";
                            dic.Add(id, match.Value);
                            return id;
                        });
                        line = regex3.Replace(line, match =>
                        {
                            var id = "{" + key++.ToString("d10") + "}";
                            dic.Add(id, match.Value);
                            return id;
                        });

                        // 변환 후처리 과정이 번거로워 html 방식은 사용하지 않는다.
                        //line = regex.Replace(line, match => "<span class=\"notranslate\">" + match.Value + "</span>");
                        //line = regex2.Replace(line, match => "<span class=\"notranslate\">" + match.Value + "</span>");
                        //line = regex3.Replace(line, match => "<span class=\"notranslate\">" + match.Value + "</span>");
                        return line;
                    }), "ko");

                    foreach (var (line, ret, i) in lines.Skip(index).Take(BucketCount).Zip(rets, (line, ret) => (line, ret)).Select((tuple, i) => (tuple.line, tuple.ret, i)))
                    {
                        var item = new ListViewItem((index + i + 1).ToString());
                        item.SubItems.Add(line);
                        item.SubItems.Add(regexT.Replace(ret.TranslatedText, match => dic.TryGetValue(match.Value, out var v) ? v : match.Value));

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
