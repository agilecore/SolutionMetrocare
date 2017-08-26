using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class UnidadeTempoController : Base                                 
    {                                                                               
        internal UnidadeTempo _UnidadeTempo { get; set; }                 
                                                                                    
        public UnidadeTempoController()                                        
        {                                                                           
            _UnidadeTempo = new UnidadeTempo();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionUnidadeTempo = _UnidadeTempo.GetAll().ToList(); 
            return View(collectionUnidadeTempo);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new UnidadeTempoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(UnidadeTempoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var UnidadeTempo = new UnidadeTempo();                    
                _UnidadeTempo.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

