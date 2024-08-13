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
    TextBox salary = new TextBox();

    //Crear un contenedor lateral izquierdo
    private Panel leftPanel = new Panel();
    //dataGridView para mostrar los datos de la base de datos
    private DataGridView dataGridView;




    public Form1()
    {

        InitializeComponent();
        // Inicializar el DataGridView
        dataGridView = new DataGridView();
        dataGridView.Location = new Point(250, 400);
        dataGridView.Size = new Size(800, 300);
        dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        Controls.Add(dataGridView);

        this.Load += new EventHandler(GetAllRegiters!);

        //----------------------------------------------------panel izquierdo----------------------------------------------
        //Configuracion del panel izquierdo, ocupar el todo el alto de la ventana y el 20% del ancho de la ventana
        leftPanel.Dock = DockStyle.Left;
        leftPanel.Width = (int)(Width * 0.2);
        leftPanel.BackColor = Color.FromArgb(31, 30, 68);
        Controls.Add(leftPanel);

        //Iconos para el panel izquierdo
        IconButton icon1 = new IconButton();
        icon1.IconChar = IconChar.Sellcast;
        icon1.IconColor = Color.White;
        icon1.Dock = DockStyle.Top;
        icon1.FlatStyle = FlatStyle.Flat;
        icon1.FlatAppearance.BorderSize = 0;
        icon1.Height = 60;
        leftPanel.Controls.Add(icon1);

        IconButton icon2 = new IconButton();
        icon2.IconChar = IconChar.ShoppingCart;
        icon2.IconColor = Color.White;
        icon2.Dock = DockStyle.Top;
        icon2.FlatStyle = FlatStyle.Flat;
        icon2.FlatAppearance.BorderSize = 0;
        icon2.Height = 60;
        leftPanel.Controls.Add(icon2);

        IconButton icon3 = new IconButton();
        icon3.IconChar = IconChar.Bars;
        icon3.IconColor = Color.White;
        icon3.Dock = DockStyle.Top;
        icon3.FlatStyle = FlatStyle.Flat;
        icon3.FlatAppearance.BorderSize = 0;
        icon3.Height = 60;
        leftPanel.Controls.Add(icon3);

        Panel panel = new Panel();
        panel.Dock = DockStyle.Top;
        panel.Height = 40;
        panel.BackColor = Color.FromArgb(31, 30, 68);
        leftPanel.Controls.Add(panel);

        //----------------------------------------------------Cuerpo del formulario----------------------------------------------

        //Titulo del negocio
        title.Text = "Tecnogadged";
        title.Font = new Font("Arial", 20, FontStyle.Bold);
        title.Location = new Point(200, 10);
        title.Size = new Size(200, 50);
        Controls.Add(title);

        //Descripcion del negocio
        description.Text = "Formulario de registro de clientes";
        description.Font = new Font("Arial", 15, FontStyle.Regular);
        description.ForeColor = Color.Gray;
        description.Location = new Point(200, 60);
        description.Size = new Size(300, 50);
        Controls.Add(description);

        //Campo de nombre 
        name.Font = new Font("Arial", 12, FontStyle.Regular);
        name.ForeColor = Color.White;
        name.Location = new Point(250, 120);
        name.Size = new Size(200, 50);
        name.BackColor = Color.FromArgb(31, 30, 68);
        name.BorderStyle = BorderStyle.FixedSingle;
        name.Font = new Font("Arial", 12, FontStyle.Regular);
        name.TextAlign = HorizontalAlignment.Center;
        Controls.Add(name);

        //Icono para el campo de nombre
        IconPictureBox nameIcon = new IconPictureBox();
        nameIcon.IconChar = IconChar.User;
        nameIcon.IconColor = Color.FromArgb(31, 30, 68);
        nameIcon.Location = new Point(200, 120);
        nameIcon.Size = new Size(32, 32);
        nameIcon.BackColor = Color.Transparent;
        Controls.Add(nameIcon);

        //Campo de edad
        age = new TextBox();
        age.ForeColor = Color.White;
        age.Location = new Point(250, 180);
        age.Size = new Size(200, 50);
        age.BackColor = Color.FromArgb(31, 30, 68);
        age.BorderStyle = BorderStyle.FixedSingle;
        age.Font = new Font("Arial", 12, FontStyle.Regular);
        age.TextAlign = HorizontalAlignment.Center;
        Controls.Add(age);

        //Icono para el campo de edad
        IconPictureBox phoneIcon = new IconPictureBox();
        phoneIcon.IconChar = IconChar.Baby;
        phoneIcon.IconColor = Color.FromArgb(31, 30, 68);
        phoneIcon.Location = new Point(200, 180);
        phoneIcon.Size = new Size(32, 32);
        phoneIcon.BackColor = Color.Transparent;
        Controls.Add(phoneIcon);

        //Campo de salario
        salary = new TextBox();
        salary.ForeColor = Color.White;
        salary.Location = new Point(250, 240);
        salary.Size = new Size(200, 50);
        salary.BackColor = Color.FromArgb(31, 30, 68);
        salary.BorderStyle = BorderStyle.FixedSingle;
        salary.Font = new Font("Arial", 12, FontStyle.Regular);
        salary.TextAlign = HorizontalAlignment.Center;
        Controls.Add(salary);

        //Icono para el campo de salario
        IconPictureBox salaryIcon = new IconPictureBox();
        salaryIcon.IconChar = IconChar.MoneyBill;
        salaryIcon.IconColor = Color.FromArgb(31, 30, 68);
        salaryIcon.Location = new Point(200, 240);
        salaryIcon.Size = new Size(32, 32);
        salaryIcon.BackColor = Color.Transparent;
        Controls.Add(salaryIcon);

        //Boton para enviar los datos
        Button button = new Button();
        button.Text = "Enviar";
        button.Font = new Font("Arial", 12, FontStyle.Regular);
        button.Location = new Point(250, 300);
        button.Size = new Size(200, 50);
        button.BackColor = Color.FromArgb(31, 30, 68);
        button.ForeColor = Color.White;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Click += new EventHandler(PostARegister!);
        Controls.Add(button);



    }

    //Funcion de boton para conectar a la base de datos
    private void GetAllRegiters(object sender, EventArgs e)
    {
        // Instanciar la clase DbConnect y ejecutar la consulta
        DbConnect dbConnect = new DbConnect();
        string query = "SELECT * FROM employee"; // Reemplaza 'your_table' con el nombre de tu tabla
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
            string query = "INSERT INTO employee (employee_name, age, salary) VALUES ('" + name.Text + "', " + age.Text + ", " + salary.Text + ")";
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
