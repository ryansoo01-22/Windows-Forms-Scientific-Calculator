//CSC 222 ASSIGNMENT 23 SPRINT 3 12/14/22- Members of the team who worked on this: Ryan Soo, Fatima Nava, Kosi Onwuli, Liam Roberts
//Sprint 1 - Plan/Format the User Interface
//Sprint 2 - Research/find/plan algorithms to do mathematical calculations & implement mathematical calculations into User Interface
//Sprint 3 - Test for bugs / debug product / make QoL changes / add help menu

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RFKL_CS_Calculator
{
    public partial class Form1 : Form
    {
        string binres; 
        int decres;
        int value1 = 0;
        int value2 = 0;
        int conversion; //selects conversion
        int function; //selects arithmetic function


        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Base 2 (binary) arithmetic
        {
            function = this.comboBox2.SelectedIndex; //selected arithmetic function from dropdown box selection
            
            if(function == 0) //Binary Addition
            {
                this.textBox3.Text = "Base 2 (binary) Addition";
                try
                {
                    value1 = Convert.ToInt32(this.textBox1.Text, 2);
                    value2 = Convert.ToInt32(this.textBox4.Text, 2);
                    decres = value1 + value2;
                    binres = Convert.ToString(decres, 2);
                    string message = "Binary: " + "0b" + binres + " \n" + "Decimal: " + decres.ToString();
                    this.textBox2.Text = message;

                }
                catch (Exception ex)
                {
                    this.textBox2.Text = "Error on input. Please enter in a binary number that includes only 1s and 0s";
                }
            }
            else if(function == 1) //Binary Subtraction
            {
                this.textBox3.Text = "Base 2 (binary) Subtraction";
                try
                {
                    value1 = Convert.ToInt32(this.textBox1.Text, 2);
                    value2 = Convert.ToInt32(this.textBox4.Text, 2);
                    decres = value1 - value2;
                    binres = Convert.ToString(decres, 2);
                    string message = "Binary: " + "0b" + binres + " \n" + "Decimal: " + decres.ToString();
                    this.textBox2.Text = message;

                }
                catch (Exception ex)
                {
                    this.textBox2.Text = "Error on input. Please enter in a binary number that includes only 1s and 0s";
                }
            }
            else if(function == 2) //Binary Multiplication
            {
                this.textBox3.Text = "Base 2 (binary) Multiplication";
                try
                {
                    value1 = Convert.ToInt32(this.textBox1.Text, 2);
                    value2 = Convert.ToInt32(this.textBox4.Text, 2);
                    decres = value1 * value2;
                    binres = Convert.ToString(decres, 2);
                    string message = "Binary: " + "0b" + binres + " \n" + "Decimal: " + decres.ToString();
                    this.textBox2.Text = message;

                }
                catch (Exception ex)
                {
                    this.textBox2.Text = "Error on input. Please enter in a binary number that includes only 1s and 0s";
                }
            }
            else if(function == 3) //Binary Division
            {
                this.textBox3.Text = "Base 2 (binary) Division";
                try
                {
                    value1 = Convert.ToInt32(this.textBox1.Text, 2);
                    value2 = Convert.ToInt32(this.textBox4.Text, 2);
                    try
                    {
                        decres = value1 / value2;
                        binres = Convert.ToString(decres, 2);
                        Console.WriteLine("BINARY RESULT IS " + binres);
                        string message = "Binary: " + "0b" + binres + " \n" + "Decimal: " + decres.ToString();
                        this.textBox2.Text = message;

                    }
                    catch (Exception ex)
                    {
                        this.textBox2.Text = "Error on input. You cannot divide by zero";
                    }
                }
                catch (Exception ex)
                {
                    this.textBox2.Text = "Error on input. Please enter in a binary number that includes only 1s and 0s";
                }
            }
            else //no function selected
            {
                this.textBox2.Text = "Error on input. A binary arithmetic function was not selected. Please try again";
            }
            
        }

        private void button2_Click(object sender, EventArgs e) // Decimal/IP Address/MAC Address to Binary conversion
        {
            conversion = this.comboBox1.SelectedIndex; //selected conversion from dropdown box selection

            if (conversion == 0) //Decimal to Binary Conversion
            {
                try
                {
                    this.textBox3.Text = "Decimal to Binary Conversion";
                    int toConvert = Convert.ToInt32(textBox1.Text);
                    binres = Convert.ToString(toConvert, 2);
                    this.textBox2.Text = "0b" + binres;
                }
                catch
                {
                    this.textBox2.Text = "Error on input. Please enter in a decimal number";
                }
            }
            else if(conversion == 1) //Binary to Decimal Conversion
            {
                try
                {
                    this.textBox3.Text = "Binary to Decimal Conversion";
                    string binary = textBox1.Text;
                    int converted = Convert.ToInt32(binary, 2);
                    this.textBox2.Text = converted.ToString();
                }
                catch (Exception ex)
                {
                    this.textBox2.Text = "Error on input. Please enter in a binary number that includes only 1s and 0s";
                }
            }
            else if(conversion == 2) //IP Address to Binary Conversion
            {
                this.textBox3.Text = "IP Address to Binary Conversion";
                string ip_To_Binary = "";
                string ipOutput = "";
                string initialInput = textBox1.Text;
                Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                if (ip.IsMatch(initialInput))
                {
                    string[] ipAddress = textBox1.Text.Split('.');
                    foreach (string i in ipAddress)
                    {
                        int toConvert = Convert.ToInt32(i);
                        ip_To_Binary += Convert.ToString(toConvert, 2) + ".";
                        ipOutput = ip_To_Binary.Remove(ip_To_Binary.Length - 1, 1);
                        this.textBox2.Text = "IP Address in Binary: " + ipOutput;
                    }
                }
                else
                {
                    this.textBox2.Text = "Error on input. The IP address was not formatted correctly. Please use the format XXX.XXX.XXX.XXX";
                }
            }
            else if(conversion == 3) //MAC Address to Binary/Decimal Conversion
            {
                this.textBox3.Text = "MAC Address to Binary/Decimal Conversion";
                string MAC_To_Binary = "";
                string MAC_To_Decimal = "";
                string MAC_BinaryOutput = "";
                string MAC_DecimalOutput = "";
                string initialInput = textBox1.Text;
                Regex mac_separated = new Regex(@"^([0-9A-Fa-f]{2}[:.-]){5}([0-9A-Fa-f]{2})|([0-9a-fA-F]{4}\\.[0-9a-fA-F]{4}\\.[0-9a-fA-F]{4})$");
                Regex mac = new Regex(@"\d{12}");
                Regex mac_hex_decimal = new Regex(@"(...)\.(...)\.(...)\.(...)");

                if (mac_separated.IsMatch(initialInput) || mac.IsMatch(initialInput) || mac_hex_decimal.IsMatch(initialInput))
                {
                    Regex mac_decimal = new Regex(@"(...)\.(...)\.(...)\.(...)");
                    Regex mac_hyphen = new Regex(@"(..)\-(..)\-(..)\-(..)\-(..)\-(..)");
                    Regex mac_colon = new Regex(@"(..)\:(..)\:(..)\:(..)\:(..)\:(..)");
                    if (mac_decimal.IsMatch(initialInput)) //MAC address is in decimal separated format
                    {
                        string[] bytes = initialInput.Split('.');
                        Console.WriteLine(bytes);
                        foreach (string i in bytes)
                        {

                            int toConvert = int.Parse(i, System.Globalization.NumberStyles.HexNumber);
                            MAC_To_Binary += Convert.ToString(toConvert, 2) + ".";
                            MAC_To_Decimal += Convert.ToString(toConvert) + ".";
                            MAC_BinaryOutput = MAC_To_Binary.Remove(MAC_To_Binary.Length - 1, 1);
                            MAC_DecimalOutput = MAC_To_Decimal.Remove(MAC_To_Decimal.Length - 1, 1);
                            this.textBox3.Text = "MAC address to Binary/Decimal Conversion";
                            this.textBox2.Text = "MAC Address in Binary: " + MAC_BinaryOutput + "\r\n" + "MAC Address in Decimal: " + MAC_To_Decimal;
                        }
                    }
                    else if (mac_hyphen.IsMatch(initialInput)) //MAC address is in hyphen separated format
                    {
                        string[] MAC_Address = textBox1.Text.Split('-');
                        foreach (string i in MAC_Address)
                        {
                            int toConvert = int.Parse(i, System.Globalization.NumberStyles.HexNumber);
                            MAC_To_Binary += Convert.ToString(toConvert, 2) + "-";
                            MAC_To_Decimal += Convert.ToString(toConvert) + "-";
                            MAC_BinaryOutput = MAC_To_Binary.Remove(MAC_To_Binary.Length - 1, 1);
                            MAC_DecimalOutput = MAC_To_Decimal.Remove(MAC_To_Decimal.Length - 1, 1);
                            this.textBox3.Text = "MAC address to Binary/Decimal Conversion";
                            this.textBox2.Text = "MAC Address in Binary: " + MAC_BinaryOutput + "\r\n" + "MAC Address in Decimal: " + MAC_DecimalOutput;
                        }

                    }
                    else if (mac_colon.IsMatch(initialInput)) //MAC address is in colon separated format
                    {
                        string[] MAC_Address = textBox1.Text.Split(':');
                        foreach (string i in MAC_Address)
                        {
                            int toConvert = int.Parse(i, System.Globalization.NumberStyles.HexNumber);
                            MAC_To_Binary += Convert.ToString(toConvert, 2) + ":";
                            MAC_To_Decimal += Convert.ToString(toConvert) + ":";
                            MAC_BinaryOutput = MAC_To_Binary.Remove(MAC_To_Binary.Length - 1, 1);
                            MAC_DecimalOutput = MAC_To_Decimal.Remove(MAC_To_Decimal.Length - 1, 1);
                            this.textBox3.Text = "MAC address to Binary/Decimal Conversion";
                            this.textBox2.Text = "MAC Address in Binary: " + MAC_BinaryOutput + "\r\n" + "MAC Address in Decimal: " + MAC_DecimalOutput;
                        }
                    }
                    else //MAC address no separators 
                    {
                        List<string> MAC_Address = new List<string>();
                        for (int i = 0; i < initialInput.Length; i += 2)
                        {
                            string sub = initialInput.Substring(i, 2);
                            MAC_Address.Add(sub);
                        }
                        foreach (string i in MAC_Address)
                        {
                            int toConvert = int.Parse(i, System.Globalization.NumberStyles.HexNumber);
                            MAC_To_Binary += Convert.ToString(toConvert, 2) + ".";
                            MAC_To_Decimal += Convert.ToString(toConvert) + ".";
                            MAC_BinaryOutput = MAC_To_Binary.Remove(MAC_To_Binary.Length - 1, 1);
                            MAC_DecimalOutput = MAC_To_Decimal.Remove(MAC_To_Decimal.Length - 1, 1);
                            this.textBox3.Text = "MAC address to Binary/Decimal Conversion";
                            this.textBox2.Text = "MAC Address in Binary: " + MAC_BinaryOutput + "\r\n" + "MAC Address in Decimal: " + MAC_DecimalOutput;

                        }
                    }
                }
                else
                {
                    this.textBox2.Text = "Error on input. The MAC address was not formatted correctly. Please use the format XX.XX.XX.XX.XX.XX \n (decimals can be replaced with - or removed)";
                }
            }
            else
            {
                this.textBox2.Text = "Error on input. A conversion function was not selected. Please try again";
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e) //Clear Button
        {
            this.comboBox1.SelectedIndex = -1;
            this.comboBox2.SelectedIndex = -1;
            conversion = 4;
            function = 4;
            value1 = 0;
            value2 = 0;
            binres = "";
            decres = 0;
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox1.Focus();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void binaryAdditionToolStripMenuItem_Click(object sender, EventArgs e) //Arithmetic Base 2 Addition option in menu
        {
            string message = "This calculator can perform Base 2 (binary) addition. To do so please enter a binary number (1s and 0s) in each of the value text boxes and click calculate";
            System.Windows.Forms.MessageBox.Show(message, "Base 2 (binary) Addition");
            this.textBox1.Focus();
        }

        private void binarySubtractionToolStripMenuItem_Click(object sender, EventArgs e) //Arithmetic Base 2 Subtraction option in menu
        {
            string message = "This calculator can perform Base 2 (binary) subtraction. To do so please enter a binary number (1s and 0s) in each of the value text boxes and click calculate";
            System.Windows.Forms.MessageBox.Show(message, "Base 2 (binary) Subtraction");
            this.textBox1.Focus();
        }

        private void base2binaryMultiplicationToolStripMenuItem_Click(object sender, EventArgs e) //Arithmetic Base 2 Multiplication option in menu
        {
            string message = "This calculator can perform Base 2 (binary) multiplication. To do so please enter a binary number (1s and 0s) in each of the value text boxes and click calculate";
            System.Windows.Forms.MessageBox.Show(message, "Base 2 (binary) Multiplication");
            this.textBox1.Focus();
        }

        private void base2binaryDivisionToolStripMenuItem_Click(object sender, EventArgs e) //Arithmetic Base 2 Division option in menu
        {
            string message = "This calculator can perform Base 2 (binary) Division. To do so please enter a binary number (1s and 0s) in each of the value text boxes and click calculate";
            System.Windows.Forms.MessageBox.Show(message, "Base 2 (binary) Division");
            this.textBox1.Focus();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e) //Help option in menu. Gives user information about the clear button.
        {
            string message = "The clear button of this CS Calculator clears all output/input and allows new values and a new function to be entered into the calculator.";
            System.Windows.Forms.MessageBox.Show(message, "Clear");
            this.textBox1.Focus();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e) //Print option in menu. Gives user information about the print button
        {
            string message = "The print button of this CS Calculator prints your current output to the screen and then clears all output and input.";
            System.Windows.Forms.MessageBox.Show(message, "Print");
            this.textBox1.Focus();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(this.textBox2.Text);
            this.button9_Click(sender, e);
        }

        private void decimalToBinaryConversionToolStripMenuItem_Click(object sender, EventArgs e) //Decimal to Binary Conversion option in menu. Gives user information about the conversion
        {
            string message = "This CS Calculator can convert a decimal number input into a binary number. To do so please enter a decimal number into the value 1 text box, select Decimal to Binary Conversion, and click convert.";
            System.Windows.Forms.MessageBox.Show(message, "Decimal to Binary Conversion");
        }

        private void binaryToDecimalConversionToolStripMenuItem_Click(object sender, EventArgs e) //Binary to Decimal Conversion option in menu. Gives user information about the conversion
        {
            string message = "This CS Calculator can convert a binary (1s and 0s) number input into a decimal number. To do so please enter a binary number (1s and 0s) into the value 1 text box, select Binary to Decimal Conversion, and click convert.";
            System.Windows.Forms.MessageBox.Show(message, "Decimal to Binary Conversion");
        }

        private void iPAddressDecimalDottedOctetToBinaryDottedOctetConversionToolStripMenuItem_Click(object sender, EventArgs e) //IP Address Decimal Dotted Octet to Binary Dotted Octet Conversion option in menu. Gives user information about the conversion
        {
            string message = "This CS Calculator can convert an IP Address in decimal dotted octet format to a binary dotted octet format. To do so please enter an IP Address in decimal dotted octet format into the value 1 text box, select IP Address Decimal Dotted Octet to Binary Dotted Octet Conversion, and click convert.";
            System.Windows.Forms.MessageBox.Show(message, "IP Address Decimal Dotted Octet to Binary Dotted Octet Conversion");
        }

        private void mACAddressHexadecimalToBinaryConversionToolStripMenuItem_Click(object sender, EventArgs e) //MAC Address Hexadecimal to Binary Conversion option in menu. Gives user information about the conversion
        {
            string message = "This CS Calculator can convert a MAC Address in hexadecimal to a MAC Address in binary. To do so please enter a MAC Address in hexadecimal into the value 1 text box, select MAC Address Hexadecimal to Binary Conversion, and click convert.";
            System.Windows.Forms.MessageBox.Show(message, "MAC Address Hexadecimal to Binary Conversion");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) //Quit menu item. Clicking this closes the program.
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //About menu item. Clicking this gives some information about the program.
        {
            string message = "This CS Calculator has been produced by Team RFKL in CSC 222. The purpose of this calculator is to ease the difficulties of working with a combination of binary and decimal numbers.";
            System.Windows.Forms.MessageBox.Show(message, "About");
        }
    }
}
