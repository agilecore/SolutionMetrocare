using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class TecnicaUtilizadaController : Base                                 
    {                                                                               
        internal TecnicaUtilizada _TecnicaUtilizada { get; set; }                 
                                                                                    
        public TecnicaUtilizadaController()                                        
        {                                                                           
            _TecnicaUtilizada = new TecnicaUtilizada();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionTecnicaUtilizada = _TecnicaUtilizada.GetAll().ToList(); 
            return View(collectionTecnicaUtilizada);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new TecnicaUtilizadaDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(TecnicaUtilizadaDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var TecnicaUtilizada = new TecnicaUtilizada();                    
                _TecnicaUtilizada.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

