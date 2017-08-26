using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class PrestadorController : Base                                 
    {                                                                               
        internal Prestador _Prestador { get; set; }                 
                                                                                    
        public PrestadorController()                                        
        {                                                                           
            _Prestador = new Prestador();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionPrestador = _Prestador.GetAll().ToList(); 
            return View(collectionPrestador);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new PrestadorDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(PrestadorDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Prestador = new Prestador();                    
                _Prestador.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

