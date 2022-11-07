using PPAI_CU36.Datos.Models;
using PPAI_CU36.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_CU36.Datos
{
    class Iterador
    {
        public BD db = new BD();


       public void iteradorMarca()
        {
            MarcaModel marcaDB = new MarcaModel();
            List<Marca> m = new List<Marca> { new Marca { nombre = "Shidmazu "} , new Marca { nombre = "Nikon"} };
            for (int i = 0; i < m.Count; i++)
            {
                marcaDB.desmaterializar(m[i]);
            }
        }

        public void iteradorRTM()
        {
            TipoRecursoTecnologicoModel marcaDB = new TipoRecursoTecnologicoModel ();
            List<TipoRecursoTecnologico> m = new List<TipoRecursoTecnologico> { new TipoRecursoTecnologico
            {
                nombre = "Balanza de precisión",
                descripcion = "recurso1fede",

            },
            new TipoRecursoTecnologico
            {
                nombre = "Microscopio de medición",
                descripcion = "recurso2erik",

            }
        };
            for (int i = 0; i < m.Count; i++)
            {
                marcaDB.desmaterializar(m[i]);
            }
        }

        public void iteradorModelos()
        {
            var marca1 = new Marca
            {
                nombre = "Shidmazu ",
            };
            var marca2 = new Marca
            {
                nombre = "Nikon",
            };
            ModeloModel usM = new ModeloModel();
            List<Modelo> lista = new List<Modelo> {
                new Modelo{nombre = "TXB622L", marca = marca1},
                new Modelo{nombre = "MM-400/800 ",marca = marca2, }
                 };
            for (int i = 0; i < lista.Count; i++)
            {
                usM.desmaterializar(lista[i]);
            }
        }

        public void iteradorPC()
        {
            PersonalCientificoModel usM = new PersonalCientificoModel();
            List<PersonalCientifico> lista = BD.ListaPersonal();
            for (int i = 0; i < lista.Count; i++)
            {
                usM.desmaterializar(lista[i]);
            }
        }
        public void iteradorUsuario()
        {
            UsuarioModel usM = new UsuarioModel();
            List<Usuario> lista = BD.ListaUsuarios();
            for (int i = 0; i < lista.Count; i++)
            {
                usM.desmaterializar(lista[i]);
            }
        }

        public void iteradorEstados()
        {
            EstadoModel usM = new EstadoModel();
            List<Estado> lista = BD.ListaEstados();
            for (int i = 0; i < lista.Count; i++)
            {
                usM.desmaterializar(lista[i]);
            }
        }

        public void iteradorRT()
        {
            RecursoTecnologicoModel usM = new RecursoTecnologicoModel();
            List<RecursosTecnologicos> lista = BD.ListaRecursos();
            for (int i = 0; i < lista.Count; i++)
            {
                usM.desmaterializar(lista[i]);
            }
        }

        

        public void iteradorAsignacionRT()
        {
            AsignacionResponsableTecnicoModel usM = new AsignacionResponsableTecnicoModel();
            List<AsignacionResponsableTecnicoRT> lista = BD.ListaAsignacionesResponsableTecnicoRT();
            for (int i = 0; i < lista.Count; i++)
            {
                usM.desmaterializar(lista[i]);
            }
        }

        public void iteradorAsignacionCI()
        {
            AsignacionCientificoDelCIModel usM = new AsignacionCientificoDelCIModel();
            List<AsignacionCientificoDelCI> lista = BD.ListaAsignacionCien();
            for (int i = 0; i < lista.Count; i++)
            {
                usM.desmaterializar(lista[i]);
            }
        }
        public void iteradorsesion()
        {
            SesionModel s = new SesionModel();
            Sesion lista = BD.ListaSesion();
            s.desmaterializar(lista);
           
        }
    }
    
}
