using System;
using System.Drawing;
using FontAwesome.Sharp;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Tecknogadged
{
    public partial class CustomerForm : Form
    {
        private TextBox name = new TextBox();
        private TextBox phone = new TextBox();
        private Form1 mainForm;

        //Selector de persona que recibio
        private ComboBox received_person = new ComboBox();
        //Selector de tipo de dispositivo
        private ComboBox type_device = new ComboBox();
        //Selector de modelo
        private ComboBox model = new ComboBox();
        //Selector de marca
        private ComboBox brand = new ComboBox();

        //Campo de texto para agregar una descripcion de la reparacion
        private TextBox description = new TextBox();




        Button sendButton = new Button();

        public CustomerForm(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(550, 420);


            // Titulo del modal
            Label title = new Label();
            title.Text = "Agregar nuevo cliente";
            title.Font = new Font("Arial", 16, FontStyle.Bold);
            title.ForeColor = Color.Black;
            title.Location = new Point(280, 20);
            title.Size = new Size(250, 50);
            Controls.Add(title);

            // Crear panel izquierdo
            Panel leftPanel = new Panel();
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.BackColor = Color.Transparent;
            Controls.Add(leftPanel);

            // Campo de nombre
            name.Font = new Font("Arial", 12, FontStyle.Regular);
            name.ForeColor = Color.White;
            name.Location = new Point(50, 50);
            name.Size = new Size(200, 100);
            name.BackColor = Color.FromArgb(31, 30, 68);
            name.BorderStyle = BorderStyle.FixedSingle;
            name.Font = new Font("Arial", 12, FontStyle.Regular);
            name.TextAlign = HorizontalAlignment.Center;
            leftPanel.Controls.Add(name);

            //Texto para el campo de nombre
            Label nameText = new Label();
            nameText.Text = "Nombre";
            nameText.Font = new Font("Arial", 12, FontStyle.Regular);
            nameText.ForeColor = Color.Black;
            nameText.Location = new Point(50, 20);
            nameText.Size = new Size(200, 50);
            leftPanel.Controls.Add(nameText);

            // Icono para el campo de nombre
            IconPictureBox nameIcon = new IconPictureBox();
            nameIcon.IconChar = IconChar.User;
            nameIcon.IconColor = Color.FromArgb(31, 30, 68);
            nameIcon.Location = new Point(10, 50);
            nameIcon.Size = new Size(32, 32);
            nameIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(nameIcon);

            // Campo de telefono
            phone = new TextBox();
            phone.ForeColor = Color.White;
            phone.Location = new Point(50, 120);
            phone.Size = new Size(200, 50);
            phone.BackColor = Color.FromArgb(31, 30, 68);
            phone.BorderStyle = BorderStyle.FixedSingle;
            phone.Font = new Font("Arial", 12, FontStyle.Regular);
            phone.TextAlign = HorizontalAlignment.Center;
            leftPanel.Controls.Add(phone);

            //Texto para el campo de telefono
            Label phoneText = new Label();
            phoneText.Text = "Telefono";
            phoneText.Font = new Font("Arial", 12, FontStyle.Regular);
            phoneText.ForeColor = Color.Black;
            phoneText.Location = new Point(50, 90);
            phoneText.Size = new Size(200, 50);
            leftPanel.Controls.Add(phoneText);

            // Icono para el campo de telefono
            IconPictureBox ageIcon = new IconPictureBox();
            ageIcon.IconChar = IconChar.Phone;
            ageIcon.IconColor = Color.FromArgb(31, 30, 68);
            ageIcon.Location = new Point(10, 120);
            ageIcon.Size = new Size(32, 32);
            ageIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(ageIcon);

            // Selector de tipo de dispositivo
            type_device.ForeColor = Color.White;
            type_device.Location = new Point(50, 190);
            type_device.Size = new Size(200, 50);
            type_device.BackColor = Color.FromArgb(31, 30, 68);
            type_device.FlatStyle = FlatStyle.Flat;
            type_device.DropDownStyle = ComboBoxStyle.DropDownList;
            type_device.Items.Add("Celular");
            type_device.Items.Add("Tablet");
            type_device.Items.Add("Laptop");
            type_device.Items.Add("Bocina");

            type_device.SelectedIndex = 0;
            leftPanel.Controls.Add(type_device);

            //Texto para el campo de tipo de dispositivo
            Label type_deviceText = new Label();
            type_deviceText.Text = "Tipo de dispositivo";
            type_deviceText.Font = new Font("Arial", 12, FontStyle.Regular);
            type_deviceText.ForeColor = Color.Black;
            type_deviceText.Location = new Point(50, 160);
            type_deviceText.Size = new Size(200, 50);
            leftPanel.Controls.Add(type_deviceText);

            // Icono para el campo de tipo de dispositivo
            IconPictureBox type_deviceIcon = new IconPictureBox();
            type_deviceIcon.IconChar = IconChar.MobileAlt;
            type_deviceIcon.IconColor = Color.FromArgb(31, 30, 68);
            type_deviceIcon.Location = new Point(10, 190);
            type_deviceIcon.Size = new Size(32, 32);
            type_deviceIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(type_deviceIcon);

            //Selector de marca
            brand.ForeColor = Color.White;
            brand.Location = new Point(50, 260);
            brand.Size = new Size(200, 50);
            brand.BackColor = Color.FromArgb(31, 30, 68);
            brand.FlatStyle = FlatStyle.Flat;
            brand.DropDownStyle = ComboBoxStyle.DropDownList;
            brand.Items.Add("Apple");
            brand.Items.Add("Samsung");
            brand.Items.Add("Huawei");
            brand.Items.Add("Xiaomi");
            leftPanel.Controls.Add(brand);

            //Texto para el campo de marca
            Label brandText = new Label();
            brandText.Text = "Marca";
            brandText.Font = new Font("Arial", 12, FontStyle.Regular);
            brandText.ForeColor = Color.Black;
            brandText.Location = new Point(50, 230);
            brandText.Size = new Size(200, 50);
            leftPanel.Controls.Add(brandText);

            // Icono para el campo de marca
            IconPictureBox brandIcon = new IconPictureBox();
            brandIcon.IconChar = IconChar.AppleAlt;
            brandIcon.IconColor = Color.FromArgb(31, 30, 68);
            brandIcon.Location = new Point(10, 260);
            brandIcon.Size = new Size(32, 32);
            brandIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(brandIcon);

            // Selector de modelo
            model.ForeColor = Color.White;
            model.Location = new Point(50, 330);
            model.Size = new Size(200, 50);
            model.BackColor = Color.FromArgb(31, 30, 68);
            model.FlatStyle = FlatStyle.Flat;
            model.DropDownStyle = ComboBoxStyle.DropDownList;
            model.Items.Add("Iphone 11");
            model.Items.Add("Samsung Galaxy S10");
            model.Items.Add("Huawei P30");
            model.Items.Add("Xiaomi Redmi Note 8");
            leftPanel.Controls.Add(model);

            //Texto para el campo de modelo
            Label modelText = new Label();
            modelText.Text = "Modelo";
            modelText.Font = new Font("Arial", 12, FontStyle.Regular);
            modelText.ForeColor = Color.Black;
            modelText.Location = new Point(50, 300);
            modelText.Size = new Size(200, 50);
            leftPanel.Controls.Add(modelText);

            // Icono para el campo de modelo
            IconPictureBox modelIcon = new IconPictureBox();
            modelIcon.IconChar = IconChar.Mobile;
            modelIcon.IconColor = Color.FromArgb(31, 30, 68);
            modelIcon.Location = new Point(10, 330);
            modelIcon.Size = new Size(32, 32);
            modelIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(modelIcon);

            // Selector de persona que recibio
            received_person.ForeColor = Color.White;
            received_person.Location = new Point(300, 120);
            received_person.Size = new Size(200, 50);
            received_person.BackColor = Color.FromArgb(31, 30, 68);
            received_person.FlatStyle = FlatStyle.Flat;
            received_person.DropDownStyle = ComboBoxStyle.DropDownList;
            received_person.Items.Add("Juan");
            received_person.Items.Add("Pedro");
            received_person.Items.Add("Maria");
            received_person.Items.Add("Ana");
            leftPanel.Controls.Add(received_person);

            //Texto para el campo de persona que recibio
            Label received_personText = new Label();
            received_personText.Text = "Persona que recibio";
            received_personText.Font = new Font("Arial", 12, FontStyle.Regular);
            received_personText.ForeColor = Color.Black;
            received_personText.Location = new Point(300, 90);
            received_personText.Size = new Size(200, 50);
            leftPanel.Controls.Add(received_personText);

            // Icono para el campo de persona que recibio
            IconPictureBox received_personIcon = new IconPictureBox();
            received_personIcon.IconChar = IconChar.User;
            received_personIcon.IconColor = Color.FromArgb(31, 30, 68);
            received_personIcon.Location = new Point(260, 120);
            received_personIcon.Size = new Size(32, 32);
            received_personIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(received_personIcon);

            //Campo de texto para agregar una descripcion de la reparacion
            description.ForeColor = Color.White;
            description.Location = new Point(300, 190);
            description.Multiline = true;
            description.ScrollBars = ScrollBars.Vertical;
            description.Size = new Size(200, 100);
            description.BackColor = Color.FromArgb(31, 30, 68);
            description.BorderStyle = BorderStyle.None;
            leftPanel.Controls.Add(description);

            //Texto para el campo de descripcion
            Label descriptionText = new Label();
            descriptionText.Text = "Motivo del fallo";
            descriptionText.Font = new Font("Arial", 12, FontStyle.Regular);
            descriptionText.ForeColor = Color.Black;
            descriptionText.Location = new Point(300, 160);
            descriptionText.Size = new Size(200, 50);
            leftPanel.Controls.Add(descriptionText);

            //Icono para el campo de descripcion
            IconPictureBox descriptionIcon = new IconPictureBox();
            descriptionIcon.IconChar = IconChar.Comment;
            descriptionIcon.IconColor = Color.FromArgb(31, 30, 68);
            descriptionIcon.Location = new Point(260, 190);
            descriptionIcon.Size = new Size(32, 32);
            descriptionIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(descriptionIcon);

            // Boton para enviar los datos
            sendButton.Text = "Registrar";
            sendButton.Font = new Font("Arial", 12, FontStyle.Regular);
            sendButton.Location = new Point(300, 300);
            sendButton.Size = new Size(200, 50);
            sendButton.BackColor = Color.FromArgb(31, 30, 68);
            sendButton.ForeColor = Color.White;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.Click += new EventHandler(PostARegister!);
            leftPanel.Controls.Add(sendButton);

        }

        protected override CreateParams CreateParams
        {
            get
            {
                // Oculta los controles superiores del formulario
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80; // WS_EX_TOOLWINDOW
                return cp;
            }
        }
        protected override void OnDeactivate(EventArgs e)
        {
            // Oculta el formulario al perder el foco
            base.OnDeactivate(e);
            Hide();
        }
        // Interceptar el mensaje de Windows para evitar mover el formulario
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int HTCAPTION = 0x2;

            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
            {
                return;
            }
            base.WndProc(ref m);
        }
        //Funcion para cerrar el modal 
        private void CloseModal(object sender, EventArgs e)
        {
            Hide();
        }

        //Boton que inserta datos en la tabla
        private void PostARegister(object sender, EventArgs e)
        {
            try
            {
                DbConnect dbConnect = new DbConnect();
                //Fecha de ingreso automatica
                String date_brought = DateTime.Now.ToString("yyyy-MM-dd");
                //Mostrar en un messafge box los datos que se van a insertar
                // MessageBox.Show("Nombre: " + name.Text + "\nTelefono: " + phone.Text + "\nTipo de dispositivo: " + type_device.Text + "\nMarca: " + brand.Text + "\nModelo: " + model.Text + "\nPersona que recibio: " + received_person.Text, "Datos a insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = $"INSERT INTO customers (Nombre_cliente, telefono, tipo_dispositivo, marca, modelo, estatus, fecha_traido, fecha_entregado, persona_recibio, persona_reparo) VALUES ('{name.Text}', '{phone.Text}', '{type_device.Text}', '{brand.Text}', '{model.Text}', 'PENDIENTE', '{date_brought}', NULL, '{received_person.Text}', 'NO REPARADO')";
                dbConnect.ExecuteQuery(query);
                mainForm.GetAllRegiters(sender, e);
                MessageBox.Show("Registro de cliente exitoso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CloseModal(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}