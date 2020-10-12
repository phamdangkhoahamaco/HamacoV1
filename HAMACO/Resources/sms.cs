using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using DevExpress.XtraEditors;

namespace HAMACO.Resources
{
    class sms
    {
        private AutoResetEvent receiveNow;

        public bool AutoConnect(SerialPort _PORT)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                if (tryketnoi(_PORT, port))
                {
                    return true;
                }
            }
            return false;
        }
      
        private bool tryketnoi(SerialPort _PORT, string porname)
        {
            try
            {
                _PORT = OpenPort(_PORT, porname);

                if (_PORT != null)
                {
                    _PORT.Write("AT" + "\r");
                    return true;
                }
                else
                {
                    _PORT.Close();
                    _PORT.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                    _PORT = null;
                    return false;
                }
            }
            catch
            {
                _PORT.Close();
                _PORT.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                _PORT = null;
                return false;
            }
           
        }

        private SerialPort OpenPort(SerialPort _PORT, string porname)
        {
            receiveNow = new AutoResetEvent(false);
            SerialPort port = new SerialPort();
            try
            {
                _PORT.PortName = porname;                 //COM1
                _PORT.BaudRate = 9600;                   //9600
                _PORT.DataBits = 8;                   //8
                _PORT.StopBits = StopBits.One;                  //1
                _PORT.Parity = Parity.None;                     //None
                _PORT.ReadTimeout = 300;             //300
                _PORT.WriteTimeout = 300;           //300
                _PORT.Encoding = Encoding.GetEncoding("iso-8859-1");
                _PORT.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                _PORT.Open();
                _PORT.DtrEnable = true;
                _PORT.RtsEnable = true;
            }
            catch (Exception ex)
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port = null;
                throw ex;
            }
            return port;
        }

        private string ExecATCommand(SerialPort port, string command, int responseTimeout, string errorMessage)
        {
            try
            {
                if (port == null) throw new ApplicationException("Cổng chưa được kết nối!");
               
                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                receiveNow.Reset();
                port.Write(command + "\r");
                string input = ReadResponse(port, responseTimeout);

                if ((input.Length == 0) || ((!input.EndsWith("\r\n> ")) && (!input.EndsWith("\r\nOK\r\n"))))
                    throw new ApplicationException("Không có thông tin phản hồi.");

                return input;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(errorMessage + "\n" + ex.Message, ex);
            }
        }

        private string ReadResponse(SerialPort port, int timeout)
        {
            string buffer = string.Empty;
            try
            {
                do
                {
                    if (receiveNow.WaitOne(timeout, false))
                    {
                        string t = port.ReadExisting();
                        buffer += t;
                    }
                }
                while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\n> ") && !buffer.EndsWith("\r\nERROR\r\n"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return buffer;
        }

        public void sendsms(SerialPort port, string PhoneNo, string Message)
        {
            {
                string recievedData = ExecATCommand(port, "AT", 300, "Không có modem được kết nối!");

                recievedData = ExecATCommand(port, "AT+CMGF=1", 300, "Không thể thiết lập định dạng tin nhắn.");
                string aa = "GSM";
                recievedData = ExecATCommand(port, "AT+CSCS=\"" + aa + "\"", 300, "lỖI GSM");
                String command = "AT+CMGS=\"" + PhoneNo + "\"";
                recievedData = ExecATCommand(port, command, 300, "Không chấp nhận số điện thoại!");
               
                command = Message + char.ConvertFromUtf32(26);
               
                recievedData = ExecATCommand(port, command, 3000, "Failed to send message");
                XtraMessageBox.Show("Đã gửi đến " + PhoneNo + " nội dung:\n" + Message);
            }

        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                    receiveNow.Set();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
