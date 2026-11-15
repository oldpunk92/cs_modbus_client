
namespace ModbusClient
{
    partial class ModbusClient
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.cbCOM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbData = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBRate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSBit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFunction = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbStrtAdd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.bSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bDisconnect = new System.Windows.Forms.Button();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bOff = new System.Windows.Forms.Button();
            this.bOn = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtRequest = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(79, 179);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(113, 20);
            this.tbAddress.TabIndex = 0;
            // 
            // cbCOM
            // 
            this.cbCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOM.FormattingEnabled = true;
            this.cbCOM.Location = new System.Drawing.Point(79, 27);
            this.cbCOM.Name = "cbCOM";
            this.cbCOM.Size = new System.Drawing.Size(113, 21);
            this.cbCOM.TabIndex = 1;
            this.cbCOM.Click += new System.EventHandler(this.cbCOM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Address ID";
            // 
            // cbData
            // 
            this.cbData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbData.FormattingEnabled = true;
            this.cbData.Location = new System.Drawing.Point(79, 54);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(113, 21);
            this.cbData.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data";
            // 
            // cbBRate
            // 
            this.cbBRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBRate.FormattingEnabled = true;
            this.cbBRate.Location = new System.Drawing.Point(79, 82);
            this.cbBRate.Name = "cbBRate";
            this.cbBRate.Size = new System.Drawing.Size(113, 21);
            this.cbBRate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "BaudRate";
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(79, 109);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(113, 21);
            this.cbParity.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Parity";
            // 
            // cbSBit
            // 
            this.cbSBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSBit.FormattingEnabled = true;
            this.cbSBit.Location = new System.Drawing.Point(79, 136);
            this.cbSBit.Name = "cbSBit";
            this.cbSBit.Size = new System.Drawing.Size(113, 21);
            this.cbSBit.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "StopBit";
            // 
            // cbFunction
            // 
            this.cbFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFunction.FormattingEnabled = true;
            this.cbFunction.Location = new System.Drawing.Point(79, 205);
            this.cbFunction.Name = "cbFunction";
            this.cbFunction.Size = new System.Drawing.Size(113, 21);
            this.cbFunction.TabIndex = 12;
            this.cbFunction.SelectedIndexChanged += new System.EventHandler(this.cbFunction_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Function";
            // 
            // tbStrtAdd
            // 
            this.tbStrtAdd.Location = new System.Drawing.Point(79, 232);
            this.tbStrtAdd.Name = "tbStrtAdd";
            this.tbStrtAdd.Size = new System.Drawing.Size(113, 20);
            this.tbStrtAdd.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Start Address";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(79, 258);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(113, 20);
            this.tbQuantity.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Quantity";
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(17, 304);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(75, 23);
            this.bConnect.TabIndex = 18;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(17, 333);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(75, 23);
            this.bSend.TabIndex = 19;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bDisconnect);
            this.groupBox1.Controls.Add(this.tbWord);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.bOff);
            this.groupBox1.Controls.Add(this.bOn);
            this.groupBox1.Controls.Add(this.bStop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbAddress);
            this.groupBox1.Controls.Add(this.bSend);
            this.groupBox1.Controls.Add(this.cbCOM);
            this.groupBox1.Controls.Add(this.bConnect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbData);
            this.groupBox1.Controls.Add(this.tbQuantity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbBRate);
            this.groupBox1.Controls.Add(this.tbStrtAdd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbParity);
            this.groupBox1.Controls.Add(this.cbFunction);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbSBit);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 405);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // bDisconnect
            // 
            this.bDisconnect.Location = new System.Drawing.Point(17, 304);
            this.bDisconnect.Name = "bDisconnect";
            this.bDisconnect.Size = new System.Drawing.Size(75, 23);
            this.bDisconnect.TabIndex = 24;
            this.bDisconnect.Text = "Disconnect";
            this.bDisconnect.UseVisualStyleBackColor = true;
            this.bDisconnect.Click += new System.EventHandler(this.bDisconnect_Click);
            // 
            // tbWord
            // 
            this.tbWord.Location = new System.Drawing.Point(104, 333);
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(117, 20);
            this.tbWord.TabIndex = 23;
            this.tbWord.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(146, 309);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Word";
            this.label10.Visible = false;
            // 
            // bOff
            // 
            this.bOff.Location = new System.Drawing.Point(104, 333);
            this.bOff.Name = "bOff";
            this.bOff.Size = new System.Drawing.Size(75, 23);
            this.bOff.TabIndex = 22;
            this.bOff.Text = "Off";
            this.bOff.UseVisualStyleBackColor = true;
            this.bOff.Visible = false;
            this.bOff.Click += new System.EventHandler(this.bOff_Click);
            // 
            // bOn
            // 
            this.bOn.Location = new System.Drawing.Point(104, 304);
            this.bOn.Name = "bOn";
            this.bOn.Size = new System.Drawing.Size(75, 23);
            this.bOn.TabIndex = 21;
            this.bOn.Text = "On";
            this.bOn.UseVisualStyleBackColor = true;
            this.bOn.Visible = false;
            this.bOn.Click += new System.EventHandler(this.bOn_Click);
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(17, 362);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 20;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtRequest);
            this.groupBox2.Location = new System.Drawing.Point(251, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 405);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request";
            // 
            // rtRequest
            // 
            this.rtRequest.Location = new System.Drawing.Point(6, 19);
            this.rtRequest.Name = "rtRequest";
            this.rtRequest.ReadOnly = true;
            this.rtRequest.Size = new System.Drawing.Size(525, 377);
            this.rtRequest.TabIndex = 0;
            this.rtRequest.Text = "";
            // 
            // ModbusClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModbusClient";
            this.Text = "ModbusClient";
            this.Load += new System.EventHandler(this.ModbusClient_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.ComboBox cbCOM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSBit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFunction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbStrtAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtRequest;
        private System.Windows.Forms.Button bOff;
        private System.Windows.Forms.Button bOn;
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bDisconnect;
    }
}

