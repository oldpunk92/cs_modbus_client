using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace ModbusClient
{
    public partial class ModbusClient : Form
    {
        SerialPort sp;

        byte Function;

        byte[] DataSend;
        byte[] DataAnswer;

        int count = 0;
        int flag = 0;

        public ModbusClient()
        {
            InitializeComponent();
            AddBoxes();
            DefaultSettings();
        }

        private void ModbusClient_Load(object sender, EventArgs e)
        {
            
        }

        //Наполнение combobox'ов
        public void AddBoxes()
        {
            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                cbParity.Items.Add(s);
            }

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                cbSBit.Items.Add(s);
            }

            List<int> Datas = new List<int> { 8, 7, 6, 5 };
            List<int> BRates = new List<int> { 9600, 19200, 38400, 57600, 115200 };
            List<string> Functions = new List<string> { "01 Read Coil", "02 Read Contact", "03 Read Holding Register", "05 Write Coil", "06 Write Single Register" };
            cbData.DataSource = Datas;
            cbBRate.DataSource = BRates;
            cbFunction.DataSource = Functions;
        }

        private void cbCOM_Click(object sender, EventArgs e)
        {
            cbCOM.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                cbCOM.Items.Add(s);
            }
        }

        //Настройки по умолчанию
        public void DefaultSettings()
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                cbCOM.Items.Add(s);
            }

            cbCOM.Text = cbCOM.Items[0].ToString();

            Function = 1;
            cbData.Text = cbData.Items[0].ToString();
            cbBRate.Text = cbBRate.Items[0].ToString();
            cbParity.Text = cbParity.Items[0].ToString();
            cbSBit.Text = cbSBit.Items[1].ToString();
            tbAddress.Text = "1";
            tbStrtAdd.Text = "1";
            tbQuantity.Text = "1";
            bConnect.Visible = true;
            bDisconnect.Visible = false;
        }
      
        //При изменении функции изменяются возможности формы
        private void cbFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFunction.Text)
            {
                case "01 Read Coil":
                    Function = 1;

                    bOn.Visible = false;
                    bOff.Visible = false;
                    tbQuantity.Enabled = true;
                    bSend.Enabled = true;
                    label10.Visible = false;
                    tbWord.Visible = false;
                    
                    break;

                case "02 Read Contact":
                    Function = 2;

                    bOn.Visible = false;
                    bOff.Visible = false;
                    tbQuantity.Enabled = true;
                    bSend.Enabled = true;
                    label10.Visible = false;
                    tbWord.Visible = false;
                    break;

                case "03 Read Holding Register":
                    Function = 3;

                    bOn.Visible = false;
                    bOff.Visible = false;
                    tbQuantity.Enabled = true;
                    bSend.Enabled = true;
                    label10.Visible = false;
                    tbWord.Visible = false;
                    break;

                case "05 Write Coil":
                    Function = 5;

                    bOn.Visible = true;
                    bOff.Visible = true;
                    tbQuantity.Text = "1";
                    tbQuantity.Enabled = false;
                    bSend.Enabled = false;
                    label10.Visible = false;
                    tbWord.Visible = false;
                    break;

                case "06 Write Single Register":
                    Function = 6;

                    bOn.Visible = false;
                    bOff.Visible = false;
                    tbQuantity.Text = "1";
                    tbQuantity.Enabled = false;
                    bSend.Enabled = true;
                    label10.Visible = true;
                    tbWord.Visible = true;
                    break;

                case "10 Write Holding Register":
                    Function = 10;

                    bOn.Visible = false;
                    bOff.Visible = false;
                    bSend.Enabled = true;
                    label10.Visible = true;
                    tbWord.Visible = true;
                    break;
            }
        }

        private void CBPortSettingEnable()
        {
            cbCOM.Enabled = true;
            cbSBit.Enabled = true;
            cbData.Enabled = true;
            cbBRate.Enabled = true;
            cbParity.Enabled = true;
        }

        private void CBPortSettingDisable()
        {
            cbCOM.Enabled = false;
            cbSBit.Enabled = false;
            cbData.Enabled = false;
            cbBRate.Enabled = false;
            cbParity.Enabled = false;
        }

        //Открытие порта по нажатию на кнопку "Connect"
        private void bConnect_Click(object sender, EventArgs e)
        {
            try
            {               
                    sp = new SerialPort(cbCOM.Text)                
                    {                   
                        PortName = cbCOM.Text,
                        DataBits = Convert.ToInt16(cbData.Text),                    
                        BaudRate = Convert.ToInt16(cbBRate.Text),                   
                        Parity = (Parity)Enum.Parse(typeof(Parity), cbParity.Text),                   
                        StopBits = (StopBits)Enum.Parse(typeof(StopBits), cbSBit.Text),  
                        WriteTimeout = 500,                    
                        ReadTimeout = 500,
                    }; 
                    sp.Open();

                if (sp.IsOpen)
                {
                    CBPortSettingDisable();

                    rtRequest.Text += "Порт " + cbCOM.Text + " успешно открыт! \r\n";
                    rtRequest.SelectionStart = rtRequest.Text.Length;
                    rtRequest.ScrollToCaret();

                    bConnect.Visible = false;
                    bDisconnect.Visible = true;
                    count = 1;
                }
                else
                {
                    CBPortSettingEnable();

                    rtRequest.Text += "Ошибка открытия порта! \r\n";
                    rtRequest.SelectionStart = rtRequest.Text.Length;
                    rtRequest.ScrollToCaret();

                    count = 0;
                }
            }
            catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
        }

        //Закрытие порта по нажатию на кнопку "Disconnect"
        private void bDisconnect_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen && count == 1)
            {
                flag = 0;
                Thread.Sleep(50);

                sp.Close();

                rtRequest.Text += "Порт " + cbCOM.Text + " успешно закрыт! \r\n";
                rtRequest.SelectionStart = rtRequest.Text.Length;
                rtRequest.ScrollToCaret();
            }
            else
            {
                rtRequest.Text += "Порт " + cbCOM.Text + " уже закрыт! \r\n";
                rtRequest.SelectionStart = rtRequest.Text.Length;
                rtRequest.ScrollToCaret();
            }

            CBPortSettingEnable();

            bConnect.Visible = true;
            bDisconnect.Visible = false;
        }

        private async void bSend_Click(object sender, EventArgs e)
        {
            switch (Function)
            {
                case 1:
                    await ReadModbusRegistersAsinc();
                    break;
                case 3:
                    await ReadModbusRegistersAsinc();
                    break;
                case 6:
                    await WriteModbusSingleRegisterAsinc();
                    break;
                //case 16:
            }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            flag = 0;
        }

        private async void bOn_Click(object sender, EventArgs e)
        {
            await WriteModbusCoil(1);
        }

        private async void bOff_Click(object sender, EventArgs e)
        {
            await WriteModbusCoil(0);
        }


        //Асинхронная запись "1/0" в регистр
        private Task WriteModbusCoil(int control)
        {
            Task writembcoilOn = Task.Run(() =>
            {
            try
            {
                int id = Convert.ToInt16(tbAddress.Text);
                int startAddress = Convert.ToInt16(tbStrtAdd.Text);
                int length = Convert.ToInt16(tbQuantity.Text);
                int byteCount;

                ModbusFunction mf = new ModbusFunction(id, startAddress, length, control, out byteCount);

                DataSend = mf.WriteCoil(id, startAddress, length, control, out byteCount);
                DataAnswer = new byte [byteCount];

                rtRequest.Text += "Запись: " + BitConverter.ToString(DataSend).Replace("-", " ") + "\r\n";

                sp.Write(DataSend, 0, DataSend.Length);
                Thread.Sleep(50);
                sp.Read(DataAnswer, 0, DataAnswer.Length);

                rtRequest.Text += "Ответ: " + BitConverter.ToString(DataAnswer).Replace("-", " ") + " " 
                                            + mf.CheckCRC(DataAnswer) + " " 
                                            + mf.CheckErr(DataAnswer) + "\r\n" + "\r\n";

                Invoke(new Action(() =>
                    rtRequest.SelectionStart = rtRequest.Text.Length));
                Invoke(new Action(() =>
                    rtRequest.ScrollToCaret()));
            }
            catch (TimeoutException)
            {
                Invoke(new Action(() =>
                    rtRequest.Text += "Превышено время ожидания ответа!" + "\r\n" + "\r\n"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            });
            return writembcoilOn;
        }

        //Асинхронная отправка сформированного сообщения на чтение регистров
        private Task ReadModbusRegistersAsinc()
        {
            Task readmbregisters = Task.Run(() =>
            {
                try
                {
                    int id = Convert.ToInt16(tbAddress.Text);
                    int startAddress = Convert.ToInt16(tbStrtAdd.Text);
                    int length = Convert.ToInt16(tbQuantity.Text);
                    int byteCount;

                        ModbusFunction mf = new ModbusFunction(id, startAddress, length, out byteCount);

                        switch (Function)
                        {
                            case 1:
                                DataSend = mf.ReadCoil(id, startAddress, length, out byteCount);
                                DataAnswer = new byte[byteCount + 5];
                                break;
                            case 2:
                                DataSend = mf.ReadContact(id, startAddress, length, out byteCount);
                                DataAnswer = new byte[byteCount + 5];
                                break;
                            case 3:
                                DataSend = mf.ReadHoldingRegister(id, startAddress, length, out byteCount);
                                DataAnswer = new byte[byteCount + 5];
                                break;
                        }

                        flag = 1;

                        while (flag == 1)
                        {
                            Invoke(new Action(() =>
                                rtRequest.Text += "Запрос: " + BitConverter.ToString(DataSend).Replace("-", " ") + "\r\n"));

                            sp.Write(DataSend, 0, DataSend.Length);
                            Thread.Sleep(50);
                            sp.Read(DataAnswer, 0, DataAnswer.Length);

                            if (DataAnswer[1] < 80)
                            {
                                Invoke(new Action(() =>
                                    rtRequest.Text += "Ответ: " + BitConverter.ToString(DataAnswer).Replace("-", " ") + " " 
                                                                + mf.CheckCRC(DataAnswer) + " " 
                                                                + mf.CheckErr(DataAnswer) + "\r\n" + "\r\n"));
                            }
                            else
                            {
                                byte[] DataAnswerErr = new byte[5];

                                for (int i = 0; i < 5; i++)
                                    DataAnswerErr[i] = DataAnswer[i];

                                Invoke(new Action(() =>
                                     rtRequest.Text += "Ответ: " + BitConverter.ToString(DataAnswerErr).Replace("-", " ") + " " 
                                                                 + mf.CheckCRC(DataAnswer) + " " 
                                                                 + mf.CheckErr(DataAnswer) + "\r\n" + "\r\n"));
                            }

                            Invoke(new Action(() =>
                                rtRequest.SelectionStart = rtRequest.Text.Length));
                            Invoke(new Action(() =>
                                rtRequest.ScrollToCaret()));

                            Thread.Sleep(1000);
                        }
                }
                catch (TimeoutException)
                {
                    Invoke(new Action(() =>
                        rtRequest.Text += "Превышено время ожидания ответа!" + "\r\n" + "\r\n"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
            });
            return readmbregisters;
        }

        //Асинхронная запись одного значения в регистр
        private Task WriteModbusSingleRegisterAsinc()
        {
            Task writembregister = Task.Run(() =>
            {
                try
                {
                    int id = Convert.ToInt16(tbAddress.Text);
                    int startAddress = Convert.ToInt16(tbStrtAdd.Text);
                    int length = Convert.ToInt16(tbQuantity.Text);
                    int writevalue = 0;
                    int byteCount;

                    if (tbWord.Text == String.Empty) writevalue = 0;
                    else if (Convert.ToInt32(tbWord.Text) > 65535 && Convert.ToInt32(tbWord.Text) < 0) MessageBox.Show("Недопустимое значение ");
                    else writevalue = Convert.ToInt16(tbWord.Text);

                    ModbusFunction mf = new ModbusFunction(id, startAddress, length, writevalue, out byteCount);
                    DataSend = mf.WriteSingleRegister(id, startAddress, length, writevalue, out byteCount);
                    DataAnswer = new byte[byteCount];

                    Invoke(new Action(() =>
                             rtRequest.Text += "Запись: " + BitConverter.ToString(DataSend).Replace("-", " ") + "\r\n"));

                   sp.Write(DataSend, 0, DataSend.Length);
                   Thread.Sleep(50);
                   sp.Read(DataAnswer, 0, DataAnswer.Length);

                   if (DataAnswer[1] < 80)
                            {
                                Invoke(new Action(() =>
                                    rtRequest.Text += "Ответ: " + BitConverter.ToString(DataAnswer).Replace("-", " ") + " " 
                                                                + mf.CheckCRC(DataAnswer) + " " 
                                                                + mf.CheckErr(DataAnswer) + "\r\n" + "\r\n"));
                            }
                            else
                            {
                                byte[] DataAnswerErr = new byte[5];

                                for (int i = 0; i < 5; i++)
                                    DataAnswerErr[i] = DataAnswer[i];

                                Invoke(new Action(() =>
                                     rtRequest.Text += "Ответ: " + BitConverter.ToString(DataAnswerErr).Replace("-", " ") + " " 
                                                                 + mf.CheckCRC(DataAnswer) + " " 
                                                                 + mf.CheckErr(DataAnswer) + "\r\n" + "\r\n"));
                            }

                            Invoke(new Action(() =>
                                rtRequest.SelectionStart = rtRequest.Text.Length));
                            Invoke(new Action(() =>
                                rtRequest.ScrollToCaret()));
                    }
                catch (TimeoutException)
                {
                    Invoke(new Action(() =>
                        rtRequest.Text += "Превышено время ожидания ответа!" + "\r\n" + "\r\n"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
            });
            return writembregister;
        }


        /*   //Вычленение определенных величин из сообщения (например, аналоговая величина)
while (bSend.Enabled == false)
   {
       sp.Write(, 0, rezBox2Form.Text.Length / 2);
       sp.Read(answer, 0, MyClass.AnswerLenght * 2 + 5);
       txtreqestBox.Text += sendRegisterText + "\r\n" + BitConverter.ToString(answer).Replace("-", "") + "\r\n" + "\r\n";

       double tag = answer[3] * Math.Pow(16, 1) + answer[4] * Math.Pow(16, 0);

       convertBox.Text = tagBox.Text + " = " + Convert.ToString(tag);

       Thread.Sleep(500);
   }      
 */

    }

    //Класс для modbus-функций
    class ModbusFunction
    {
        int Id, StartAddress, Length, WriteValue;
        byte High, Low;

        //Конуструктор для чтения
        public ModbusFunction(int id, int startAddress, int length, out int byteCount)
        {
            byteCount = 1;
            this.Id = id;
            this.StartAddress = startAddress;
            this.Length = length;
        }

        //Конструктор для записи
        public ModbusFunction(int id, int startAddress, int length, int writevalue, out int byteCount)
        {
            byteCount = 1;
            this.Id = id;
            this.StartAddress = startAddress;
            this.Length = length;
            this.WriteValue = writevalue;
        }

        //чтение coil регистра
        public byte[] ReadCoil(int id, int startAddress, int length, out int byteCount)
        {
            byte[] data = new byte[8];

            data[0] = Convert.ToByte(id);
            data[1] = Convert.ToByte(1);
            byte[] _adr = BitConverter.GetBytes(startAddress);
            data[2] = _adr[1];
            data[3] = _adr[0];
            byte[] _length = BitConverter.GetBytes(length);
            data[4] = _length[1];
            data[5] = _length[0];
            CRC(data, 6, out High, out Low);
            data[6] = Low;
            data[7] = High;

            if (length > 8)
            {
                if(length % 8 == 0) byteCount = length;
                else byteCount = length+1;
            }
            else byteCount = 1;

            return data;
        }

        //чтение contact регистра
        public byte[] ReadContact(int id, int startAddress, int length, out int byteCount)
        {
            byte[] data = new byte[8];

            data[0] = Convert.ToByte(id);
            data[1] = Convert.ToByte(2);
            byte[] _adr = BitConverter.GetBytes(startAddress);
            data[2] = _adr[1];
            data[3] = _adr[0];
            byte[] _length = BitConverter.GetBytes(length);
            data[4] = _length[1];
            data[5] = _length[0];
            CRC(data, 6, out High, out Low);
            data[6] = Low;
            data[7] = High;

            if (length > 8)
            {
                if (length % 8 == 0) byteCount = length;
                else byteCount = length + 1;
            }
            else byteCount = 1;

            return data;
        }

        //для чтения holding регистров
        public byte[] ReadHoldingRegister(int id, int startAddress, int length, out int byteCount)
        {
            byte[] data = new byte[8];

            data[0] = Convert.ToByte(id);
            data[1] = Convert.ToByte(3);
            byte[] _adr = BitConverter.GetBytes(startAddress);
            data[2] = _adr[1];
            data[3] = _adr[0];
            byte[] _length = BitConverter.GetBytes(length);
            data[4] = _length[1];
            data[5] = _length[0];
            CRC(data, 6, out High, out Low);
            data[6] = Low;
            data[7] = High;

            if (length > 8)
            {
                if (length % 8 == 0) byteCount = 2*length;
                else byteCount = 2*length + 1;
            }
            else byteCount = 2;

            return data;
        }
        
        //запись coil регистра
        public byte[] WriteCoil(int id, int startAddress, int length, int control, out int byteCount)
        {
            byte[] data = new byte[8];

            if (control == 1)
                data[4] = 255;
            else data[4] = 0;

            data[0] = Convert.ToByte(id);
            data[1] = Convert.ToByte(5);
            byte[] _adr = BitConverter.GetBytes(startAddress);
            data[2] = _adr[1];
            data[3] = _adr[0];
            data[5] = 0;
            CRC(data, 6, out High, out Low);
            data[6] = Low;
            data[7] = High;

            byteCount = data.Length;

            return data;
        }

        //запись single регистра
        public byte[] WriteSingleRegister(int id, int startAddress, int length, int word, out int byteCount)
        {
            byte[] data = new byte[11];

            data[0] = Convert.ToByte(id);
            data[1] = Convert.ToByte(6);
            byte[] _adr = BitConverter.GetBytes(startAddress);
            data[2] = _adr[1];
            data[3] = _adr[0];
            byte[] _length = BitConverter.GetBytes(length);
            data[4] = _length[1];
            data[5] = _length[0];
            data[6] = Convert.ToByte(2 * length);
            byte[] _word = BitConverter.GetBytes(word);
            data[7] = _word[1];
            data[8] = _word[0];
            CRC(data, 9, out High, out Low);
            data[9] = Low;
            data[10] = High;

            byteCount = data.Length;

            return data;
        }


        //Расчет CRC для modbus RTU
        public void CRC (byte[] message, int length, out byte High, out byte Low)
        {
            ushort Full = 0xFFFF;
            for (int i = 0; i < length; i++)
            {
                Full = (ushort)(Full ^ message[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((Full & 0x0001) == 0)
                        Full = (ushort)(Full >> 1);
                    else
                    {
                        Full = (ushort)((Full >> 1) ^ 0xA001);
                    }
                }
            }
            High = (byte)((Full >> 8) & 0xFF);
            Low = (byte)(Full & 0xFF);
        }

        //Расчет LRC для modbus ASCII
        public byte LRC(byte[] message, int length)
        {
            ushort full = 0x00;
            for (int i = 0; i < length; i++)
                full = (ushort)(full + message[i]);
            if (full > 0xFF)
                full = (ushort)(full >> 1);
            full = (ushort)(0xFF - full + 0x01);
            return Convert.ToByte(full);
        }

        //Проверка контрольной суммы ответа от устройства
        public string CheckCRC(byte[] data)
        {
            string checkCRC;
            byte[] checkData = new byte[data.Length-2];
            for (int i = 0; i < data.Length - 2; i++)
                checkData[i] = data[i];
                CRC(checkData, checkData.Length, out High, out Low);
                if (((int)data[data.Length - 1] == (int)High) && ((int)data[data.Length - 2] == (int)Low))
                    checkCRC = "Контрольная сумма верна.";
                else checkCRC = "Ошибка контрольной суммы.";  
            return checkCRC;
        }

        //Обработка сообщений с ошибкой
        public string CheckErr(byte[] data)
        {
            string err = "";
            if (data[1]>80)
            {
                switch (data[2])
                {
                    case 1:
                        err = "Принятый код функции не может быть обработан.";
                        break;
                    case 2:
                        err = "Адрес данных недоступен.";
                        break;
                    case 3:
                        err = "Значение является недопустимой величиной.";
                        break;
                    default:
                        err = "Код ошибки: " + Convert.ToString(data[2]);
                        break;
                }
            }
            else err = "";
            return err;
        }
    }
}

