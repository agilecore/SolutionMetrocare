using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class LogPrestadorController : Base                                 
    {                                                                               
        internal LogPrestador _LogPrestador { get; set; }                 
                                                                                    
        public LogPrestadorController()                                        
        {                                                                           
            _LogPrestador = new LogPrestador();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionLogPrestador = _LogPrestador.GetAll().ToList(); 
            return View(collectionLogPrestador);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new LogPrestadorDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(LogPrestadorDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var LogPrestador = new LogPrestador();                    
                _LogPrestador.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

