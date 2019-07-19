using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TibosiHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btExchange_Click(object sender, EventArgs e)
        {
            var oldText = tbOldText.Text.Trim();

            var lines = oldText.Split('\r', '\n');
            tbNewText.Text = GetTitle(lines);
        }

        public string GetNo(string input)
        {
            var str = input.Trim();
            StringBuilder sb = new StringBuilder();

            Regex regNum = new Regex("^[1-9]");
            if (regNum.IsMatch(str))//开头是数字
            {
                foreach (var c in str)
                {
                    if (char.IsNumber(c))
                    {
                        sb.Append(c);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return sb.ToString();
        }

        public bool IsStartsWith(string input, string txt)
        {
            var str = input.Trim();
            return str.Trim().StartsWith(txt, StringComparison.CurrentCultureIgnoreCase);
        }

        public string GetTitle(string[] lines)
        {
            Dictionary<int, string> titles = new Dictionary<int, string>();
            Dictionary<int, string> options = new Dictionary<int, string>();
            Dictionary<int, string> answers = new Dictionary<int, string>();

            StringBuilder sb = new StringBuilder();
            int titleNo = 1;
            foreach (var item in lines)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    continue;
                }
                try
                {
                    //题目
                    var no = GetNo(item);
                    if (!string.IsNullOrWhiteSpace(no))
                    {
                        sb = new StringBuilder();
                        sb.Append(item.Substring(no.Length).Trim());
                        continue;
                    }
                    if (IsStartsWith(item, "A"))
                    {
                        var txt = sb.ToString().Trim().Replace("\r\n", "\t");
                        titles.Add(titleNo, txt);
                        sb = new StringBuilder();
                        sb.AppendLine(item);
                        continue;
                    }
                    if (IsStartsWith(item, "答案"))
                    {
                        var txt = sb.ToString().Trim();
                        options.Add(titleNo, txt);
                        answers.Add(titleNo++, item.Substring("答案：".Length).Trim());
                        continue;
                    }
                    sb.AppendLine(item.Trim());
                    //sb.Append($"\t{item.Trim()}");
                }
                catch (Exception e)
                {
                    var txt = titles[titles.Values.Count - 1];
                    MessageBox.Show($"错误：{e.Message}，当前题目：{txt}");
                    break;
                }
            }

            StringBuilder newText = new StringBuilder();
            newText.AppendLine("[单选题]");
            foreach (var item in titles)
            {
                newText.AppendLine(item.Key + ".\t" + item.Value);
                if (options.ContainsKey(item.Key))
                {
                    newText.AppendLine($"{options[item.Key]}");

                }
            }
            newText.AppendLine("[试题答案]");
            foreach (var item in answers)
            {
                newText.AppendLine(item.Key + ".\t" + item.Value);
            }
            return newText.ToString();
        }
        public string GetTitle0(string[] lines)
        {
            Dictionary<int, string> titles = new Dictionary<int, string>();
            Dictionary<int, Dictionary<string, string>> options = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<int, string> answers = new Dictionary<int, string>();

            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> noOptions = new Dictionary<string, string>();
            int titleNo = 1;
            foreach (var item in lines)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    continue;
                }
                try
                {
                    //题目
                    var no = GetNo(item);
                    if (!string.IsNullOrWhiteSpace(no))
                    {
                        sb = new StringBuilder();
                        sb.Append(item.Substring(no.Length).Trim());
                        noOptions = new Dictionary<string, string>();
                        continue;
                    }
                    if (IsStartsWith(item, "A"))
                    {
                        var txt = sb.ToString().Trim();
                        titles.Add(titleNo, txt);
                        sb = new StringBuilder();
                        sb.AppendLine(item);
                        continue;
                    }
                    if (IsStartsWith(item, "B"))
                    {
                        var txt = sb.ToString().Trim();
                        noOptions.Add("A", txt);
                        sb = new StringBuilder();
                        sb.AppendLine(item);
                        continue;
                    }
                    if (IsStartsWith(item, "C"))
                    {
                        var txt = sb.ToString().Trim();
                        noOptions.Add("B", txt);
                        sb = new StringBuilder();
                        sb.AppendLine(item);
                        continue;
                    }
                    if (IsStartsWith(item, "D"))
                    {
                        var txt = sb.ToString().Trim();
                        noOptions.Add("C", txt);
                        sb = new StringBuilder();
                        sb.AppendLine(item);
                        continue;
                    }
                    if (IsStartsWith(item, "答案"))
                    {
                        var txt = sb.ToString().Trim();
                        noOptions.Add("D", txt);
                        options.Add(titleNo, noOptions);
                        answers.Add(titleNo++, item.Substring("答案：".Length).Trim());
                        continue;
                    }
                    sb.Append($"\t{item.Trim()}");
                }
                catch (Exception e)
                {
                    var txt = titles[titles.Values.Count - 1];
                    MessageBox.Show($"错误：{e.Message}，当前题目：{txt}");
                    break;
                }
            }

            StringBuilder newText = new StringBuilder();
            newText.AppendLine("[单选题]");
            foreach (var item in titles)
            {
                newText.AppendLine(item.Key + ".\t" + item.Value);
                if (options.ContainsKey(item.Key))
                {
                    var itemOptions = options[item.Key];
                    foreach (var itemOption in itemOptions)
                    {
                        newText.AppendLine($"{itemOption.Key}.\t{itemOption.Value}");
                    }
                }
            }
            newText.AppendLine("[试题答案]");
            foreach (var item in answers)
            {
                newText.AppendLine(item.Key + ".\t" + item.Value);
            }
            return newText.ToString();
        }
    }
}