using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class LogCredenciadoController : Base                                 
    {                                                                               
        internal LogCredenciado _LogCredenciado { get; set; }                 
                                                                                    
        public LogCredenciadoController()                                        
        {                                                                           
            _LogCredenciado = new LogCredenciado();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionLogCredenciado = _LogCredenciado.GetAll().ToList(); 
            return View(collectionLogCredenciado);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new LogCredenciadoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(LogCredenciadoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var LogCredenciado = new LogCredenciado();                    
                _LogCredenciado.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

