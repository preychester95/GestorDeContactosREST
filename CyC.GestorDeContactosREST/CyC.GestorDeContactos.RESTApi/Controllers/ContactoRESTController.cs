using CyC.GestorDeContactos.AccesoDatos.DAL;
using CyC.GestorDeContactos.AccesoDatos.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CyC.GestorDeContactos.RESTApi.Controllers
{
    [RoutePrefix("api/contacto")]
    public class ContactoRESTController : ApiController
    {
        //Obtener todos los contactos. GET sin pasar parámetros por URL
        [System.Web.Http.HttpGet]
        [Route("obtenerContactos")]
        public List<Contacto> getAllContactos()
        {
            return ContactoDAL.getAllContactos();
        }

        //Obtener un contacto por id. GET pasando un parámetro por URL
        [System.Web.Http.HttpGet]
        [Route("contactoById/{idContacto}")]
        public Contacto getContactoById(string idContacto)
        {
            return ContactoDAL.getContactoByGuid(Guid.Parse(idContacto));
        }

        //Crear un contacto. POST
        [System.Web.Http.HttpPost]
        [Route("createContacto")]
        public void createContacto([FromBody] Contacto nuevoContacto)
        {
            nuevoContacto.UIDContacto = Guid.NewGuid();
            ContactoDAL.createContacto(nuevoContacto);
        }

        //POST pasando algún parámetro por URL
        //[System.Web.Http.HttpPost]
        //[Route("createContacto/{name}/{surname}")]
        //public void createContacto([FromBody] Contacto nuevoContacto, string name, string surname)
        //{
        //    string nombre = name;
        //    string apellido = surname;
        //    nuevoContacto.UIDContacto = Guid.NewGuid();
        //    ContactoDAL.createContacto(nuevoContacto);
        //}

        //Actualizar un contacto. PUT
        [System.Web.Http.HttpPut]
        [Route("updateContacto")]
        public void updateContacto([FromBody] Contacto contactoToUpdate)
        {
            ContactoDAL.updateContacto(contactoToUpdate);
        }

        //Borrar registro. DELETE
        [System.Web.Http.HttpDelete]
        [Route("deleteContacto")]
        public void deleteContacto([FromBody] Contacto contactoToDelete)
        {
            ContactoDAL.deleteContacto(contactoToDelete);
        }

    }
}
