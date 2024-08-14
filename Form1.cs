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

    private Panel rightPanel = new Panel();

    //dataGridView para mostrar los datos de la base de datos
    public DataGridView dataGridView = new DataGridView();

    //Extraer las medidas de la pantalla del dispositivo


    public Form1()
    {

        InitializeComponent();
        // Inicializar el DataGridView
        dataGridView.Location = new Point(300, 200);
        dataGridView.Size = new Size(1000, 500);
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

        rightPanel.Controls.Add(dataGridView);

        this.Load += new EventHandler(GetAllRegiters!);

        //----------------------------------------------------sizeBox izquierdo----------------------------------------------
        //Configuracion del sizeBox izquierdo, ocupar el todo el alto de la ventana y el 20% del ancho de la ventana
        leftPanel.Dock = DockStyle.Left;
        leftPanel.Width = (int)(Width * 0.3);
        leftPanel.BackColor = Color.FromArgb(31, 30, 68);
        Controls.Add(leftPanel);

        rightPanel.Dock = DockStyle.Fill;
        rightPanel.BackColor = Color.White;
        Controls.Add(rightPanel);

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
        icon4.Click += new EventHandler(OpenCustomerFormButton_Click!);
        leftPanel.Controls.Add(icon4);


        Panel sizeBox2 = new Panel();
        sizeBox2.Dock = DockStyle.Bottom;
        sizeBox2.Height = 40;
        sizeBox2.BackColor = Color.FromArgb(31, 30, 68);
        leftPanel.Controls.Add(sizeBox2);




        //----------------------------------------------------Cuerpo del panel derecho----------------------------------------------

        //Titulo del negocio
        title.Text = "Clientes";
        title.Font = new Font("Arial", 20, FontStyle.Bold);
        title.Location = new Point(300, 50);
        title.Size = new Size(200, 50);
        rightPanel.Controls.Add(title);

        //Descripcion del negocio
        description.Text = "Filtra y atiende";
        description.Font = new Font("Arial", 15, FontStyle.Regular);
        description.ForeColor = Color.Gray;
        description.Location = new Point(300, 100);
        description.Size = new Size(300, 50);
        rightPanel.Controls.Add(description);

        //Icono de busqueda
        IconPictureBox searchIcon = new IconPictureBox();
        searchIcon.IconChar = IconChar.Search;
        searchIcon.IconColor = Color.FromArgb(31, 30, 68);
        searchIcon.Location = new Point(300, 150);
        searchIcon.Size = new Size(32, 32);
        searchIcon.BackColor = Color.Transparent;
        rightPanel.Controls.Add(searchIcon);

        //Campo de busqueda
        TextBox search = new TextBox();
        search.Font = new Font("Arial", 12, FontStyle.Regular);
        search.ForeColor = Color.White;
        search.Location = new Point(350, 150);
        search.Size = new Size(200, 50);
        search.BackColor = Color.FromArgb(31, 30, 68);
        search.BorderStyle = BorderStyle.FixedSingle;
        search.Font = new Font("Arial", 12, FontStyle.Regular);
        search.TextAlign = HorizontalAlignment.Center;
        rightPanel.Controls.Add(search);



    }

    //Funcion de boton para conectar a la base de datos
    public void GetAllRegiters(object sender, EventArgs e)
    {
        // Instanciar la clase DbConnect y ejecutar la consulta
        DbConnect dbConnect = new DbConnect();
        string query = "SELECT * FROM customers ORDER BY fecha_traido DESC";
        DataTable dataTable = dbConnect.ExecuteQuery(query);

        // Asignar los datos al DataGridView
        dataGridView.DataSource = dataTable;

        // Manejar el evento CellFormatting para cambiar el color del texto de la columna "estatus"
        dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
    }

    private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView.Columns[e.ColumnIndex].Name == "estatus")
        {
            if (e.Value != null)
            {
                string estatus = e.Value.ToString();
                switch (estatus)
                {
                    case "PENDIENTE":
                        e.CellStyle.ForeColor = Color.Orange;
                        break;
                    case "ATRASADO":
                        e.CellStyle.ForeColor = Color.Red;
                        break;
                    case "REPARADO":
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case "ENTREGADO":
                        e.CellStyle.ForeColor = Color.DarkCyan;
                        break;
                    default:
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }
    }
    private void OpenCustomerFormButton_Click(object sender, EventArgs e)
    {
        using (CustomerForm customerForm = new CustomerForm(this))
        {
            customerForm.ShowDialog(Form1.ActiveForm);
        }
    }


}
