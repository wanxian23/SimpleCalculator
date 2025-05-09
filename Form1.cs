using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace revisionForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cBt_Click(object sender, EventArgs e)
        {
            resultTb.Text = "";
        }

        private void delBt_Click(object sender, EventArgs e)
        {
            int lengthString = resultTb.Text.Length;
            if (lengthString != 0)
                resultTb.Text = resultTb.Text.Substring(0, lengthString - 1);
        }

        private void oneBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "1";
        }

        private void twoBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "2";
        }

        private void threeBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "3";
        }

        private void fourBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "4";
        }

        private void fiveBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "5";
        }

        private void sixBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "6";
        }

        private void sevenBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "7";
        }

        private void eightBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "8";
        }

        private void nineBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "9";
        }

        private void divisionBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "/";
        }

        private void multiplyBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "x";
        }

        private void minusBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "-";
        }

        private void plusBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "+";
        }

        private void dotBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += ".";
        }

        private void modulusBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "%";
        }

        private void equalBt_Click(object sender, EventArgs e)
        {
            List<char> opr = new List<char>();
            List<double> number = new List<double>();
            string digit = "";
            string result = "";

            foreach (char character in resultTb.Text)
            {
                if (char.IsDigit(character) || character == '.')
                {
                    digit += character.ToString();
                }
                else if (digit != "" && (number.Count <= opr.Count) && digit != ".")
                {
                    number.Add(double.Parse(digit));
                    opr.Add(character);
                    digit = "";
                } 
                else
                {
                    resultTb.Text = "Math Error";
                    return;
                }
            }

            if (digit != "" && digit != ".")
                number.Add(double.Parse(digit));

            if (number.Count <= opr.Count)
            {
                result = "Math Error";
            } 
            else
            {
                if (opr.Count < 1)
                {
                    result = resultTb.Text;
                }
                else
                {
                    while (opr.Count > 0)
                    {
                        int index = 0;
                        bool mulDiv = false;

                        foreach (char mulDivOpr in opr)
                        {
                            if (mulDivOpr == 'x' || mulDivOpr == '/' || mulDivOpr == '%')
                            {
                                mulDiv = true;
                                break;
                            }
                            index++;
                        }

                        if (mulDiv)
                        {
                            switch (opr[index])
                            {
                                case 'x':
                                    result = (number[index] * number[index + 1]).ToString();
                                    break;
                                case '/':
                                    if (number[index + 1] != 0)
                                        result = (number[index] / number[index + 1]).ToString();
                                    else
                                    {
                                        result = "Math Error";
                                    }
                                    break;
                                case '%':
                                    if (number[index + 1] != 0)
                                    {
                                        double temp = Math.Floor(number[index] / number[index + 1]) * number[index + 1];
                                        result = (number[index] - temp).ToString();
                                    }

                                    else
                                    {
                                        result = "Math Error";
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            index = 0;
                            switch (opr[index])
                            {
                                case '+':
                                    result = (number[index] + number[index + 1]).ToString();
                                    break;
                                case '-':
                                    if (number[index + 1] != 0)
                                        result = (number[index] - number[index + 1]).ToString();
                                    else
                                    {
                                        result = "Math Error";
                                        break;
                                    }
                                    break;
                            }
                        }

                        if (result == "Math Error")
                            break;
                        else
                        {
                            opr.RemoveAt(index);
                            number.RemoveAt(index);
                            number[index] = double.Parse(result);
                        }
                    }
                }
            }

            resultTb.Text = result;
        }

        private void zeroBt_Click(object sender, EventArgs e)
        {
            resultTb.Text += "0";
        }
    }
}
