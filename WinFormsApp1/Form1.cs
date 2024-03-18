using ProyectoFinal_JuanAlonso.Modelos;
using ProyectoFinal_JuanAlonso.database;
using ProyectoFinal_JuanAlonso.Service;

namespace PresentacionForm
{
    public partial class FrmView : Form
    {
        
        public FrmView()
        {
            InitializeComponent();
        }

        private void FrmView_Load(object sender, EventArgs e)
        {
            //List<Usuario> usuarios = UsuarioService.GetAllUser();
            //this.dvgUsuario.DataSource = usuarios;
        }
    }
}
