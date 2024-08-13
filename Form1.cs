namespace Tecknogadged;
using FontAwesome.Sharp;
using System.Drawing;
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



public partial class Form1 : Form
{


    private Label title = new Label();
    private Label description = new Label();

    private TextBox name = new TextBox();
    private TextBox age = new TextBox();
    private TextBox salary = new TextBox();

    //Crear un contenedor lateral izquierdo
    private Panel leftPanel = new Panel();
    private IconButton icon1;
    private IconButton icon2;
    private IconButton icon3;
    private IconButton icon4;

    //dataGridView para mostrar los datos de la base de datos
    private DataGridView dataGridView;

    //Extraer las medidas de la pantalla del dispositivo


    public Form1()
    {

        InitializeComponent();
        // Inicializar el DataGridView
        dataGridView = new DataGridView();
        dataGridView.Location = new Point(300, 200);
        dataGridView.Size = new Size(1000, 300);
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridView.BorderStyle = BorderStyle.None;
        dataGridView.BackgroundColor = Color.White;
        dataGridView.EnableHeadersVisualStyles = false;
        dataGridView.RowHeadersVisible = false;
        dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
        dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68);
        dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.White;
        dataGridView.RowTemplate.Height = 50;
        dataGridView.ColumnHeadersHeight = 50;
        dataGridView.ReadOnly = true;

        Controls.Add(dataGridView);

        this.Load += new EventHandler(GetAllRegiters!);

        //----------------------------------------------------sizeBox izquierdo----------------------------------------------
        //Configuracion del sizeBox izquierdo, ocupar el todo el alto de la ventana y el 20% del ancho de la ventana
        leftPanel.Dock = DockStyle.Left;
        leftPanel.Width = (int)(Width * 0.3);
        leftPanel.BackColor = Color.FromArgb(31, 30, 68);
        Controls.Add(leftPanel);

        //Iconos para el sizeBox izquierdo
        icon1 = new IconButton();
        icon1.IconChar = IconChar.PeopleGroup;
        icon1.IconColor = Color.White;
        icon1.Dock = DockStyle.Top;
        icon1.FlatStyle = FlatStyle.Flat;
        icon1.FlatAppearance.BorderSize = 0;
        icon1.Text = "Atender";
        icon1.TextImageRelation = TextImageRelation.ImageBeforeText;
        icon1.Font = new Font("Arial", 12, FontStyle.Bold);
        icon1.ForeColor = Color.White;
        icon1.Height = 60;
        leftPanel.Controls.Add(icon1);

        icon2 = new IconButton();
        icon2.IconChar = IconChar.Desktop;
        icon2.IconColor = Color.White;
        icon2.Dock = DockStyle.Top;
        icon2.FlatStyle = FlatStyle.Flat;
        icon2.FlatAppearance.BorderSize = 0;
        icon2.Text = "Clientes";
        icon2.TextImageRelation = TextImageRelation.ImageBeforeText;
        icon2.Font = new Font("Arial", 12, FontStyle.Bold);
        icon2.ForeColor = Color.White;
        icon2.Height = 60;
        leftPanel.Controls.Add(icon2);

        icon3 = new IconButton();
        icon3.IconChar = IconChar.UserAlt;
        icon3.IconColor = Color.White;
        icon3.Dock = DockStyle.Top;
        icon3.FlatStyle = FlatStyle.Flat;
        icon3.FlatAppearance.BorderSize = 0;
        icon3.Text = "Perfil";
        icon3.TextImageRelation = TextImageRelation.ImageBeforeText;
        icon3.Font = new Font("Arial", 12, FontStyle.Bold);
        icon3.ForeColor = Color.White;
        icon3.Height = 60;
        leftPanel.Controls.Add(icon3);

        Panel sizeBox = new Panel();
        sizeBox.Dock = DockStyle.Top;
        sizeBox.Height = 40;
        sizeBox.BackColor = Color.FromArgb(31, 30, 68);
        leftPanel.Controls.Add(sizeBox);


        icon4 = new IconButton();
        icon4.IconChar = IconChar.UserEdit;
        icon4.IconColor = Color.White;
        icon4.FlatStyle = FlatStyle.Flat;
        icon4.FlatAppearance.BorderSize = 0;
        icon4.Height = 60;
        icon4.Width = 200;
        icon4.Text = "Nuevo cliente";
        icon4.TextImageRelation = TextImageRelation.ImageBeforeText;
        icon4.Font = new Font("Arial", 12, FontStyle.Bold);
        icon4.ForeColor = Color.White;
        icon4.BackColor = Color.FromArgb(26, 128, 229);
        int icon4X = (int)(leftPanel.Width * 0.08);
        int icon4Y = (int)(leftPanel.Height * 1.45);
        icon4.Location = new Point(icon4X, icon4Y);
        leftPanel.Controls.Add(icon4);


        Panel sizeBox2 = new Panel();
        sizeBox2.Dock = DockStyle.Bottom;
        sizeBox2.Height = 40;
        sizeBox2.BackColor = Color.FromArgb(31, 30, 68);
        leftPanel.Controls.Add(sizeBox2);




        //----------------------------------------------------Cuerpo del formulario----------------------------------------------

        //Titulo del negocio
        title.Text = "Clientes";
        title.Font = new Font("Arial", 20, FontStyle.Bold);
        title.Location = new Point(300, 50);
        title.Size = new Size(200, 50);
        Controls.Add(title);

        //Descripcion del negocio
        description.Text = "Filtra y atiende";
        description.Font = new Font("Arial", 15, FontStyle.Regular);
        description.ForeColor = Color.Gray;
        description.Location = new Point(300, 100);
        description.Size = new Size(300, 50);
        Controls.Add(description);



        //Campo de busqueda
        TextBox search = new TextBox();
        search.Font = new Font("Arial", 12, FontStyle.Regular);
        search.ForeColor = Color.White;
        search.Location = new Point(300, 150);
        search.Size = new Size(200, 50);
        search.BackColor = Color.FromArgb(31, 30, 68);
        search.BorderStyle = BorderStyle.FixedSingle;
        search.Font = new Font("Arial", 12, FontStyle.Regular);
        search.TextAlign = HorizontalAlignment.Center;
        Controls.Add(search);

        // //Campo de nombre 
        // name.Font = new Font("Arial", 12, FontStyle.Regular);
        // name.ForeColor = Color.White;
        // name.Location = new Point(350, 120);
        // name.Size = new Size(200, 50);
        // name.BackColor = Color.FromArgb(31, 30, 68);
        // name.BorderStyle = BorderStyle.FixedSingle;
        // name.Font = new Font("Arial", 12, FontStyle.Regular);
        // name.TextAlign = HorizontalAlignment.Center;
        // Controls.Add(name);

        // //Icono para el campo de nombre
        // IconPictureBox nameIcon = new IconPictureBox();
        // nameIcon.IconChar = IconChar.User;
        // nameIcon.IconColor = Color.FromArgb(31, 30, 68);
        // nameIcon.Location = new Point(300, 120);
        // nameIcon.Size = new Size(32, 32);
        // nameIcon.BackColor = Color.Transparent;
        // Controls.Add(nameIcon);

        // //Campo de edad
        // age = new TextBox();
        // age.ForeColor = Color.White;
        // age.Location = new Point(350, 180);
        // age.Size = new Size(200, 50);
        // age.BackColor = Color.FromArgb(31, 30, 68);
        // age.BorderStyle = BorderStyle.FixedSingle;
        // age.Font = new Font("Arial", 12, FontStyle.Regular);
        // age.TextAlign = HorizontalAlignment.Center;
        // Controls.Add(age);

        // //Icono para el campo de edad
        // IconPictureBox phoneIcon = new IconPictureBox();
        // phoneIcon.IconChar = IconChar.Baby;
        // phoneIcon.IconColor = Color.FromArgb(31, 30, 68);
        // phoneIcon.Location = new Point(300, 180);
        // phoneIcon.Size = new Size(32, 32);
        // phoneIcon.BackColor = Color.Transparent;
        // Controls.Add(phoneIcon);

        // //Campo de salario
        // salary = new TextBox();
        // salary.ForeColor = Color.White;
        // salary.Location = new Point(350, 240);
        // salary.Size = new Size(200, 50);
        // salary.BackColor = Color.FromArgb(31, 30, 68);
        // salary.BorderStyle = BorderStyle.FixedSingle;
        // salary.Font = new Font("Arial", 12, FontStyle.Regular);
        // salary.TextAlign = HorizontalAlignment.Center;
        // Controls.Add(salary);

        // //Icono para el campo de salario
        // IconPictureBox salaryIcon = new IconPictureBox();
        // salaryIcon.IconChar = IconChar.MoneyBill;
        // salaryIcon.IconColor = Color.FromArgb(31, 30, 68);
        // salaryIcon.Location = new Point(300, 240);
        // salaryIcon.Size = new Size(32, 32);
        // salaryIcon.BackColor = Color.Transparent;
        // Controls.Add(salaryIcon);

        // //Boton para enviar los datos
        // Button button = new Button();
        // button.Text = "Enviar";
        // button.Font = new Font("Arial", 12, FontStyle.Regular);
        // button.Location = new Point(350, 300);
        // button.Size = new Size(200, 50);
        // button.BackColor = Color.FromArgb(31, 30, 68);
        // button.ForeColor = Color.White;
        // button.FlatStyle = FlatStyle.Flat;
        // button.FlatAppearance.BorderSize = 0;
        // button.Click += new EventHandler(PostARegister!);
        // Controls.Add(button);



    }

    //Funcion de boton para conectar a la base de datos
    private void GetAllRegiters(object sender, EventArgs e)
    {
        // Instanciar la clase DbConnect y ejecutar la consulta
        DbConnect dbConnect = new DbConnect();
        string query = "SELECT * FROM customers";
        DataTable dataTable = dbConnect.ExecuteQuery(query);

        // Asignar los datos al DataGridView
        dataGridView.DataSource = dataTable;
    }
    //Boton que inserta datos en la tabla
    private void PostARegister(object sender, EventArgs e)
    {
        try
        {
            DbConnect dbConnect = new DbConnect();
            string query = "INSERT INTO customers (employee_name, age, salary) VALUES ('" + name.Text + "', " + age.Text + ", " + salary.Text + ")";
            dbConnect.ExecuteQuery(query);
            GetAllRegiters(sender, e);
            MessageBox.Show("Registro exitoso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }


}
