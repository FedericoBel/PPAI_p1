using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Entidades
{
    public class Usuario
    {

        private int idUsuario;
        private string clave;
        private string usuario;
        private Boolean habilitado;
        
        // constructor
        public Usuario(int idusuario, string claveusu, string usuariousu, bool habilitadousu)
        {
            idUsuario = idusuario;
            clave = claveusu;
            usuario = usuariousu;
            habilitado = habilitadousu;
        }

        public int idDeUsuario
        {
            get => idUsuario;
            set => idUsuario = value;
        }

        public string claveDeUsuario
        {
            get => clave;
            set => clave = value;
        }
        public string nombreUsuario
        {
            get => usuario;
            set => usuario = value;
        }
        public bool estahabilitado
        {
            get => habilitado;
            set => habilitado = value;
        }


    }

}
