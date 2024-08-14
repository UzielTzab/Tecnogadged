using System;
using System.Drawing;
using FontAwesome.Sharp;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Tecknogadged
{
    public partial class AtentionCustomerForm : Form
    {

        private Form1 mainForm;
        private ComboBox reparedPeron = new ComboBox();
        private ComboBox status = new ComboBox();

        //Campo de texto para agregar una descripcion de la reparacion
        private TextBox description = new TextBox();

        Button updateButton = new Button();

        int id = 1;
        String name = "Uziel";
        String statusNow = "NO REPARADO";


        public AtentionCustomerForm(Form1 form, int id, string name, string tipoDispositivo, string brand, string model, string problem, string statusNow)
        {
            this.name = name;
            this.statusNow = statusNow;
            this.id = id;
            InitializeComponent();
            mainForm = form;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(550, 550);

            // Titulo del modal
            Label title = new Label();
            title.Text = "Atender cliente";
            title.Font = new Font("Arial", 16, FontStyle.Bold);
            title.ForeColor = Color.Black;
            title.Location = new Point(280, 20);
            title.Size = new Size(250, 50);
            Controls.Add(title);

            //Titulo de datos del cleinte
            Label customerData = new Label();
            customerData.Text = "Datos del cliente";
            customerData.Font = new Font("Arial", 16, FontStyle.Bold);
            customerData.ForeColor = Color.Black;
            customerData.Location = new Point(50, 20);
            customerData.Size = new Size(200, 50);
            Controls.Add(customerData);


            // Crear panel izquierdo
            Panel leftPanel = new Panel();
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.BackColor = Color.Transparent;
            Controls.Add(leftPanel);

            //Plasmar en un label el nombre del cliente
            Label nameText = new Label();
            nameText.Text = name;
            nameText.Font = new Font("Arial", 12, FontStyle.Regular);
            nameText.ForeColor = Color.Gray;
            nameText.Location = new Point(50, 90);
            nameText.Size = new Size(200, 50);
            leftPanel.Controls.Add(nameText);

            //Icono para el nombre del cliente
            IconPictureBox nameIcon = new IconPictureBox();
            nameIcon.IconChar = IconChar.User;
            nameIcon.IconColor = Color.FromArgb(31, 30, 68);
            nameIcon.Location = new Point(10, 90);
            nameIcon.Size = new Size(32, 32);
            nameIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(nameIcon);

            //Plasmar en un label el tipo de dispositivo
            Label deviceTypeText = new Label();
            deviceTypeText.Text = tipoDispositivo;
            deviceTypeText.Font = new Font("Arial", 12, FontStyle.Regular);
            deviceTypeText.ForeColor = Color.Gray;
            deviceTypeText.Location = new Point(50, 150);
            deviceTypeText.Size = new Size(200, 50);
            leftPanel.Controls.Add(deviceTypeText);

            //Icono para el tipo de dispositivo
            IconPictureBox deviceTypeIcon = new IconPictureBox();
            deviceTypeIcon.IconChar = IconChar.MobileAlt;
            deviceTypeIcon.IconColor = Color.FromArgb(31, 30, 68);
            deviceTypeIcon.Location = new Point(10, 150);
            deviceTypeIcon.Size = new Size(32, 32);
            deviceTypeIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(deviceTypeIcon);

            //Plasmar en un label la marca del dispositivo
            Label brandText = new Label();
            brandText.Text = brand;
            brandText.Font = new Font("Arial", 12, FontStyle.Regular);
            brandText.ForeColor = Color.Gray;
            brandText.Location = new Point(50, 210);
            brandText.Size = new Size(200, 50);
            leftPanel.Controls.Add(brandText);

            //Icono para la marca del dispositivo
            IconPictureBox brandIcon = new IconPictureBox();
            brandIcon.IconChar = IconChar.Apple;
            brandIcon.IconColor = Color.FromArgb(31, 30, 68);
            brandIcon.Location = new Point(10, 210);
            brandIcon.Size = new Size(32, 32);
            brandIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(brandIcon);

            //Plasmar en un label el modelo del dispositivo
            Label modelText = new Label();
            modelText.Text = model;
            modelText.Font = new Font("Arial", 12, FontStyle.Regular);
            modelText.ForeColor = Color.Gray;
            modelText.Location = new Point(50, 270);
            modelText.Size = new Size(200, 50);
            leftPanel.Controls.Add(modelText);

            //Icono para el modelo del dispositivo
            IconPictureBox modelIcon = new IconPictureBox();
            modelIcon.IconChar = IconChar.MobileAlt;
            modelIcon.IconColor = Color.FromArgb(31, 30, 68);
            modelIcon.Location = new Point(10, 270);
            modelIcon.Size = new Size(32, 32);
            modelIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(modelIcon);

            //Plasmar en un label el problema del dispositivo
            Label problemText = new Label();
            problemText.Text = problem;
            problemText.Font = new Font("Arial", 12, FontStyle.Regular);
            problemText.ForeColor = Color.Gray;
            problemText.Location = new Point(50, 330);
            problemText.Size = new Size(200, 50);
            leftPanel.Controls.Add(problemText);

            //Icono para el problema del dispositivo
            IconPictureBox problemIcon = new IconPictureBox();
            problemIcon.IconChar = IconChar.ExclamationCircle;
            problemIcon.IconColor = Color.FromArgb(31, 30, 68);
            problemIcon.Location = new Point(10, 330);
            problemIcon.Size = new Size(32, 32);
            problemIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(problemIcon);

            //Plasmar en un label el estatus del dispositivo
            Label statusNowText = new Label();
            statusNowText.Text = statusNow;
            statusNowText.Font = new Font("Arial", 12, FontStyle.Regular);
            statusNowText.ForeColor = Color.Gray;
            statusNowText.Location = new Point(50, 390);
            statusNowText.Size = new Size(200, 50);
            leftPanel.Controls.Add(statusNowText);

            //Icono para el estatus del dispositivo
            IconPictureBox statusNowIcon = new IconPictureBox();
            statusNowIcon.IconChar = IconChar.CheckCircle;
            statusNowIcon.IconColor = Color.FromArgb(31, 30, 68);
            statusNowIcon.Location = new Point(10, 390);
            statusNowIcon.Size = new Size(32, 32);
            statusNowIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(statusNowIcon);




            // Selector de persona que reparo
            reparedPeron.ForeColor = Color.White;
            reparedPeron.Location = new Point(300, 120);
            reparedPeron.Size = new Size(200, 50);
            reparedPeron.BackColor = Color.FromArgb(31, 30, 68);
            reparedPeron.FlatStyle = FlatStyle.Flat;
            reparedPeron.DropDownStyle = ComboBoxStyle.DropDownList;
            reparedPeron.Items.Add("Juan");
            reparedPeron.Items.Add("Pedro");
            reparedPeron.Items.Add("Maria");
            reparedPeron.Items.Add("Ana");
            leftPanel.Controls.Add(reparedPeron);

            //Texto para el campo de persona que reparo
            Label received_personText = new Label();
            received_personText.Text = "Persona que reparo";
            received_personText.Font = new Font("Arial", 12, FontStyle.Regular);
            received_personText.ForeColor = Color.Black;
            received_personText.Location = new Point(300, 90);
            received_personText.Size = new Size(200, 50);
            leftPanel.Controls.Add(received_personText);

            // Icono para el campo de persona que reparo
            IconPictureBox received_personIcon = new IconPictureBox();
            received_personIcon.IconChar = IconChar.User;
            received_personIcon.IconColor = Color.FromArgb(31, 30, 68);
            received_personIcon.Location = new Point(260, 120);
            received_personIcon.Size = new Size(32, 32);
            received_personIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(received_personIcon);

            //Selector de estatus
            status.ForeColor = Color.White;
            status.Location = new Point(300, 200);
            status.Size = new Size(200, 50);
            status.BackColor = Color.FromArgb(31, 30, 68);
            status.FlatStyle = FlatStyle.Flat;
            status.DropDownStyle = ComboBoxStyle.DropDownList;
            status.Items.Add("NO REPARADO");
            status.Items.Add("REPARADO");
            leftPanel.Controls.Add(status);

            //Texto para el campo de estatus
            Label statusText = new Label();
            statusText.Text = "Estatus";
            statusText.Font = new Font("Arial", 12, FontStyle.Regular);
            statusText.ForeColor = Color.Black;
            statusText.Location = new Point(300, 170);
            statusText.Size = new Size(200, 50);
            leftPanel.Controls.Add(statusText);

            //Icono para el campo de estatus
            IconPictureBox statusIcon = new IconPictureBox();
            statusIcon.IconChar = IconChar.CheckCircle;
            statusIcon.IconColor = Color.FromArgb(31, 30, 68);
            statusIcon.Location = new Point(260, 200);
            statusIcon.Size = new Size(32, 32);
            statusIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(statusIcon);

            //Campo de texto para agregar una descripcion de la reparacion
            description.ForeColor = Color.White;
            description.Location = new Point(300, 280);
            description.Multiline = true;
            description.ScrollBars = ScrollBars.Vertical;
            description.Size = new Size(200, 100);
            description.BackColor = Color.FromArgb(31, 30, 68);
            description.BorderStyle = BorderStyle.None;
            leftPanel.Controls.Add(description);

            //Texto para el campo de descripcion
            Label descriptionText = new Label();
            descriptionText.Text = "Diagnostico";
            descriptionText.Font = new Font("Arial", 12, FontStyle.Regular);
            descriptionText.ForeColor = Color.Black;
            descriptionText.Location = new Point(300, 250);
            descriptionText.Size = new Size(200, 50);
            leftPanel.Controls.Add(descriptionText);

            //Icono para el campo de descripcion
            IconPictureBox descriptionIcon = new IconPictureBox();
            descriptionIcon.IconChar = IconChar.Comment;
            descriptionIcon.IconColor = Color.FromArgb(31, 30, 68);
            descriptionIcon.Location = new Point(260, 280);
            descriptionIcon.Size = new Size(32, 32);
            descriptionIcon.BackColor = Color.Transparent;
            leftPanel.Controls.Add(descriptionIcon);

            //Boton para actualizar el registro
            updateButton.Text = "Atender";
            updateButton.Font = new Font("Arial", 12, FontStyle.Bold);
            updateButton.ForeColor = Color.White;
            updateButton.BackColor = Color.FromArgb(31, 30, 68);
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.Location = new Point(300, 400);
            updateButton.Size = new Size(200, 50);
            updateButton.Click += new EventHandler(PutARegister);
            leftPanel.Controls.Add(updateButton);

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
        private void PutARegister(object sender, EventArgs e)
        {
            try
            {
                DbConnect dbConnect = new DbConnect();

                // Construir la consulta SQL para actualizar los campos persona_reparo y estatus
                string query = "UPDATE customers SET " +
                               "persona_reparo = @reparedPerson, " +
                               "estatus = @status " +
                               "WHERE id = @id";

                // Crear el comando y agregar los parámetros
                using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.Connection))
                {
                    cmd.Parameters.AddWithValue("@reparedPerson", reparedPeron.Text); // Reemplazar con el valor real
                    cmd.Parameters.AddWithValue("@status", status.Text); // Reemplazar con el valor real
                    cmd.Parameters.AddWithValue("@id", id); // Reemplazar con el ID del registro que deseas actualizar

                    // Abrir la conexión y ejecutar la consulta
                    dbConnect.OpenConnection();
                    cmd.ExecuteNonQuery();
                    dbConnect.CloseConnection();
                }

                // Actualizar la vista principal y mostrar un mensaje de éxito
                mainForm.GetAllRegiters(sender, e);
                MessageBox.Show("Se atendió correctamente el cliente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CloseModal(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}