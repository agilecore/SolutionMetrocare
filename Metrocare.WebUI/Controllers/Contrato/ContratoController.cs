using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class ContratoController : Base                                 
    {                                                                               
        internal Contrato _Contrato { get; set; }                 
                                                                                    
        public ContratoController()                                        
        {                                                                           
            _Contrato = new Contrato();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionContrato = _Contrato.GetAll().ToList(); 
            return View(collectionContrato);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new ContratoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(ContratoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Contrato = new Contrato();                    
                _Contrato.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

