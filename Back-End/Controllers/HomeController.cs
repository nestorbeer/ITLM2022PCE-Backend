using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Back_End.Models;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("GetHomeDataSimple")]
        public IActionResult GetHomeDataSimple()
        {
            try
            {
                HomeData homeData = new HomeData();

                homeData.header.nombreEmpresa = "ITLM";
                homeData.header.textoBienvenida = "Welcome home";
                homeData.header.urlLogo = "http://google.com";

                homeData.footer.direccion = "Bogota 115 CP111";
                homeData.footer.horario = "18 a 22hs";
                homeData.footer.telefono = "+54911 444 5566";

                return Ok(homeData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetHomeData")]
        public IActionResult GetHomeData()
        {
            try
            {
                var homeData = new List<object>();

                var header = new Header();
                header.nombreEmpresa = "ITLM";
                header.textoBienvenida = "Welcome home";
                header.urlLogo = "http://google.com";
                homeData.Add(header);

                Footer footer = new Footer();
                footer.direccion = "Bogota 115 CP111";
                footer.horario = "18 a 22hs";
                footer.telefono = "+54911 444 5566";
                homeData.Add(footer);

                /********************************************/
                //Ejemplo de recorrer una lista
                homeData.ForEach(item =>
                {
                    string tipoDeObjeto = item.GetType().Name;
                    if (tipoDeObjeto == "Header")
                    {
                        Header header = (Header)item;

                    }
                    else {
                        Footer footer = (Footer)item;
                    }
                });
                foreach (object item in homeData) {
                    string s = item.ToString();
                }
                /********************************************/
                return Ok(homeData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("GetHeaderData")]
        public IActionResult GetHeaderData()
        {
            try
            {
                Header header = new Header();
                header.nombreEmpresa = "ITLM";
                header.textoBienvenida = "Welcome home";
                header.urlLogo = "http://google.com";

                return Ok(header);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetFooterData")]
        public IActionResult GetFooterData()
        {
            try
            {
                Footer footer = new Footer();
                footer.direccion = "Bogota 115 CP111";
                footer.horario = "18 a 22hs";
                footer.telefono = "+54911 444 5566";
                return Ok(footer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
