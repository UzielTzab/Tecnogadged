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
        dataGridView.Location = new Point(250, 200);
        dataGridView.Size = new Size(1200, 500);
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
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
        icon1.Click += new EventHandler(ShowAtentionPanel!);
        leftPanel.Controls.Add(icon1);

        icon2 = new IconButton();
        icon2.IconChar = IconChar.Mobile;
        icon2.IconColor = Color.White;
        icon2.Dock = DockStyle.Top;
        icon2.FlatStyle = FlatStyle.Flat;
        icon2.FlatAppearance.BorderSize = 0;
        icon2.Text = "Entregas";
        icon2.TextImageRelation = TextImageRelation.ImageBeforeText;
        icon2.Font = new Font("Arial", 12, FontStyle.Bold);
        icon2.ForeColor = Color.White;
        icon2.Height = 60;
        icon2.Click += new EventHandler(ShowDeliveriesPanel!);
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

    // Método para obtener todos los registros de la tabla "customers" y mostrarlos en el DataGridView
    public void GetAllRegiters(object sender, EventArgs e)
    {
        // Instanciar la clase DbConnect y ejecutar la consulta
        DbConnect dbConnect = new DbConnect();
        string query = "SELECT * FROM customers WHERE estatus IN ('PENDIENTE', 'ATRASADO') ORDER BY fecha_traido DESC";
        // Verificar si la columna "Acciones" ya existe
        if (!dataGridView.Columns.Contains("Acciones"))
        {
            // Agregar la columna de botones "Acciones"
            DataGridViewButtonColumn accionesColumn = new DataGridViewButtonColumn();
            accionesColumn.Name = "Acciones";
            accionesColumn.HeaderCell.Style.ForeColor = Color.Green;
            accionesColumn.HeaderText = "Acciones";
            accionesColumn.Text = "Atender";
            accionesColumn.UseColumnTextForButtonValue = true; // Mostrar el texto en los botones    
            dataGridView.Columns.Add(accionesColumn);
        }
        // Verificar la columna de botones "Eliminar"
        if (!dataGridView.Columns.Contains("Eliminar"))
        {
            // Agregar la columna de botones "Eliminar"
            DataGridViewButtonColumn accionesColumn = new DataGridViewButtonColumn();
            accionesColumn.Name = "Eliminar";
            accionesColumn.HeaderCell.Style.ForeColor = Color.Red;
            accionesColumn.HeaderText = "Eliminar";
            accionesColumn.Text = "Borrar";
            accionesColumn.UseColumnTextForButtonValue = true; // Mostrar el texto en los botones    
            dataGridView.Columns.Add(accionesColumn);

        }
        DataTable dataTable = dbConnect.ExecuteQuery(query);

        // Asignar los datos al DataGridView
        dataGridView.DataSource = dataTable;
        // Deshabilitar la opción de agregar nuevas filas
        dataGridView.AllowUserToAddRows = false;



        // Desuscribirse de los eventos para evitar múltiples suscripciones
        dataGridView.CellFormatting -= dataGridView_CellFormatting;
        dataGridView.CellClick -= dataGridView_CellClick;

        // Manejar el evento CellFormatting para cambiar el color del texto de la columna "estatus"
        dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);

        // Manejar el evento CellClick para capturar los clics en los botones de la columna "Acciones"
        dataGridView.CellClick += new DataGridViewCellEventHandler(dataGridView_CellClick);
    }

    // Método para obtener los registros que contengan "REPARADO" en la columna "estatus"
    private void GetRepairedRegisters(object sender, EventArgs e)
    {
        // Instanciar la clase DbConnect y ejecutar la consulta
        DbConnect dbConnect = new DbConnect();
        string query = "SELECT * FROM customers WHERE estatus = 'REPARADO' ORDER BY fecha_entregado DESC";
        DataTable dataTable = dbConnect.ExecuteQuery(query);

        // Asignar los datos al DataGridView
        dataGridView.DataSource = dataTable;
        // Deshabilitar la opción de agregar nuevas filas
        dataGridView.AllowUserToAddRows = false;

        // Desuscribirse de los eventos para evitar múltiples suscripciones
        dataGridView.CellFormatting -= dataGridView_CellFormatting;
        dataGridView.CellClick -= dataGridView_CellClick;

        // Manejar el evento CellFormatting para cambiar el color del texto de la columna "estatus"
        dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);

        // Manejar el evento CellClick para capturar los clics en los botones de la columna "Acciones"
        dataGridView.CellClick += new DataGridViewCellEventHandler(dataGridView_CellClick);
    }

    // Manejador de eventos para el clic en los botones de la columna "Acciones"
    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // Verificar si el clic fue en la columna de botones
        if (e.ColumnIndex == dataGridView.Columns["Acciones"].Index && e.RowIndex >= 0)
        {
            // Obtener el valor de la celda de la fila correspondiente
            var cellValue = dataGridView.Rows[e.RowIndex].Cells["Acciones"].Value;
            // Aquí puedes agregar la lógica que deseas ejecutar cuando se haga clic en el botón
            //Pasar el datos de ese cleinte al formulario de atencion
            int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["id"].Value);
            string name = dataGridView.Rows[e.RowIndex].Cells["Nombre_cliente"].Value.ToString();
            string tipoDispositivo = dataGridView.Rows[e.RowIndex].Cells["tipo_dispositivo"].Value.ToString();
            string brand = dataGridView.Rows[e.RowIndex].Cells["marca"].Value.ToString();
            string model = dataGridView.Rows[e.RowIndex].Cells["modelo"].Value.ToString();
            // string problem = dataGridView.Rows[e.RowIndex].Cells["problema"].Value.ToString();
            string statusNow = dataGridView.Rows[e.RowIndex].Cells["estatus"].Value.ToString();

            OpenAtentionFormButton_Click(sender, e, id, name, tipoDispositivo, brand, model, "Decripcion del problema aquí", statusNow);
        }
        // Verificar si el clic fue en la columna de eliminar
        if (e.ColumnIndex == dataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
        {
            // Obtener el valor de la celda de la fila correspondiente
            var cellValue = dataGridView.Rows[e.RowIndex].Cells["Eliminar"].Value;
            // Aquí puedes agregar la lógica que deseas ejecutar cuando se haga clic en el botón
            //Pasar el datos de ese cleinte al formulario de atencion
            int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["id"].Value);

            DeleteRecordById(id);

        }

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
                    case "NO REPARADO":
                        e.CellStyle.ForeColor = Color.DarkRed;
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
    private void OpenAtentionFormButton_Click(object sender, EventArgs e, int id, string name, string tipoDispositivo, string brand, string model, string problem, string statusNow)
    {
        using (AtentionCustomerForm customerForm = new AtentionCustomerForm(this, id: id, name: name, tipoDispositivo: tipoDispositivo, brand: brand, model: model, problem: problem, statusNow: statusNow))
        {
            customerForm.ShowDialog(Form1.ActiveForm);
        }
    }
    private void DeleteRecordById(int id)
    {
        // Preguntar al usuario si está seguro de eliminar el registro
        DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (result == DialogResult.Yes)
        {
            // Instanciar la clase DbConnect y ejecutar la consulta de eliminación
            DbConnect dbConnect = new DbConnect();
            string query = $"DELETE FROM customers WHERE id = {id}";
            dbConnect.ExecuteQuery(query);

            // Actualizar el DataGridView después de eliminar el registro
            GetAllRegiters(null, null);

            MessageBox.Show("Se eliminó correctamente el cliente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    // Método para mostrar el panel de entregas
    private void ShowDeliveriesPanel(object sender, EventArgs e)
    {
        // Limpiar el rightPanel
        rightPanel.Controls.Clear();

        // Agregar nuevos controles al rightPanel
        //Titulo del apartado
        title.Text = "Entregas";
        title.Font = new Font("Arial", 20, FontStyle.Bold);
        title.Location = new Point(300, 50);
        title.Size = new Size(200, 50);
        rightPanel.Controls.Add(title);

        //Descripcion del apartado
        description.Text = "Entrega los pendientes";
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

        this.Load += new EventHandler(GetRepairedRegisters!);// Cargar los registros de "Entregas"
    }
    // Método para mostrar el panel de atencion
    private void ShowAtentionPanel(object sender, EventArgs e)
    {
        // Limpiar el rightPanel
        rightPanel.Controls.Clear();

        // Agregar nuevos controles al rightPanel
        //Titulo del apartado
        title.Text = "Clientes";
        title.Font = new Font("Arial", 20, FontStyle.Bold);
        title.Location = new Point(300, 50);
        title.Size = new Size(200, 50);
        rightPanel.Controls.Add(title);

        //Descripcion del apartado
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

        this.Load += new EventHandler(GetAllRegiters!);

    }

}
