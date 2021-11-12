using Newtonsoft.Json;
using ServicioAPI.Logica;
using ServicioAPI.Models;
using ServicioAPI.Models.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioAPI.Controllers
{
    public class HomeController : ApiController
    {
        
        //[HttpGet, Route("~/api/getClient")]
        //public IEnumerable<Clientes> GetClient()
        //{
        //    ClientesFile hf = new ClientesFile();
        //    List<Clientes> listResult = hf.GetClient();
        //    return listResult;
        //}

        [HttpGet, Route("~/api/getClients")]
        public HttpResponseMessage GetClients()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);
            HomeFile hf = new HomeFile();

            List<ClientesDTO> listResult = hf.GetClient();

            if (listResult.Count > 0)
            {
                //Guarda la lista en el response
                response = Request.CreateResponse<IEnumerable>(HttpStatusCode.OK, listResult);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent, "No hay Datos");
            }
            return response;
        }

        [HttpGet, Route("~/api/getItems")]
        public HttpResponseMessage GetItems()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);
            HomeFile hf = new HomeFile();

            List<ItemsDTO> listResult = hf.GetItems();

            if (listResult.Count > 0)
            {
                //Guarda la lista en el response
                response = Request.CreateResponse<IEnumerable>(HttpStatusCode.OK, listResult);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent, "No hay Datos");
            }
            return response;
        }

        [HttpGet, Route("~/api/getVentas")]
        public HttpResponseMessage GetVentas()
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);
            HomeFile hf = new HomeFile();

            List<VentaDTO> listResult = hf.GetVentas();

            if (listResult.Count > 0)
            {
                //Guarda la lista en el response
                response = Request.CreateResponse<IEnumerable>(HttpStatusCode.OK, listResult);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent, "No hay Datos");
            }
            return response;
        }


        [HttpPost, Route("~/api/getVentasCli")]
        public HttpResponseMessage GetVentasCli(object id)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);
            HomeFile hf = new HomeFile();

            List<VentaDTO> listResult = hf.GetVentasCli(int.Parse(id.ToString()));

            if (listResult.Count > 0)
            {
                //Guarda la lista en el response
                response = Request.CreateResponse<IEnumerable>(HttpStatusCode.OK, listResult);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent, "No hay Datos");
            }
            return response;
        }




        [HttpPost, Route("~/api/getItemsFact")]
        public HttpResponseMessage GetItemsFact(object factura)
        {
            var response = Request.CreateResponse(HttpStatusCode.NotImplemented);
            HomeFile hf = new HomeFile();

            List<ItemsFacturaDTO> listResult = hf.GetItemsFact(int.Parse(factura.ToString()));

            if (listResult.Count > 0)
            {
                //Guarda la lista en el response
                response = Request.CreateResponse<IEnumerable>(HttpStatusCode.OK, listResult);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent, "No hay Datos");
            }
            return response;
        }





        [HttpGet, Route("~/api/getClientId")]
        public IEnumerable<Clientes> GetClientId(int id)
        {
            HomeFile hf = new HomeFile();
            List<Clientes> listResult = hf.GetClientId(id);
            return listResult;
        }


        
        [HttpPost, Route("~/api/setClient")]
        public string SetClient(ClientesDTO cliente)
        {
            HomeFile hf = new HomeFile();
            string response = hf.SetClient(cliente);
            return response;
        }



        [HttpPost, Route("~/api/deleteClient")]
        public string DeleteClient(object id)
        {
            HomeFile hf = new HomeFile();
            string response = hf.DeleteClient(int.Parse(id.ToString()));
            return response;
        }



        [HttpPost, Route("~/api/updateClient")]
        public string UpdateClient(ClientesDTO c)
        {
            HomeFile hf = new HomeFile();
            string response = hf.SetClient(c);
            return response;
        }


        [HttpPost, Route("~/api/setItem")]
        public string SetItem(ItemsDTO item)
        {
            HomeFile hf = new HomeFile();
            string response = hf.SetItem(item);
            return response;
        }



        [HttpPost, Route("~/api/deleteItem")]
        public string DeleteItem(object id)
        {
            HomeFile hf = new HomeFile();
            string response = hf.DeleteItem(int.Parse(id.ToString()));
            return response;
        }


        [HttpPost, Route("~/api/setFactura")]
        public string SetFactura(Dictionary<string,object> param )
        {
            var json = JsonConvert.SerializeObject(param["venta"]);
            var venta = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
            json = JsonConvert.SerializeObject(param["items"]);
            var items = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);

            HomeFile hf = new HomeFile();
            string response = hf.SetFactura(venta,items);
            return response;
        }
    }
}
