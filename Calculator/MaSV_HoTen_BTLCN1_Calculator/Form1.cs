using System.Text;

namespace MaSV_HoTen_BTLCN1_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            history = new List<string>();
        }
        #region bienvariable
        string _toantu = "";
        bool toantu_Clicked = false;
        double a = 0;
        private List<string> history;
        #endregion
        #region Method
        private void FormatNumberWithCommas()
        {
            string input = txt_kq.Text;

            if (int.TryParse(input, out int number))
            {
                string formattedNumber = number.ToString("#,###");

                txt_kq.Text = formattedNumber;
            }
        }
        private void ShowHistory()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string calculation in history)
            {
                sb.AppendLine(calculation);
            }

            MessageBox.Show(sb.ToString(), "Lịch sử các phép tính");
        }
        #endregion
        private void Number_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (toantu_Clicked)
            {
                txt_kq.Text = btn.Text;
                toantu_Clicked = false;
            }
            else
            {
                txt_kq.Text += btn.Text;
            }
            this.txt_kq.SelectionStart = txt_kq.Text.Length;
        }
        private void toantu_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!string.IsNullOrEmpty(txt_kq.Text))
            {
                a = double.Parse(txt_kq.Text);
                _toantu = btn.Text;
                txt_kq2.Text = txt_kq.Text + " " + _toantu;
                toantu_Clicked = true;
            }
        }

        private void cham_click(object sender, EventArgs e)
        {
            if (!txt_kq.Text.Contains("."))
            {
                Button btn = (Button)sender;
                txt_kq.Text += btn.Text;
                this.txt_kq.SelectionStart = txt_kq.Text.Length;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_kq.Text = "";
            txt_kq2.Text = "";
            btn_lichsu.Text = "";
            a = 0;
            _toantu = "";

            toantu_Clicked = false;
        }
        private void btn_clearentry_Click(object sender, EventArgs e)
        {
            txt_kq.Text = "";
            txt_kq2.Text = "";
            MessageBox.Show("Sua doi git!!");
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (txt_kq.Text != "")
            {
                txt_kq.Text = txt_kq.Text.Remove(txt_kq.Text.Length - 1, 1);
                txt_kq.SelectionStart = txt_kq.Text.Length;
            }
        }


        private void btn_amduong_Click(object sender, EventArgs e)
        {
            if (txt_kq.Text[0] == '-')
            {
                txt_kq.Text = txt_kq.Text.TrimStart('-');
            }
            else
            {
                txt_kq.Text = '-' + txt_kq.Text;
            }
        }
        private bool isLastCalculationAdded = false;

        private void btn_bang_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_kq.Text))
            {
                double b = double.Parse(txt_kq.Text);
                double ketqua = 0;
                switch (_toantu)
                {
                    case "+":
                        ketqua = a + b;
                        break;
                    case "-":
                        ketqua = a - b;
                        break;
                    case "x":
                        ketqua = a * b;
                        break;
                    case "/":
                        ketqua = a / b;
                        break;
                }
                txt_kq.Text = ketqua.ToString();
                txt_kq2.Text = txt_kq2.Text + " " + b + " = " + ketqua;
                toantu_Clicked = false;

                //them vao lich su
                string calculation = txt_kq2.Text + " " + txt_kq.Text + " = " + ketqua;
                history.Add(calculation);
                //

            }
        }

        private void btn_percent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_kq.Text))
            {
                double currentValue = Convert.ToDouble(txt_kq.Text);
                double percentageValue = currentValue / 100;
                txt_kq.Text = percentageValue.ToString();
                txt_kq2.Text = txt_kq.Text + " %";
            }
        }

        private void txt_kq_TextChanged(object sender, EventArgs e)
        {
            FormatNumberWithCommas();
        }

        private void btn_lichsu_Click(object sender, EventArgs e)
        {
            ShowHistory();
        }
    }
}
