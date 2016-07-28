using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        string operationPerformed = "",operationPerformed_last="";
        bool isOperationPerformed = false;
        double firstResult = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void general(string number)
        {
            if ((textBox_result.Text == "0") || (isOperationPerformed))
                textBox_result.Clear();
            isOperationPerformed = false;
            textBox_result.Text = textBox_result.Text + number;
        }
        private void button0_Click(object sender, EventArgs e)
        {
            general("0");
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            general("1");
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            general("2");
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            general("3");
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            general("4");
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            general("5");
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            general("6");
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            general("7");
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            general("8");
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            general("9");
        }

        private void button_point_Click(object sender, EventArgs e)
        {
            isOperationPerformed = false;
            if ((textBox_result.Text == "0") || (isOperationPerformed))
                textBox_result.Clear();
            if(!textBox_result.Text.Contains("."))
                textBox_result.Text = textBox_result.Text + ".";
        }

        

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                firstResult = resultValue;

                operationPerformed = button.Text;
                if(button.Text!="%")operationPerformed_last = operationPerformed;

                button_equal.PerformClick();
                if (button.Text == "+" || button.Text == "-" || button.Text == "*" || button.Text == "/")
                {
                    
                    labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                }
                else
                {
                    labelCurrentOperation.Text = "";
                }
                isOperationPerformed = true;
               
                
            }
            else
            {
                operationPerformed = button.Text;
                if (button.Text != "%") operationPerformed_last = operationPerformed;

                resultValue = Double.Parse(textBox_result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
                if (button.Text == "√" || button.Text=="+ -"||button.Text=="1/x") button_equal.PerformClick();
            }

        }

        private void button_delete_c_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
            resultValue = 0;
            labelCurrentOperation.Text = "";
        }

        private void button_delete_ce_Click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
        }

        private void button_equal_Click(object sender, EventArgs e)
        {


            switch(operationPerformed)
            {
                    
                case "+":
                    textBox_result.Text = (resultValue + Double.Parse(textBox_result.Text)).ToString();
                    
                    break;
                case "-":
                    textBox_result.Text = (resultValue - Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "*":
                    textBox_result.Text = (resultValue * Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "/":
                    textBox_result.Text = (resultValue / Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "√":
                    resultValue = Double.Parse(textBox_result.Text);
                    textBox_result.Text = (Math.Sqrt(resultValue)).ToString();
                    break;
                case "+ -":
                    resultValue = Double.Parse(textBox_result.Text);
                    textBox_result.Text = ((-1)*(resultValue)).ToString();
                    resultValue = Double.Parse(textBox_result.Text);
                    break;
                case "%":
                    textBox_result.Text =  (Double.Parse(textBox_result.Text) * resultValue/100).ToString();
                    //operator.PerformClick();
                    operationPerformed = operationPerformed_last;

                    //resultValue = Double.Parse(textBox_result.Text);

                    button_equal.PerformClick();
                    break;
                case "1/x":
                    resultValue = Double.Parse(textBox_result.Text);
                    textBox_result.Text = ((double)1/(resultValue)).ToString();
                    break;
                default: break;
            }
            if(operationPerformed!="%")
                resultValue = Double.Parse(textBox_result.Text);
          
            labelCurrentOperation.Text = "";
        }

        private void button_delete_one_Click(object sender, EventArgs e)
        {
            if (textBox_result.Text.Length > 1)
                textBox_result.Text = textBox_result.Text.Remove(textBox_result.Text.Length - 1, 1);
            else textBox_result.Text = "0";
        }


    }
}
