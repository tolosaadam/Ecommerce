using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WSVenta.Models;
using WSVenta.Models.Request;
using WSVenta.Models.Response;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {
                using (VentalRealContext db = new VentalRealContext())      /* Lo que hace el using es eliminar todo lo que esta 
                                                                             * adentro de las llaves una vez se cierren. */
                {
                    var lst = db.Cliente.OrderByDescending(d=>d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch(Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);                 // "Ok"  Me convierte en json la consulta
        }
    
        [HttpPost]
        public IActionResult Add(RequestCliente oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentalRealContext db = new VentalRealContext())             //Inserccion con Entity
                {
                    Cliente oCliente = new Cliente();                            //Creo un objeto de la clase de la tabla Cliente
                    oCliente.Nombre = oModel.Nombre;                             /* Guardo en ese objeto  lo que 
                                                                                  * recibo en mi request  */
                    db.Cliente.Add(oCliente);                                    // Lo guardo en la "Base de datos"
                    db.SaveChanges();                                            // Guardando la bd

                    oRespuesta.Exito = 1;
                }
                
            }
            catch(Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        
        [HttpPut]
        public IActionResult Edit(RequestCliente oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentalRealContext db = new VentalRealContext())             
                {
                    Cliente oCliente = db.Cliente.Find(oModel.Id);                    /*Busca en la base de datos el registro mediante el ID  
                                                                              * el cual viene en "oModel.id" (Como hacer un where en el id) */
                    oCliente.Nombre = oModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified; /* Le indica al Entity framework que
                                                                                                    * ese registro paso a un estado
                                                                                                    * "modified" */
                    db.SaveChanges();                                            

                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)                  //Solo voy a recibir el Id, no el modelo como antes.
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (VentalRealContext db = new VentalRealContext())
                {
                    Cliente oCliente = db.Cliente.Find(Id);

                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

    }
}
