using System;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_v1
{
    public partial class Admin : Form
    {


        string nombre, clave, documento, contacto;
        bool validar, validarId;


        public Admin()
        {

            InitializeComponent();
        }

        private void dvgDirectivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow Row in dvgDirectivos.Rows)
                {

                    txtName.Text = dvgDirectivos.CurrentRow.Cells["ColumnName"].Value.ToString();
                    txtContact.Text = dvgDirectivos.CurrentRow.Cells["ColumnContact"].Value.ToString();
                    txtId.Text = dvgDirectivos.CurrentRow.Cells["ColumnId"].Value.ToString();
                    txtPass.Text = dvgDirectivos.CurrentRow.Cells["ColumnPassword"].Value.ToString();
                }

                desactBtn();
            }
            catch { }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            nombre = txtName.Text;
            documento = txtId.Text;
            clave = txtPass.Text;
            contacto = txtContact.Text;
            validar = valDatos(nombre, documento, clave, contacto);

            if (validar == true)
            {

                validarId = valId(documento);
                if (validarId == true)
                {

                    dvgDirectivos.Rows.Add(nombre, documento, clave, contacto);
                    MessageBox.Show("Usuario registrado con éxito");
                    limpiar();
                }

            }

        }

        public bool valDatos(string name, string id, string pass, string contact)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Falta ingresar el NOMBRE ");
                errorProviderValidar.SetError(txtName, "Ingrese nombre");
                validar = false;
            }
            else

            if (txtPass.Text == "")
            {
                MessageBox.Show("Falta ingresar la CONTRASEÑA ");
                errorProviderValidar.SetError(txtPass, "Ingrese contraseña");
                validar = false;
            }
            else

            if (txtId.Text == "")
            {
                MessageBox.Show("Falta ingresar el DOCUMENTO");
                errorProviderValidar.SetError(txtId, "Ingrese documento");
                validar = false;
            }
            else

            if (txtContact.Text == "")
            {
                MessageBox.Show("Falta ingresar la información de CONTACTO");
                errorProviderValidar.SetError(txtContact, "Ingrese la información de contacto");
                validar = false;

            }
            else
            {

                validar = true;
                errorProviderValidar.SetError(txtName, "");
                errorProviderValidar.SetError(txtPass, "");
                errorProviderValidar.SetError(txtId, "");
                errorProviderValidar.SetError(txtContact, "");
            }

            return validar;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            nombre = txtName.Text;
            documento = txtId.Text;
            clave = txtPass.Text;
            contacto = txtContact.Text;
            validar = valDatos(nombre, documento, clave, contacto);
            validarId = true;

            if (validar == true)
            {
                if (documento != dvgDirectivos.CurrentRow.Cells["ColumnId"].Value.ToString())
                {
                    validarId = valId(documento);


                }
                if (validarId == true)
                {
                    dvgDirectivos.CurrentRow.Cells["ColumnName"].Value = nombre;
                    dvgDirectivos.CurrentRow.Cells["ColumnId"].Value = documento;
                    dvgDirectivos.CurrentRow.Cells["ColumnPassword"].Value = clave;
                    dvgDirectivos.CurrentRow.Cells["ColumnContact"].Value = contacto;
                    MessageBox.Show("Usuario modificado correctamente");
                    actBtn();
                    limpiar();
                }

            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
         

            string question = "¿Eliminar este usuario?";
            string title = "Eliminar usuario";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(question, title, buttons);

            if(result == DialogResult.Yes)
            {
                dvgDirectivos.Rows.RemoveAt(dvgDirectivos.CurrentRow.Index);
                MessageBox.Show("Usuario eliminado correctamente.");
                actBtn();
                limpiar();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            guardarDatos();
        }

        public bool valId(string id)
        {
            validarId = true;

            for (int i = 0; i < dvgDirectivos.Rows.Count; i++)
            {

                foreach (DataGridViewRow Row in dvgDirectivos.Rows)
                {
                    String strFila = ColumnId.Index.ToString();
                    string valor = Convert.ToString(Row.Cells["ColumnId"].Value);

                    if (valor == id)
                    {
                        MessageBox.Show("Ya existe este documento:");
                        errorProviderValidar.SetError(txtId, "Ingrese otro documento");
                        validarId = false;
                        break;
                    }
                    else
                    {

                        errorProviderValidar.SetError(txtId, "");
                        validarId = true;
                    }

                }
            }
            return validarId;
        }

        private void guardarDatos()
        {
            StreamWriter baseDatos;
            string linea;

            baseDatos = new StreamWriter("./base.txt");

            


        }

        private void limpiar()
        {
            txtName.Text = "";
            txtContact.Text = "";
            txtPass.Text = "";
            txtId.Text = "";


        }

        private void actBtn()
        {

            btnAdd.Enabled = true;
            btnSave.Enabled = true;
            btnDel.Enabled = false;
            btnMod.Enabled = false;

        }

        private void desactBtn()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            btnDel.Enabled = true;
            btnMod.Enabled = true;
        }

    }
}
